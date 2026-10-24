#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float red;
    float green;
    float blue;
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

fxVertexOut vertexShader(fxShaderVerts input)
{
    fxVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy * vec2(.5,.5f) + vec2(.5,.5);
    output.tex1 = input.tex1;
    output.texMask = input.texMask;
    output.texSize = u.texSize;
    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    vec4 texColor = getColor(inputTex, fsTexture);
#ifdef PRE_MULT
    divideAlpha(texColor);
#endif
    float4 outColor;
    outColor.rgb = vec3(u.nitsScale, u.nitsScale, u.nitsScale) - texColor.rgb;

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    outColor.rgb=mix(texColor.rgb,outColor.rgb,blendValue);
    outColor.a=texColor.a;
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}
