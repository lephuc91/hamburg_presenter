#include "dxShaderIncludes.h"

cbuffer uniforms : register( b0 )
{
    float alpha;
    float curLevel;
    float peakLevel;
    float sdrScale;
    bool hdrFF;
    float pad[3];
};

// data structure : before vertex shader (mesh info)
struct vertexInfo
{
    float3 position : POSITION;
    float2 uv: TEXCOORD0;
};

// data structure : vertex shader to pixel shader
// also called interpolants because values interpolates through the triangle
// from one vertex to another
struct v2p
{
    float4 position : SV_POSITION;
    float2 uv : TEXCOORD0;
};

static const float4 toXYZ_R = float4(0.4124, 0.3576, 0.1805, 0.0);
static const float4 toXYZ_G = float4(0.2126, 0.7152, 0.0722, 0.0);
static const float4 toXYZ_B = float4(0.0193, 0.1192, 0.9505, 0.0);

float4 toLinear2(float4 c)
{
    float3 low = c.rgb / 12.92;
    float3 high = pow((c.rgb + 0.055) / 1.055, float3(2.4, 2.4, 2.4));
    float3 linearRGB = mix(low, high, step(0.04045, c.rgb));
    return float4(linearRGB, c.a);
}

v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position,1.0)*float4(1,-1,1,1);
    output.uv=input.uv;
    return output;
}

float4 pixelShader(v2p input) : SV_TARGET
{
    float4 sourceColor = inputTex0.Sample(linearSampler, input.uv);
    float4 outColor = sourceColor;
    if (hdrFF)
    {
        float4 linearColor = toLinear2(sourceColor);
        outColor = float4(dot(toXYZ_R, linearColor), dot(toXYZ_G, linearColor), dot(toXYZ_B, linearColor), linearColor.a);
        outColor.rgb *= sdrScale;
    }
    if((1.0-input.uv.y)>curLevel)
    {
        float diff=abs((1.0-input.uv.y)-peakLevel);
        if(diff>.005)
        {
            outColor.a=alpha;
        }
    }
    return outColor;
}
