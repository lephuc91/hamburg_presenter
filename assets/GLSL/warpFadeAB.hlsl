#include "dxShaderIncludes.h"
#include "alpha.h"

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
    float x1 = u.transitionProgressLinear;
    vec2 p1 = input.tex1;
    vec2 p2 = input.tex2;

    float x2=smoothstep(.20,.80,(x1*2.0+p1.x-1.0));
    x1=smoothstep(.20,.80,(x1*2.0+p1.x-1.0));

    vec2 tc1=(p1-.5)*(1.-x1)+.5;
    vec2 tc2=(p2-.5)*(1.-x2)+.5;

    tc1=(p1-.5)*x1+.5;
    // tc2=(p2-.5)*x2+.5;

    vec4 colorA=getColor(inputTex0,tc1);
    vec4 colorB=getColor(inputTex1,tc2);
    float4 outColor;
    mixColor(outColor, colorB, colorA, u.transitionProgressLinear);

#ifdef USE_MASK
    multiplyOpacity(outColor, float(inputTexMask.Sample(linearSampler, input.texMask).a));
#endif

    return outColor;
}
