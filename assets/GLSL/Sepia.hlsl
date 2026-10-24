#include "dxEffectIncludes.h"
#include "alpha.h"

fxVertexOut vertexShader(fxShaderVerts input)
{
    fxVertexOut output;
    output.position =float4(input.position,1);
    output.tex1 = input.tex1;
    output.texMask = input.texMask;
    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    float4 texel = getColor(inputTex,fsTexture);
#ifdef PRE_MULT
    divideAlpha(texel);
#endif

#ifdef LINEAR_16
    // Convert to grayscale using NTSC conversion weights
    float gray = dot(texel.xyz, vec3(0.355, 0.658, 0.004));
    float4 outColor = vec4(gray * vec3(0.970, 1.0, 0.878), texel.a);
#else
    // convert grayscale to sepia
    float gray = dot(texel.rgb, vec3(0.299, 0.587, 0.114));
    float4 outColor = vec4(gray * vec3(1.2, 1.0, 0.8), texel.a);
#endif

    float blendValue=u.blendValue;

#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    outColor.rgb=mix(texel.rgb,outColor.rgb,blendValue);
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}
