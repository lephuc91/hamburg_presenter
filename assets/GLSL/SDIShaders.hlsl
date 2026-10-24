#include "commonMLDX.h"
#include "alpha.h"
#include "outputColorHelper.h"

Texture2D<float4> inTexture1 : register(t0);
Texture2D<float4> inTexture2 : register(t1);
#ifdef TO_YUV
RWTexture2D<uint> outTexture : register(u2);
#else
RWTexture2D<float4> outTexture : register(u2);
#endif

inline float4 getInputPixel(const uint2 coord)
{
    const int3 coord3 = int3(coord, 0);
#ifdef INTERLACED
    return ((coord.y & 1u) == 0u) ? inTexture1.Load(coord3) : inTexture2.Load(coord3);
#else
    return inTexture1.Load(coord3);
#endif
}

inline uint to8Bit(const float val)
{
    return uint(round(val * 255.0)) & 0xFF;
}

inline uint to10Bit(const float val)
{
    return uint(round(val * 1023.0)) & 0x3FF;
}

#ifdef TO_YUV

[numthreads(16, 16, 1)]
void BGRATo2vuyKernel8(const uint3 DTid : SV_DispatchThreadID)
{
    const uint2 gid = DTid.xy;
    const uint2 baseCoord = gid * uint2(2, 1);

    // Read and convert first + second pixel
    const float3 yuv0 = toOutput(getInputPixel(baseCoord)).rgb;
    const float3 yuv1 = toOutput(getInputPixel(baseCoord + uint2(1, 0))).rgb;

    // Convert to 8-bit (average chroma)
    const uint y0 = to8Bit(yuv0.r);
    const uint y1 = to8Bit(yuv1.r);
    const uint cb = to8Bit(0.5f * (yuv0.g + yuv1.g));
    const uint cr = to8Bit(0.5f * (yuv0.b + yuv1.b));

    // Pack into 32-bit word + write output
    outTexture[gid] = cb | (y0 << 8) | (cr << 16) | (y1 << 24);
}

[numthreads(16, 16, 1)]
void BGRATo2vuyKernel10(const uint3 DTid : SV_DispatchThreadID)
{
    const uint2 gid = DTid.xy;
    const uint2 baseCoord = gid * uint2(6, 1);

    // Read 6 RGB pixels and convert
    const float3 yuv0 = toOutput(getInputPixel(baseCoord + uint2(0, 0))).rgb;
    const float3 yuv1 = toOutput(getInputPixel(baseCoord + uint2(1, 0))).rgb;
    const float3 yuv2 = toOutput(getInputPixel(baseCoord + uint2(2, 0))).rgb;
    const float3 yuv3 = toOutput(getInputPixel(baseCoord + uint2(3, 0))).rgb;
    const float3 yuv4 = toOutput(getInputPixel(baseCoord + uint2(4, 0))).rgb;
    const float3 yuv5 = toOutput(getInputPixel(baseCoord + uint2(5, 0))).rgb;

    // Convert luma to 10-bit
    const uint y0 = to10Bit(yuv0.r);
    const uint y1 = to10Bit(yuv1.r);
    const uint y2 = to10Bit(yuv2.r);
    const uint y3 = to10Bit(yuv3.r);
    const uint y4 = to10Bit(yuv4.r);
    const uint y5 = to10Bit(yuv5.r);

    // Average chroma and convert to 10-bit
    const uint cb0 = to10Bit(0.5 * (yuv0.g + yuv1.g));
    const uint cr0 = to10Bit(0.5 * (yuv0.b + yuv1.b));
    const uint cb1 = to10Bit(0.5 * (yuv2.g + yuv3.g));
    const uint cr1 = to10Bit(0.5 * (yuv2.b + yuv3.b));
    const uint cb2 = to10Bit(0.5 * (yuv4.g + yuv5.g));
    const uint cr2 = to10Bit(0.5 * (yuv4.b + yuv5.b));

    // Pack values into 32-bit words + write output
    const uint baseX = gid.x * 4;
    outTexture[uint2(baseX, gid.y)] = cb0 | (y0 << 10) | (cr0 << 20);
    outTexture[uint2(baseX + 1, gid.y)] = y1 | (cb1 << 10) | (y2 << 20);
    outTexture[uint2(baseX + 2, gid.y)] = cr1 | (y3 << 10) | (cb2 << 20);
    outTexture[uint2(baseX + 3, gid.y)] = y4 | (cr2 << 10) | (y5 << 20);
}

inline uint ByteReverse(uint x)
{
    return (x >> 24) | ((x >> 8) & 0xff00) | ((x << 8) & 0xff0000) | (x << 24);
}

[numthreads(16, 16, 1)]
void BGRATo2vuyaKernel10(uint3 DTid : SV_DispatchThreadID)
{
    const uint2 bgraBlockGid = DTid.xy * uint2(2, 1);
    float cb[2], cr[2];
    uint y[2];
    uint a[2];

    [unroll]
    for (int i = 0; i < 2; ++i)
    {
        float4 rgb = toOutput(getInputPixel(bgraBlockGid + uint2(i, 0)));
        y[i] = to10Bit(rgb.r);
        a[i] = to10Bit(rgb.a);

        int pair = i / 2;
        if (i % 2 == 0)
        {
            cb[pair] = rgb.g;
            cr[pair] = rgb.b;
        }
        else
        {
            cb[pair] = (cb[pair] + rgb.g) * 0.5;
            cr[pair] = (cr[pair] + rgb.b) * 0.5;
        }
    }

    const uint cb_uint = to10Bit(cb[0]);
    const uint cr_uint = to10Bit(cr[0]);

    // Pack into 32-bit words
    uint word0 = y[0] | (cb_uint << 10) | (a[0] << 20);
    uint word1 = y[1] | (cr_uint << 10) | (a[1] << 20);

    uint baseX = DTid.x * 2;
    outTexture[uint2(baseX + 0, DTid.y)] = ByteReverse(word0);
    outTexture[uint2(baseX + 1, DTid.y)] = ByteReverse(word1);

    //// more performant but not a sure thing, switch to this after testing on DeckLink 4K mini
    //uint word0 = (a[0]>>4) | ((a[0]&0xf)<<12) | ((cb_uint>>6)<<8) | ((y[0]>>8)<<16) | ((cb_uint&0x3f)<<18) | ((y[0]&0xff)<<24);
    //uint word1 = (a[1]>>4) | ((a[1]&0xf)<<12) | ((cr_uint>>6)<<8) | ((y[1]>>8)<<16) | ((cr_uint&0x3f)<<18) | ((y[1]&0xff)<<24);

    //outTexture[uint2(baseX + 0, DTid.y)] = word0;
    //outTexture[uint2(baseX + 1, DTid.y)] = word1;
}

#else  // !TO_YUV

[numthreads(16, 16, 1)]
void BRGACopy(const uint3 DTid : SV_DispatchThreadID)
{
    const uint2 gid = DTid.xy;
    const float4 rgba = toOutput(getInputPixel(gid));
    outTexture[gid] = rgba.argb;
}

#endif  // !TO_YUV
