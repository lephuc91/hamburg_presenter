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

    x1=smoothstep(.20,.80,(x1*2.0+p1.x-1.0));

    vec2 tc1=(p1-.5)*(1.-x1)+.5;
    
    tc1=(p1-.5)*x1+.5;

    vec2 texA=mix(tc1,p1,u.transitionProgressLinear);
    vec2 texB=mix(p1,tc1,u.transitionProgressLinear);
    vec2 useTex=mix(texB,texA,u.mix);

    vec4 outColor = getColor(inputTex0, useTex);

    float fsMix = u.transitionState == 2 ? 1.0 - u.transitionProgress : u.transitionProgress;
    float alpha = fsMix * u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);

    return outColor;
}
