#include "commonMLDX.h"
#include "alpha.h"
#include "outputColorHelper.h"

Texture2D  inputTexEven: register(t1);
Texture2D  inputTexOdd: register(t0);

SamplerState clearBorderSampler : register(s0);
SamplerState nearestSampler : register(s1);

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
    float2 uv2 : TEXCOORD1;
};

v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position,1.0);
    output.uv = input.uv;
    output.uv2 = input.uv + float2(1.0,0.0);
    return output;
}


float4 pixelShader(v2p input) : SV_TARGET
{
    float4 texColor0;
    float4 texColor1;
    float4 texColor01;
    float4 texColor11;
    float4 yuv0;
    float4 yuv1;
    float4 outColor;

    float width,height;
    inputTexOdd.GetDimensions(width,height);

    texColor0 = inputTexOdd.Sample(nearestSampler,input.uv/float2(width,height));
    texColor1 = inputTexOdd.Sample(nearestSampler,input.uv2/float2(width,height));
    texColor01 = inputTexEven.Sample(nearestSampler,input.uv/float2(width,height));
    texColor11 = inputTexEven.Sample(nearestSampler,input.uv2/float2(width,height));

    float isOddLine=floor(frac(input.uv.y * 0.5) * 2.0);

    texColor0=lerp(texColor01,texColor0,isOddLine);
    texColor1=lerp(texColor11,texColor1,isOddLine);

    texColor0 = toOutput(texColor0);
    texColor1 = toOutput(texColor1);

    yuv0 = float4(dot(std709X, texColor0)+0.0625,
        dot(std709Y, texColor0)+0.5,
        dot(std709Z, texColor0)+0.5,
        1.0 );

    yuv1 = float4(dot(std709X, texColor1)+0.0625,
        dot(std709Y, texColor1)+0.5,
        dot(std709Z, texColor1)+0.5,
        1.0 );

    outColor.a = yuv1.r;
    outColor.b = (yuv0.b+yuv1.b)*.5;
    outColor.r = (yuv0.g+yuv1.g)*.5;
    outColor.g = yuv0.r;
    return outColor;
}

