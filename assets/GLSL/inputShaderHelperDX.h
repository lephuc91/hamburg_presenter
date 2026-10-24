Texture2D inputTex0 : register(t0);
Texture2D inputTex1 : register(t1);
Texture2D inputTex2 : register(t2);
Texture2D inputTex3 : register(t3);
Texture2D maskTex : register(t4);

SamplerState clearBorderSampler : register(s0);
SamplerState nearestSampler : register(s1);

#define textureFetchNearest(a, b) a.Sample(nearestSampler, b)
#define fract(a) frac(a)

#define vec4 float4
#define vec3 float3
#define vec2 float2
#define mix lerp

// data structure : before vertex shader (mesh info)
struct vertexInfo
{
    float3 position : POSITION;
    float2 texCoordY : TEXCOORD0;
};

// data structure : vertex shader to pixel shader
// also called interpolants because values interpolates through the triangle
// from one vertex to another
struct v2p
{
    float4 position : SV_POSITION;
    float2 texCoordY : TEXCOORD0;
    float2 texCoordUV : TEXCOORD1;
};

struct planarUniforms
{
    float4 endColor;
    float hScale;
    float vScale;
    float endOpacity;
    float pad;
};

cbuffer uniformBuffer : register(b0)
{
    planarUniforms uniforms;
}
