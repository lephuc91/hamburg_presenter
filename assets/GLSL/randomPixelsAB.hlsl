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
    output.normPos=input.position.xy*vec2(.5,.5f)+vec2(.5,.5);
    return output;
}


float4 pixelShader(vertexOut input) : SV_TARGET
{
    float mixVal=step(rand(input.normPos), u.transitionProgressLinear);
    vec4 texelA=getColor(inputTex0,input.tex1);
    vec4 texelB=getColor(inputTex1,input.tex2);
    float4 outColor=mix(texelB,texelA,mixVal);

#ifdef USE_MASK
    multiplyOpacity(outColor, float(inputTexMask.Sample(linearSampler, input.texMask).a));
#endif

    return outColor;
}
