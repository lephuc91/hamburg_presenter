#include "inputShaderHelperDX.h"
#include "commonMLDX.h"
#include "alpha.h"
#include "inputColorHelper.h"

v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position,1.0);
    output.texCoordY = input.texCoordY;
    output.texCoordUV = input.texCoordY;
    return output;
}

float4 pixelShader(v2p input) : SV_TARGET
{
    float width,height;
    inputTex0.GetDimensions(width,height);
    float2 normalizedTC=input.texCoordY/float2(width,height);

#ifdef ARGB
    float4 outColor= inputTex0.Sample(nearestSampler, normalizedTC).argb;
#endif

#ifdef ABGR
    float4 outColor= inputTex0.Sample(nearestSampler, normalizedTC).abgr;
#endif

#ifdef BGRA
    float4 outColor= inputTex0.Sample(nearestSampler, normalizedTC).bgra;
 #endif

 #ifdef RGBA
    float4 outColor= inputTex0.Sample(nearestSampler, normalizedTC).rgba;
 #endif

    outColor=processColorProfile(outColor);

#ifdef USE_MASK
    multiplyOpacity(outColor, textureFetchNearest(maskTex, input.maskCoord).a);
#endif

#ifdef USE_END_COLOR
    mixColor(outColor, uniforms.endColor, outColor, uniforms.endOpacity);
#endif

    return outColor;
}
