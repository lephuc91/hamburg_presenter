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

    // Convert to grayscale
#ifdef LINEAR_16
    float gray = dot(texColor.rgb, vec3(0.355, 0.658, 0.004));
#else
    float gray = dot(texColor.rgb, vec3(0.299, 0.587, 0.114));
#endif

    // invert
    gray = u.nitsScale - gray;

    // replicate grayscale to RGB components
    float4 outColor = vec4(gray, gray, gray, texColor.a);

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    outColor.rgb=mix(texColor.rgb,outColor.rgb,blendValue);
    outColor.a=texColor.a;

#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}
