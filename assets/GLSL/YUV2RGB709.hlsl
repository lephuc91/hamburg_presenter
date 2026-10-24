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
#ifdef AYUV
    float textureWidth;
    float textureHeight;
    float isOddUV;

    inputTex0.GetDimensions(textureWidth,textureHeight);

    isOddUV = 1.0 - floor(frac(input.texCoordY.x * 0.5) * 2.0);

    float2 normalizedTC=input.texCoordY/float2(textureWidth,textureHeight);
    
    float4 yuvIn = inputTex0.Sample(nearestSampler,normalizedTC).argb;
    yuvIn += stdbias;

    float4 outColor = float4(dot(yuv2R, yuvIn),
                             dot(yuv2G, yuvIn),
                             dot(yuv2B, yuvIn),
                             yuvIn.a);

    outColor=processColorProfile(outColor);

#ifdef USE_MASK
    multiplyOpacity(outColor, textureFetchNearest(maskTex, input.maskCoord).a);
#endif

#ifdef USE_END_COLOR
    mixColor(outColor, uniforms.endColor, outColor, uniforms.endOpacity);
#endif

    return outColor;
#else
    float4 yuvIn;

    float4 y0;
    float4 y1;

    float isOddUV;
    float textureWidth;
    float textureHeight;

    inputTex0.GetDimensions(textureWidth,textureHeight);

    isOddUV = 1.0 - floor(frac(input.texCoordY.x * 0.5) * 2.0);

    float2 normalizedTC=input.texCoordY/float2(textureWidth*2.,textureHeight);

    float alpha = 1.0;

    #ifdef YUYV
    y0 = float4(inputTex0.Sample(nearestSampler,normalizedTC)).argb;
    #endif
    
    #ifdef Y1UY0V
    y0 = float4(inputTex0.Sample(nearestSampler,normalizedTC)).abgr;
    #endif

    #ifdef UYVY
    y0 = float4(inputTex0.Sample(nearestSampler,normalizedTC)).rabg;
    #endif

#ifdef YUVA
    y0 = float4(inputTex0.Sample(nearestSampler,normalizedTC)).rabg;
    alpha = float4(inputTex1.Sample(nearestSampler,normalizedTC)).r;
#endif

    y1=y0;
    y1.g=y0.a;
    y0=lerp(y0,y1,isOddUV);

    y0+=stdbias;

    float4 outColor=float4(dot(yuv2R, y0),
        dot(yuv2G, y0),
        dot(yuv2B, y0),
        alpha);

    outColor=processColorProfile(outColor);

#ifdef USE_MASK
    multiplyOpacity(outColor, maskTex.Sample(nearestSampler, normalizedTC).a);
#endif

#ifdef USE_END_COLOR
    mixColor(outColor, uniforms.endColor, outColor, uniforms.endOpacity);
#endif

    return outColor;
#endif
}
