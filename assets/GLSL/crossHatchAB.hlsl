#include "dxShaderIncludes.h"
#include "alpha.h"

float rand(vec2 co)
{
    float a = 12.9898;
    float b = 78.233;
    float c = 43758.5453;
    float dt= dot(co.xy ,vec2(a,b));
    float sn= mod(dt,3.14);
    return fract(sin(sn) * c);
}


vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.normPos = input.position.xy;
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{

    vec2 p = input.normPos;

    float x = u.transitionProgressLinear*2.5;
    float dist = distance(vec2(0.,0.), p);
    float r = x - min(rand(vec2(p.y, 0.0)), rand(vec2(0.0, p.x)));
    float m = dist <= r ? 1.0 : 0.0;

    float4 outColor=mix(getColor(inputTex1,input.tex2),getColor(inputTex0,input.tex1),m);
#ifdef USE_MASK
    multiplyOpacity(outColor, float(inputTexMask.Sample(linearSampler, input.texMask).a));
#endif
    return outColor;
}
