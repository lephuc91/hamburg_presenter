
#include "dxShaderIncludes.h"
#include "alpha.h"

float rand (vec2 co)
{
    return fract(sin(dot(co.xy ,vec2(12.9898,78.233))) * 43758.5453);
}

float Gaussian(float p, float center, float c)
{
    return 0.575 * exp(- pow((p - center) / c, 2.));
}

#define PI 3.1415926535897932384626433832795
float cosCurve(float p)
{
    return 0.5 * (cos(2.0*PI * (p - 0.5)) + 1.0);
}

vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    return output;
}


float4 pixelShader(vertexOut input) : SV_TARGET
{
    vec2 p = input.tex1;

    float c = cos(0.575 * cosCurve(u.transitionProgressLinear * (1. + cosCurve(u.transitionProgressLinear) * Gaussian(u.transitionProgressLinear * rand(p), 0.5, 0.5))));
    vec2 d = p * c;

    vec4 texColor=getColor(inputTex0,d);
    vec4 colorA=mix(vec4(0,0,0,0),texColor,u.mix);
    vec4 colorB=mix(texColor,vec4(0,0,0,0),u.mix);
    float4 outColor;
    mixColor(outColor, colorB, colorA, u.transitionProgressLinear);

    float alpha = u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);

    return outColor;
}

