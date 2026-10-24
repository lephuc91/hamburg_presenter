#include "commonMLDX.h"
#include "alpha.h"
#include "outputColorHelper.h"

Texture2D inputTex : register(t0);

SamplerState linearSampler : register(s0);

struct vertexInfo
{
    float3 position : POSITION;
    float2 uv : TEXCOORD0;
};

struct v2p
{
    float4 position : SV_POSITION;
    float2 uv : TEXCOORD0;
};

v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position, 1.0);
    output.uv = input.uv;
    return output;
}


float4 pixelShader(v2p input) : SV_TARGET
{
    float4 baseColor = inputTex.Sample(linearSampler, input.uv);
    baseColor = toOutput(baseColor);
    return baseColor;
}
