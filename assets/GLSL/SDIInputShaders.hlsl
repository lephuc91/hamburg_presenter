#include "commonMLDX.h"
#include "alpha.h"
#include "inputColorHelper.h"

#ifdef INPUT_TEX_FLOAT
Texture2D<float> inTexture : register(t0);
#else
Texture2D<uint> inTexture : register(t0);
#endif
RWTexture2D<float4> outTexture : register(u2);

inline float m8(const uint val)
{
    return float(val & 0xFFu);
}

inline float m10(const uint val)
{
    return float(val & 0x3FFu);
}

static const float3x3 yuv2RGB = float3x3(yuv2R.r, yuv2R.g, yuv2R.b,
                                         yuv2G.r, yuv2G.g, yuv2G.b,
                                         yuv2B.r, yuv2B.g, yuv2B.b);

inline void WriteRGB(const uint2 coord, const float3 vyu)
{
    const float3 rgb = multiply(yuv2RGB, vyu);
    outTexture[coord] = processColorProfile(float4(rgb, 1.0));
}

[numthreads(16, 16, 1)]
void YUV8In(const uint3 DTid : SV_DispatchThreadID)
{
    uint srcWidth, srcHeight;
    inTexture.GetDimensions(srcWidth, srcHeight);

    const uint word = inTexture.Load(int3(DTid.x, srcHeight - 1 - DTid.y, 0));
    static const float scale = 1.0 / 255.0;
    const float4 vy0uy1 = float4(m8(word >> 16), m8(word >> 8), m8(word), m8(word >> 24)) * scale
                        + float4(stdbias.rgb, stdbias.g);

    const uint baseX = DTid.x * 2;
    WriteRGB(uint2(baseX, DTid.y), vy0uy1.rgb);
    WriteRGB(uint2(baseX + 1, DTid.y), vy0uy1.rab);
}

[numthreads(16, 16, 1)]
void YUV10In(const uint3 DTid : SV_DispatchThreadID)
{
    uint srcWidth, srcHeight;
    inTexture.GetDimensions(srcWidth, srcHeight);
    const uint2 baseCoord = uint2(DTid.x * 4, srcHeight - 1 - DTid.y);
    const uint word0 = inTexture.Load(int3(baseCoord + uint2(0, 0), 0));
    const uint word1 = inTexture.Load(int3(baseCoord + uint2(1, 0), 0));
    const uint word2 = inTexture.Load(int3(baseCoord + uint2(2, 0), 0));
    const uint word3 = inTexture.Load(int3(baseCoord + uint2(3, 0), 0));

    static const float scale = 1.0 / 1023.0;
    const float3 vyu0 = float3(m10(word0 >> 20), m10(word0 >> 10), m10(word0)) * scale + stdbias.rgb;
    const float3 vyu1 = float3(vyu0.r, m10(word1) * scale + stdbias.g, vyu0.b);
    const float3 vyu2 = float3(m10(word2), m10(word1 >> 20), m10(word1 >> 10)) * scale + stdbias.rgb;
    const float3 vyu3 = float3(vyu2.r, m10(word2 >> 10) * scale + stdbias.g, vyu2.b);
    const float3 vyu4 = float3(m10(word3 >> 10), m10(word3), m10(word2 >> 20)) * scale + stdbias.rgb;
    const float3 vyu5 = float3(vyu4.r, m10(word3 >> 20) * scale + stdbias.g, vyu4.b);

    const uint baseX = DTid.x * 6;
    WriteRGB(uint2(baseX, DTid.y), vyu0);
    WriteRGB(uint2(baseX + 1, DTid.y), vyu1);
    WriteRGB(uint2(baseX + 2, DTid.y), vyu2);
    WriteRGB(uint2(baseX + 3, DTid.y), vyu3);
    WriteRGB(uint2(baseX + 4, DTid.y), vyu4);
    WriteRGB(uint2(baseX + 5, DTid.y), vyu5);
}

[numthreads(16, 16, 1)]
void P216In(const uint3 DTid : SV_DispatchThreadID)
{
    uint srcWidth, srcHeight;
    inTexture.GetDimensions(srcWidth, srcHeight);
    const uint flippedY = srcHeight - 1 - DTid.y;
    const uint evenX = DTid.x & ~1u;
    const float luma = inTexture.Load(int3(DTid.x, flippedY - srcHeight / 2, 0));
    const float cr = inTexture.Load(int3(evenX, flippedY, 0));
    const float cb = inTexture.Load(int3(evenX + 1, flippedY, 0));
    const float3 uyv = float3(cb, luma, cr) + stdbias.rgb;
    WriteRGB(uint2(DTid.x, DTid.y), uyv);
}

[numthreads(16, 16, 1)]
void PA16In(const uint3 DTid : SV_DispatchThreadID)
{
    uint srcWidth, srcHeight;
    inTexture.GetDimensions(srcWidth, srcHeight);
    const uint flippedY = srcHeight - 1 - DTid.y;
    const uint sectionHeight = srcHeight / 3;
    const uint evenX = DTid.x & ~1u;
    const float luma = inTexture.Load(int3(DTid.x, flippedY - sectionHeight * 2, 0));
    const float cr = inTexture.Load(int3(evenX, flippedY - sectionHeight, 0));
    const float cb = inTexture.Load(int3(evenX + 1, flippedY - sectionHeight, 0));
    const float alpha = inTexture.Load(int3(evenX, flippedY, 0));
    const float3 uyv = float3(cb, luma, cr) + stdbias.rgb;
    const float3 rgb = multiply(yuv2RGB, uyv);
    outTexture[uint2(DTid.x, DTid.y)] = processColorProfile(float4(rgb, alpha));
}
