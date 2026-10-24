#include "dxShaderIncludes.h"
#include "alpha.h"

typedef struct
{
    float4 burnColor;
    float pad[3];
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
    output.normPos=input.position.xy*vec2(.5,.5f)+vec2(.5,.5);
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float dist=length(input.tex1-vec2(.5,.5));

    float outAlpha=dist-u.transitionProgress;
    outAlpha+=.05;
    outAlpha*=20.;
    outAlpha=min(outAlpha,1.0);
    outAlpha=max(outAlpha,0.0);

    vec4 colorA = getColor(inputTex0, input.tex1);
    vec4 colorB = getColor(inputTex1, input.tex2);
    float4 outColor;
    mixColor(outColor, colorA, colorB, outAlpha);

    float alpha = u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);

    return outColor;
}
