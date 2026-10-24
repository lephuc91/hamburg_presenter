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


    float progress=u.transitionProgressLinear;
    vec4 outColor;
    float alpha = 1.0;
    if(u.transitionState==0)
    {
        outColor=getColor(inputTex0,(input.tex1+inv*disp));
        alpha *= progress;
    }
    else
    {
        outColor.r=getColor(inputTex0,(input.tex1+progress*disp2*(1.0-vars.colorSeparation))).r;
        outColor.ga=getColor(inputTex0,(input.tex1+progress*disp2)).ga;
        outColor.b=getColor(inputTex0,(input.tex1+progress*disp2*(1.0+vars.colorSeparation))).b;
        alpha *= inv;
    }

    alpha *= u.baseAlpha;

#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif

    multiplyOpacity(outColor, alpha);
    return outColor;
}
