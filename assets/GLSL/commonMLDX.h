#ifdef __METAL__
using namespace metal;
#define _gconstexpr constexpr constant
#define _constexpr constexpr
#else  // HLSL
#define _gconstexpr static const
#define _constexpr static const
#define fract frac
#define mix lerp
#define sample(a, b) Sample(a, b)
#define select(a, b, c) c ? b : a
#endif  // __METAL__

#define vec2 float2
#define vec3 float3
#define vec4 float4
#define mat2 float2x2
#define mat3 float3x3
#define mat4 float4x4

#ifndef mod
#define mod(x, y) (x - y * floor(x / y))
#endif

float avoidZero(float v)
{
    return v < 0 ? min(v, -1e-6) : max(v, 1e-6);
}

float2 avoidZero(float2 v)
{
    return float2(avoidZero(v.x), avoidZero(v.y));
}

float3 avoidZero(float3 v)
{
    return float3(avoidZero(v.x), avoidZero(v.y), avoidZero(v.z));
}

float4 avoidZero(float4 v)
{
    return float4(avoidZero(v.x), avoidZero(v.y), avoidZero(v.z), avoidZero(v.w));
}

#define safeDivide(a, b) (a / avoidZero(b))

inline float3 multiply(float3x3 m, float3 v)
{
    return float3(dot(m[0], v), dot(m[1], v), dot(m[2], v));
}
