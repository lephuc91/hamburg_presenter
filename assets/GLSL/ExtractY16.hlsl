#include "commonMLDX.h"
#include "alpha.h"
#include "outputColorHelper.h"

Texture2D  inputTex0 : register(t0);

SamplerState nearestSampler : register(s0);

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
    float2 texCoord1 : TEXCOORD0;
    float2 texCoord2 : TEXCOORD1;
};


v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position,1.0);
    output.texCoord1 = input.uv;
    input.uv.x+=1.0;
    output.texCoord2=input.uv;
    return output;
}


float2 ScaleAndSplit(float value)
{
    float2 ret;

    int tmp=int(value*1023.0);
    ret.x=float(tmp&0xff)/255.0;
    ret.y=float(tmp>>8)/255.0;
    return ret;
}

float4 pixelShader(v2p input) : SV_TARGET
{
    float width,height;
    inputTex0.GetDimensions(width,height);

    float2 texSize=float2(width,height);

    float2 texCoord=input.texCoord1+float2(.5,.5);

    float4 texColor0 = toOutput(float4(inputTex0.Sample(nearestSampler,texCoord/texSize)));
    texCoord.x+=1.0;
    float4 texColor1 = toOutput(float4(inputTex0.Sample(nearestSampler,texCoord/texSize)));


    float4 yuv0 = float4(dot(std709X, texColor0)+0.0625,
                         dot(std709Y, texColor0)+0.5,
                         dot(std709Z, texColor0)+0.5,
                         1.0 );

    float4 yuv1 = float4(dot(std709X, texColor1)+0.0625,
                         dot(std709Y, texColor1)+0.5,
                         dot(std709Z, texColor1)+0.5,
                         1.0 );
    
    float2 y0=ScaleAndSplit(yuv0.r);
    float2 y1=ScaleAndSplit(yuv1.r);

    float4 outColor=float4(y0.x,y0.y,y1.x,y1.y);

    return outColor;
}
