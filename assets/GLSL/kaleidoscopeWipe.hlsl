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
    kaleidoscopeTransform(p, u.transitionProgressLinear, power, speed);

    float4 colorA = getColor(inputTex0, input.tex1);
#ifdef OPACITY_MASK
    float4 texColor = colorA;
#endif
    float4 colorA2 = getColor(inputTex0, p);

#ifndef PRE_MULT
    multiplyAlpha(colorA);
    multiplyAlpha(colorA2);
#endif

    float4 colorB = colorA;
    multiplyOpacityPremultiplied(colorB, u.transitionAlpha);
    colorA = mix(colorA, colorA2, 1.0 - 2.0 * abs(u.transitionProgressLinear - 0.5));
    float4 outColor = mix(colorB, colorA, u.mix);

#ifdef OPACITY_MASK
    float maxOpacity = texColor.a;
    outColor = min(outColor, float4(maxOpacity, maxOpacity, maxOpacity, maxOpacity));
#endif

    float fsMix = u.transitionState == 2 ? 1.0 - u.transitionProgress : u.transitionProgress;
    float alpha = fsMix * u.baseAlpha;

#ifdef USE_MASK
    alpha *= float(inputTexMask.sample(linearSampler, input.texMask).a);
#endif

    multiplyOpacityPremultiplied(outColor, alpha);

#ifndef PRE_MULT
    divideAlpha(outColor);
#endif

    return outColor;
}
