#include "commonMLDX.h"
#include "alpha.h"
#include "outputColorHelper.h"

SamplerState linearSampler : register(s0);
Texture2D inputTex : register(t0);

struct vsPT
{
    float3 pos : POSITION;
    float2 uv: TEXCOORD0;
};

struct fsPT
{
    float4 pos : SV_POSITION;
    float2 tc0 : TEXCOORD0;
#ifndef HQ
    float2 tc1 : TEXCOORD1;
    float2 tc2 : TEXCOORD2;
    float2 tc3 : TEXCOORD3;
#endif
};

fsPT vertexShader(vsPT input)
{
    fsPT output;
    output.pos = float4(input.pos, 1.0);
    output.pos.y *= -1.0;
#ifdef HQ
    output.tc0 = input.uv;
#else
    output.tc0 = input.uv + float2(-0.5, 0.5);
    output.tc1 = input.uv + float2(0.5, 0.5);
    output.tc2 = input.uv + float2(0.5, -0.5);
    output.tc3 = input.uv + float2(-0.5, -0.5);
#endif
    return output;
}


float4 pixelShader(fsPT input) : SV_TARGET
{
    float width, height;
    inputTex.GetDimensions(width, height);
    float2 texSize = float2(width, height);
    float4 outColor = inputTex.Sample(linearSampler, input.tc0 / texSize);
#ifndef HQ
    outColor += inputTex.Sample(linearSampler, input.tc1 / texSize);
    outColor += inputTex.Sample(linearSampler, input.tc2 / texSize);
    outColor += inputTex.Sample(linearSampler, input.tc3 / texSize);
    outColor *= 0.25;
#endif
    outColor = toOutput(outColor);
    return outColor;
}

