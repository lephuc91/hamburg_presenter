
// Generic vertex function and first part of fragment function
// Included by ssInputShadersML::LoadShader()

#if __METAL__ || __METAL_MACOS__ || __METAL_IOS__
#include <metal_stdlib>
using namespace metal;
#endif

#include <simd/simd.h>

#define vec2 float2
#define vec3 float3
#define vec4 float4
#define textureFetchNearest(a, b) float4(a.sample(nearestSampler, b))

typedef struct
{
    float hScale;
    float vScale;
    vector_float4 endColor;
    float endOpacity;
} planarUniforms;

typedef struct
{
    vector_float4 pos;
    packed_float2 tc;
} planarVerts;

typedef struct
{
    vector_float4 pos;
    packed_float2 tc;
    packed_float2 maskTC;
} planarVertsMask;

#if __METAL__ || __METAL_MACOS__ || __METAL_IOS__

typedef struct
{
    float4 position [[position]];
    float2 texCoordY;   // normalized
    float2 texCoordUV;  // normalized
    float2 texCoordPS;  // pixel space
    float2 maskCoord;   // normalized
    float2 texCoordV;   // normalize and hold V if different from UV
} inputVertexType;

constexpr sampler nearestSampler(
    mip_filter::nearest,
    mag_filter::nearest,
    min_filter::nearest,
    address::clamp_to_border,
    border_color::transparent_black);

#endif

#ifdef USE_MASK
vertex inputVertexType vertexFunc(
    uint vertexID [[vertex_id]],
    const device planarVertsMask *in [[buffer(0)]],
    constant planarUniforms &uniforms [[buffer(1)]],
    texture2d<half> inputTex0 [[texture(0)]],
    texture2d<half> inputTex1 [[texture(1)]],
    texture2d<half> inputTex2 [[texture(2)]],
    texture2d<half> inputTex3 [[texture(3)]],
    texture2d<half> maskTex [[texture(4)]])
{
    inputVertexType out;

    out.position = in[vertexID].pos;

    out.texCoordY = in[vertexID].tc / float2(inputTex0.get_width(), inputTex0.get_height());
    out.texCoordUV = in[vertexID].tc / float2(inputTex1.get_width(), inputTex1.get_height());
    out.texCoordUV *= float2(uniforms.hScale, uniforms.vScale);
    out.texCoordPS = in[vertexID].tc;
    out.maskCoord = in[vertexID].maskTC / float2(maskTex.get_width(), maskTex.get_height());

    return out;
}
#else

vertex inputVertexType vertexFunc(
    uint vertexID [[vertex_id]],
    const device planarVerts *in [[buffer(0)]],
    constant planarUniforms &uniforms [[buffer(1)]],
    texture2d<half> inputTex0 [[texture(0)]],
    texture2d<half> inputTex1 [[texture(1)]])
{
    inputVertexType out;

    out.position = in[vertexID].pos;

    out.texCoordY = in[vertexID].tc / float2(inputTex0.get_width(), inputTex0.get_height());
    out.texCoordUV = in[vertexID].tc / float2(inputTex1.get_width(), inputTex1.get_height());
    out.texCoordUV *= float2(uniforms.hScale, uniforms.vScale);
    out.texCoordPS = in[vertexID].tc;

    return out;
}
#endif
