#include "dxShaderIncludes.h"
#include "alpha.h"

typedef struct
{
    int direction;
    float pad[3];
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

static const float2 directionTable[9] = {
    float2( 1,  1),
    float2( 0,  1),
    float2(-1,  1),
    float2( 1,  0),
    float2( 0,  0),
    float2(-1,  0),
    float2( 1, -1),
    float2( 0, -1),
    float2(-1, -1)
};

static const float2 center = float2(0.5, 0.5);

vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.position = mul(u.worldViewProj, float4(input.position, 1));
    output.normPos = input.position.xy * 0.5 + center;
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float2 p = input.normPos;
    float2 dir = normalize(directionTable[vars.direction]);
    float diagonalScale = abs(dir.x) + abs(dir.y);
    if (diagonalScale > 0)
        dir /= diagonalScale;
    float offset = 1.0;
    float prog = dot(dir, p) - dot(dir, center) + 0.5 - u.transitionProgressLinear * (1.0 + offset);
    float pr = smoothstep(-offset, 0.0, prog) * 0.5;
    float2 squares = float2(10, 10);
    float2 squarep = fract(p * squares);
    float2 squaremin = float2(pr, pr);
    float2 squaremax = float2(1.0 - pr, 1.0 - pr);
    float which = all(squaremin <= squarep) && all(squarep <= squaremax) ? 1.0 : 0.0;
    float4 texelA = getColor(inputTex0, input.tex1);
    float4 texelB = getColor(inputTex1, input.tex2);
    float4 outColor = mix(texelB, texelA, which);
    float alpha = u.baseAlpha;

#ifdef USE_MASK
    alpha *= float(inputTexMask.sample(linearSampler, input.texMask).a);
#endif

    multiplyOpacity(outColor, alpha);
    return outColor;
}
