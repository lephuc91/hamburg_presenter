#include "commonMLDX.h"
#include "alpha.h"
#include "outputColorHelper.h"

Texture2D  inputTex0 : register(t0);

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


float4 pixelShader(v2p input) : SV_TARGET
{
    float width,height;
    inputTex0.GetDimensions(width,height);

    float2 texSize=float2(width,height);

    //this shader is for 420 and we are gathering 2 UV samples and interleaving them
    //that would mean that we need to sample 8 pixels to do that, but we can take advantage of bilinear filtering
    //provided by the GPU to do that for us.  We offset the sample coordinate by half pixel right and half line down
    //that'll let us get the average of a 2x2 pixel area with one read
    //we're reading twice because we're writing out 2 UV samples
    float2 texCoord=input.texCoord1+float2(.5,.5);

    float4 texColor0 = toOutput(float4(inputTex0.Sample(linearSampler,texCoord/texSize)));
    texCoord.x+=1.0;
    float4 texColor1 = toOutput(float4(inputTex0.Sample(linearSampler,texCoord/texSize)));

    float4 yuv0 = float4(dot(std709X, texColor0)+0.0625,
                         dot(std709Y, texColor0)+0.5,
                         dot(std709Z, texColor0)+0.5,
                         1.0 );

    float4 yuv1 = float4(dot(std709X, texColor1)+0.0625,
                         dot(std709Y, texColor1)+0.5,
                         dot(std709Z, texColor1)+0.5,
                         1.0 );



    float4 outColor;
    outColor=float4(yuv0.g,yuv0.b,yuv1.g,yuv1.b);
    return outColor;
}
