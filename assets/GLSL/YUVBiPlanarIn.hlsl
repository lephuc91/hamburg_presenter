#include "inputShaderHelperDX.h"
#include "commonMLDX.h"
#include "alpha.h"
#include "inputColorHelper.h"

v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position, 1.0);
    output.texCoordY = input.texCoordY;
    output.texCoordUV = input.texCoordY;
    return output;
}

float4 pixelShader(v2p input) : SV_TARGET
{
    float4 yuvIn;

    float width, height;
    inputTex0.GetDimensions(width, height);
    float2 normalizedTC = input.texCoordY / float2(width, height);

    yuvIn.g = inputTex0.Sample(nearestSampler, normalizedTC).r;
    yuvIn.br = inputTex1.Sample(nearestSampler, normalizedTC).rg;
    yuvIn.a = 0.0;

#ifdef HAS_ALPHA
    yuvIn.a = inputTex3.Sample(nearestSampler, normalizedTC).r;
#endif

#ifdef IS_10BIT
    yuvIn*=float4(64.0, 64.0, 64.0, 64.0);;
#endif

#ifdef IS_12BIT
    yuvIn*=float4(16.0, 16.0, 16.0, 16.0);
#endif

    yuvIn += stdbias;

    float4 outColor = float4(dot(yuv2R, yuvIn),
        dot(yuv2G, yuvIn),
        dot(yuv2B, yuvIn),
        1.0);

    outColor = processColorProfile(outColor);

#ifdef USE_MASK
    multiplyOpacity(outColor, maskTex.Sample(nearestSampler, normalizedTC).a);
#endif

#ifdef USE_END_COLOR
    mixColor(outColor, uniforms.endColor, outColor, uniforms.endOpacity);
#endif

    return outColor;
}
