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

float4 grayscale(float4 color)
{
    float gray = 0.2126*color.r + 0.7152*color.g + 0.0722*color.b;
    return float4(gray, gray, gray, color.a);
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float4 colorA = getColor(inputTex0, input.tex1);
    float4 colorB = getColor(inputTex1, input.tex2);

#ifndef PRE_MULT
    multiplyAlpha(colorA);
    multiplyAlpha(colorB);
#endif

    float4 color1 = mix(grayscale(colorA), colorA, smoothstep(0.6, 1.0, u.transitionProgress));
    float4 color2 = mix(grayscale(colorB), colorB, smoothstep(0.6, 1.0, 1. - u.transitionProgress));
    float4 outColor = mix(color2, color1, u.transitionProgress);

#ifdef USE_MASK
    multiplyOpacityPremultiplied(outColor, float(inputTexMask.Sample(linearSampler, input.texMask).a));
#endif

#ifndef PRE_MULT
    divideAlpha(outColor);
#endif

    return outColor;
}
