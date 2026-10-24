#include "dxShaderIncludes.h"
#include "alpha.h"

typedef struct
{
    float zoom;
    float size;
    float colorSeparation;
    float pad;
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
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float inv = 1. - u.transitionProgressLinear;
    vec2 disp = vars.size*vec2(cos(vars.zoom*input.tex1.x), sin(vars.zoom*input.tex1.y));
    vec2 disp2=vars.size*vec2(cos(vars.zoom*input.tex2.x), sin(vars.zoom*input.tex2.y));

    vec4 colorIn=getColor(inputTex0,(input.tex1+inv*disp));

    float progress=u.transitionProgressLinear;
    vec4 colorOut;

    colorOut.r=getColor(inputTex1,(input.tex2+progress*disp2*(1.0-vars.colorSeparation))).r;
    colorOut.ga=getColor(inputTex1,(input.tex2+progress*disp2)).ga;
    colorOut.b=getColor(inputTex1,(input.tex2+progress*disp2*(1.0+vars.colorSeparation))).b;

#ifndef PRE_MULT
    multiplyAlpha(colorOut);
    multiplyAlpha(colorIn);
#endif
    float4 outColor=mix(colorOut,colorIn,u.transitionProgress);
#ifndef PRE_MULT
    divideAlpha(outColor);
#endif

#ifdef USE_MASK
    multiplyOpacity(outColor, float(inputTexMask.Sample(linearSampler, input.texMask).a));
#endif

    return outColor;
}
