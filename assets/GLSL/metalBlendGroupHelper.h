// Copyright (c) Renewed Vision, LLC. All rights reserved.

#if __METAL__ || __METAL_MACOS__ || __METAL_IOS__
#include <metal_stdlib>
using namespace metal;
#endif

#include <simd/simd.h>

typedef struct
{
    vector_float4 pos;
    packed_float2 tex[16];
} bgVertexIn;

typedef struct
{
    float opacity0;
    float opacity1;
    float opacity2;
    float opacity3;
    float opacity4;
    float opacity5;
    float opacity6;
    float opacity7;
    float opacity8;
    float opacity9;
    float opacity10;
    float opacity11;
    float opacity12;
    float opacity13;
    float opacity14;
    float opacity15;
    vector_float4 screenColor;
} bgShaderVars;

#if __METAL__ || __METAL_MACOS__ || __METAL_IOS__

#define vec2 float2
#define vec3 float3
#define vec4 float4
#define mat4 float4x4
#define mat2 float2x2
#define mat3 float3x3
#define getColor(a, b) float4(a.sample(linearSampler, b))
#define mod(x, y) ((x) - (y)*floor((x) / (y)))
#define discard discard_fragment()
#define screenColor vars.screenColor
#define opacity0 vars.opacity0
#define opacity1 vars.opacity1
#define opacity2 vars.opacity2
#define opacity3 vars.opacity3
#define opacity4 vars.opacity4
#define opacity5 vars.opacity5
#define opacity6 vars.opacity6
#define opacity7 vars.opacity7
#define opacity8 vars.opacity8
#define opacity9 vars.opacity9
#define opacity10 vars.opacity10
#define opacity11 vars.opacity11
#define opacity12 vars.opacity12
#define opacity13 vars.opacity13
#define opacity14 vars.opacity14
#define opacity15 vars.opacity15

constexpr sampler linearSampler(
    mip_filter::nearest,
    mag_filter::linear,
    min_filter::linear,
    s_address::clamp_to_border,
    t_address::clamp_to_border,
    border_color::transparent_black);

float rand(vec2 co)
{
    float a = 12.9898;
    float b = 78.233;
    float c = 43758.5453;
    float dt = dot(co.xy, vec2(a, b));
    float sn = mod(dt, 3.14);
    return fract(sin(sn) * c);
}

vec3 RGBToHSL(vec3 color)
{
    vec3 hsl;  // init to 0 to avoid warnings ? (and reverse if + remove first part)

    float fmin = min(min(color.r, color.g), color.b);  // Min. value of RGB
    float fmax = max(max(color.r, color.g), color.b);  // Max. value of RGB
    float delta = fmax - fmin;                         // Delta RGB value

    hsl.z = (fmax + fmin) / 2.0;  // Luminance

    if (delta == 0.0)  // This is a gray, no chroma...
    {
        hsl.x = 0.0;  // Hue
        hsl.y = 0.0;  // Saturation
    }
    else  // Chromatic data...
    {
        if (hsl.z < 0.5)
            hsl.y = delta / (fmax + fmin);  // Saturation
        else
            hsl.y = delta / (2.0 - fmax - fmin);  // Saturation

        float deltaR = (((fmax - color.r) / 6.0) + (delta / 2.0)) / delta;
        float deltaG = (((fmax - color.g) / 6.0) + (delta / 2.0)) / delta;
        float deltaB = (((fmax - color.b) / 6.0) + (delta / 2.0)) / delta;

        if (color.r == fmax)
            hsl.x = deltaB - deltaG;  // Hue
        else if (color.g == fmax)
            hsl.x = (1.0 / 3.0) + deltaR - deltaB;  // Hue
        else if (color.b == fmax)
            hsl.x = (2.0 / 3.0) + deltaG - deltaR;  // Hue

        if (hsl.x < 0.0)
            hsl.x += 1.0;  // Hue
        else if (hsl.x > 1.0)
            hsl.x -= 1.0;  // Hue
    }

    return hsl;
}

float HueToRGB(float f1, float f2, float hue)
{
    if (hue < 0.0)
        hue += 1.0;
    else if (hue > 1.0)
        hue -= 1.0;
    float res;
    if ((6.0 * hue) < 1.0)
        res = f1 + (f2 - f1) * 6.0 * hue;
    else if ((2.0 * hue) < 1.0)
        res = f2;
    else if ((3.0 * hue) < 2.0)
        res = f1 + (f2 - f1) * ((2.0 / 3.0) - hue) * 6.0;
    else
        res = f1;
    return res;
}

vec3 HSLToRGB(vec3 hsl)
{
    vec3 rgb;

    if (hsl.y == 0.0)
        rgb = vec3(hsl.z);  // Luminance
    else
    {
        float f2;

        if (hsl.z < 0.5)
            f2 = hsl.z * (1.0 + hsl.y);
        else
            f2 = (hsl.z + hsl.y) - (hsl.y * hsl.z);

        float f1 = 2.0 * hsl.z - f2;

        rgb.r = HueToRGB(f1, f2, hsl.x + (1.0 / 3.0));
        rgb.g = HueToRGB(f1, f2, hsl.x);
        rgb.b = HueToRGB(f1, f2, hsl.x - (1.0 / 3.0));
    }

    return rgb;
}

float4 alphaBlend(float4 dst, float4 src, float layerOpacity, float alpha)
{
    return mix(dst, src, layerOpacity * alpha);
}

#endif
