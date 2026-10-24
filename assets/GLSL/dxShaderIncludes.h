#define vec2 float2
#define vec3 float3
#define vec4 float4
#define fract frac
#define mix(a, b, c) lerp(a, b, c)
#define sample(a, b) Sample(a, b)
#define mod(x, y) (x - y * floor(x / y))
#define mat4 float4x4

SamplerState linearSampler : register(s0);
SamplerState nearestSampler : register(s1);
SamplerState blurSampler : register(s2);

#define textureFetchNearest(a, b) a.Sample(nearestSampler, b)

#ifdef HAS_BACKGROUND_EFFECT

#define getColor(a, b) backgroundEffect(a, b, inputTex1, inputTexMask, input.position.xy, u, subVars)

#else

#define getColor(a, b) a.Sample(linearSampler, b)

#endif

Texture2D inputTex0 : register(t0);
Texture2D inputTex1 : register(t1);
Texture2D inputTexMask : register(t2);

typedef struct
{
    float3 position : POSITION;
    float2 tex1 : TEXCOORD0;
    float2 texMask : TEXCOORD1;
    float2 tex2 : TEXCOORD2;
} txShaderVerts;

typedef struct
{
    float3 position : POSITION;
    float2 tex1 : TEXCOORD0;
    float2 texMask : TEXCOORD1;
} fxShaderVerts;

typedef struct
{
    float4 position : SV_POSITION;
    float2 tex1 : TEXCOORD0;
    float2 tex2 : TEXCOORD1;
    float2 texMask : TEXCOORD2;
    float2 normPos : POSITION;
} vertexOut;

struct txShaderUniforms
{
    int transitionState;
    float transitionProgressLinear;
    float transitionProgress;
    float lastTransitionProgress;

    float transitionAlpha;
    float timer;
    float baseAlpha;
    float mix;

    float4x4 worldViewProj;
    float2 windowSize;
    float2 uvScale;
    float2 uvOffset;

    float saturation;
    float verticalDirectionFlip;
    float nitsScale;
    float pad[3];
};

cbuffer transitionBuffer : register(b0)
{
    txShaderUniforms u;
}
