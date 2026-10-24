#include "dxShaderIncludes.h"
#include "alpha.h"

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
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.normPos=input.position.xy*vec2(.5,.5f)+vec2(.5,.5);
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float4 outColor = u.transitionProgressLinear < 0.5
        ? getColor(inputTex1, input.tex2)
        : getColor(inputTex0, input.tex1);
    float4 burnColor = float4(0,0,0,0);

#ifndef PRE_MULT
    multiplyAlpha(outColor);
#endif

    outColor = u.transitionProgressLinear < 0.5
        ? mix(outColor, burnColor, u.transitionProgressLinear * 2.0)
        : mix(burnColor, outColor, (u.transitionProgressLinear - 0.5) * 2.0);

#ifdef USE_MASK
    multiplyOpacityPremultiplied(outColor, float(inputTexMask.Sample(linearSampler, input.texMask).a));
#endif

#ifndef PRE_MULT
    divideAlpha(outColor);
#endif

    return outColor;
}
