#define vec2 float2
#define vec3 float3
#define vec4 float4
#define mix(a, b, c) lerp(a, b, c)
#define fract frac
#define mod(x, y) (x - y * floor(x / y))
#define mat4 float4x4
#define mat2 float2x2

SamplerState linearSampler : register(s0);
SamplerState nearestSampler : register(s1);
SamplerState blurSampler : register(s2);
SamplerState mirrorSampler : register(s3);

#define textureFetchNearest(a, b) a.Sample(nearestSampler, b)
#define fsTexture input.tex1
#define getColor(a, b) a.Sample(linearSampler, b)

Texture2D inputTex : register(t0);
Texture2D inputTexMask : register(t1);

typedef struct
{
    float3 position : POSITION;
    float2 tex1 : TEXCOORD0;
    float2 texMask : TEXCOORD1;
} fxShaderVerts;

typedef struct
{
    float4 position : SV_POSITION;
    float2 normPos : POSITION;
    float2 tex1 : TEXCOORD0;
    float2 texMask : TEXCOORD2;
    float2 texSize : TEXCOORD3;
    float floatParam0 : PSIZE0;
    float floatParam1 : PSIZE1;
    float floatParam2 : PSIZE2;

} fxVertexOut;

struct fxGeneralUniforms
{
    int renderPass;
    float globalTime;
    float localTime;
    float random;
    float randomOnce;
    float blendValue;
    float2 texSize;
    float nitsScale;
};

cbuffer transitionBuffer : register(b1)
{
    fxGeneralUniforms u;
}
