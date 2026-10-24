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

vec2 offset(float scale,float progress, float x, float theta)
{
    float shifty = 0.023*scale*cos(10.0*(progress+x));
    return vec2(0, shifty);
}


float4 pixelShader(vertexOut input) : SV_TARGET
{
    float fsMix=u.transitionProgress;
    float fsProgress;
    if(u.transitionProgress<.5)
    {
        fsProgress=u.transitionProgressLinear/.5;
    }
    else
    {
        fsProgress=1.-(u.transitionProgressLinear-.5)/.5;
    }

    vec2 p1 = input.tex1;
    vec2 p2 = input.tex2;

    vec4 colorA=getColor(inputTex0,(p1+offset(fsProgress,fsMix,p1.x,0.0)));
    vec4 colorB=getColor(inputTex1,(p2+offset(fsProgress,fsMix,p2.x,3.145)));

    float4 outColor;
    mixColor(outColor, colorB, colorA, u.transitionProgressLinear);

#ifdef USE_MASK
    multiplyOpacity(outColor, float(inputTexMask.Sample(linearSampler, input.texMask).a));
#endif

    return outColor;
}
