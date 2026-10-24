#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float radius;
} fxVars;


cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

fxVertexOut vertexShader(fxShaderVerts input)
{
    fxVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy * vec2(.5,.5f);
    output.tex1 = input.tex1;
    output.texMask = input.texMask;
    output.texSize = u.texSize;
    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    float4 texel = getColor(inputTex, fsTexture);
    float fsOuterRadius = vars.radius * 0.01;
    float fsInnerRadius = fsOuterRadius * 0.5;
    float dist = distance(input.normPos, vec2(0.0, 0.0));
    float blend = 1.0 - (fsOuterRadius - dist) / (fsOuterRadius - fsInnerRadius);
    blend = clamp(blend, 0.0, 1.0);
    blend *= u.blendValue;
#ifdef USE_MASK
    blend *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    float4 vignetteColor = float4(0.0, 0.0, 0.0, 1.0);
    float4 outColor;
    mixColor(outColor, texel, vignetteColor, blend);
    return outColor;
}
