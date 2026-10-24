// Copyright (c) Renewed Vision, LLC. All rights reserved.
#ifndef MetalShaderTypes_h
#define MetalShaderTypes_h

#if __METAL__ || __METAL_MACOS__ || __METAL_IOS__
#include <metal_stdlib>
using namespace metal;
#endif

#include <simd/simd.h>

typedef struct
{
    vector_float4 pos;
    packed_float2 tex1;
    packed_float2 tex2;
    packed_float2 texMask;
} txShaderVers;

typedef struct
{
    vector_float4 pos;
    packed_float2 tex1;
    packed_float2 texMask;
} fxShaderVerts;

typedef struct
{
    int transitionState;
    float transitionProgressLinear;
    float transitionProgress;
    float lastTransitionProgress;
    float transitionAlpha;
    float timer;
    float baseAlpha;
    float mix;
    packed_float2 windowSize;
    packed_float2 uvScale;
    packed_float2 uvOffset;
    matrix_float4x4 worldViewProj;
    float verticalDirectionFlip;
    float nitsScale;
} txShaderUniforms;

typedef struct
{
    int pass;
    float globalTime;
    float localTime;
    float random;
    float randomOnce;
    float blendValue;
    float nitsScale;
} fxGeneralUniforms;

#if __METAL__ || __METAL_MACOS__ || __METAL_IOS__
typedef struct
{
    float4 position [[position]];
    float2 tex1;
    float2 tex2;
    float2 texMask;
    float2 normPos;
} vertexOut;

typedef struct
{
    float4 position [[position]];
    float2 tex1;
    float2 texMask;
    float2 normPos;
    float2 texSize;
    float2 mixValue;
} fxVertexOut;

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

typedef struct
{
    float4 position [[position]];
    float2 texCoordY;   // normalized
    float2 texCoordUV;  // normalized
    float2 texCoordPS;  // pixel space
    float2 maskCoord;   // normalized
} inputVertexType;

typedef struct
{
    float4 position [[position]];
    float2 texCoord;
} pixCopyVertexOut;

typedef struct
{
    vector_float4 pos;
    packed_float2 tc;
} pixCopyVertexFormat;

constexpr sampler linearSampler(
    mip_filter::nearest,
    mag_filter::linear,
    min_filter::linear,
    s_address::clamp_to_border,
    t_address::clamp_to_border,
    border_color::transparent_black);

#define vec2 float2
#define vec3 float3
#define vec4 float4
#define mat4 float4x4
#define mat2 float2x2
#define mat3 float3x3
#define mod(x, y) ((x) - (y)*floor((x) / (y)))
#define discard discard_fragment()
#define fsTexture input.tex1

#ifdef HAS_BACKGROUND_EFFECT

#define getColor(a, b) backgroundEffect(a, b, inputTex1, inputTexMask, input.position.xy, u, subVars)

#else

#define getColor(a, b) float4(a.sample(linearSampler, b))

typedef struct
{
    float notUsed;
} subFXVars;

#endif

#endif
#endif
