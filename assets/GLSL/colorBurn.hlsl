#include "dxShaderIncludes.h"
#include "alpha.h"
#include "fadeHelper.h"

typedef struct
{
    float4 burnColor;
    float pad[3];
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = mul(u.worldViewProj, float4(input.position, 1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    vec4 texColor = getColor(inputTex0, input.tex1);
    vec4 burnColor = vars.burnColor;
#ifndef PRE_MULT
    multiplyAlpha(texColor);
#endif
    multiplyAlpha(burnColor); // burnColor always comes in straight alpha
    vec4 outColor;
    colorBurn(outColor, texColor, burnColor, u.transitionProgress, u.mix);
    float alpha = u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.sample(linearSampler, input.texMask).a);
#endif
    outColor *= alpha;
#ifndef PRE_MULT
    divideAlpha(outColor);
#endif
    return outColor;
}
