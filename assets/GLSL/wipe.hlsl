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
    output.position = mul(u.worldViewProj, float4(input.position, 1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.normPos = input.position.xy * 0.5 + center;
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float2 dir = normalize(directionTable[vars.direction]);
    dir.y *= u.verticalDirectionFlip;
    float diagonalScale = abs(dir.x) + abs(dir.y);
    if (diagonalScale > 0)
        dir /= diagonalScale;
    float prog = dot(dir, input.normPos) - dot(dir, center) + (1 - u.transitionProgress) * 1.2 - 0.1;
    float alpha = smoothstep(0.4, 0.6, prog);
    alpha = mix(alpha, 1 - alpha, u.mix);
    alpha *= u.baseAlpha;

#ifdef USE_MASK
    alpha *= float(inputTexMask.sample(linearSampler, input.texMask).a);
#endif

    float4 outColor = getColor(inputTex0, input.tex1);
    multiplyOpacity(outColor, alpha);
    return outColor;
}
