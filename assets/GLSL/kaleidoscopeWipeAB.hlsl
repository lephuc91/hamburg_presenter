#include "dxShaderIncludes.h"
#include "kaleidoscopeHelper.h"
#include "alpha.h"

static const float speed=1.;
static const float angle=2.;
static const float power=2.;



typedef struct
{
    float4 position: SV_POSITION;
    float2 tex1: TEXCOORD0;
    float2 tex2: TEXCOORD1;
    float2 texMask: TEXCOORD2;
} vertexOut2;


vertexOut2 vertexShader(txShaderVerts input)
{
    vertexOut2 output;
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    return output;
}

float4 pixelShader(vertexOut2 input) : SV_TARGET
{
    float2 p = input.tex1;
    float2 p2 = input.tex2;
    kaleidoscopeTransform(p, u.transitionProgressLinear, power, speed);

    float4 colorA = getColor(inputTex0, input.tex1);
    float4 colorB = getColor(inputTex1, input.tex2);
    float4 colorA2 = getColor(inputTex0, p);
    float4 colorB2 = getColor(inputTex1, p2);

#ifndef PRE_MULT
    multiplyAlpha(colorA);
    multiplyAlpha(colorB);
    multiplyAlpha(colorA2);
    multiplyAlpha(colorB2);
#endif

    colorA = mix(colorA, colorA2, 1.0 - 2.0 * abs(u.transitionProgressLinear - 0.5));
    colorB = mix(colorB, colorB2, 1.0 - 2.0 * abs(u.transitionProgressLinear - 0.5));
    float4 outColor = mix(colorB, colorA, u.transitionProgressLinear);

#ifdef USE_MASK
    multiplyOpacityPremultiplied(outColor, float(inputTexMask.sample(linearSampler, input.texMask).a));
#endif

#ifndef PRE_MULT
    divideAlpha(outColor);
#endif

    return outColor;
}
