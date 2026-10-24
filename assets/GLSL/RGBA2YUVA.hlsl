#include "commonMLDX.h"
#include "alpha.h"
#include "outputColorHelper.h"

Texture2D  inputTex : register(t0);

SamplerState linearSampler : register(s0);

static const float4 std709X = float4(  0.183,   0.614,  0.062, 0.0  );
static const float4 std709Y = float4( -0.101,  -0.338,  0.439, 0.0  );
static const float4 std709Z = float4(  0.439,  -0.399, -0.040, 0.0  );



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

v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position,1.0);
    output.uv = input.uv;
    return output;
}


float4 pixelShader(v2p input) : SV_TARGET
{
    float width,height;
    inputTex.GetDimensions(width,height);

    float4 texColor0=toOutput(inputTex.Sample(linearSampler,input.uv/float2(width,height)).bgra);

    float4 yuv0 = float4(dot(std709X, texColor0)+0.0625,
        dot(std709Y, texColor0)+0.5,
        dot(std709Z, texColor0)+0.5,
        texColor0.a);

    float4 outColor=float4(yuv0.a,yuv0.r,yuv0.g,yuv0.b);// Convert (and horizontal downsample) RGB to YUV2 using HD gamma corrected values (from Decklink SDK)

    return outColor;
}
