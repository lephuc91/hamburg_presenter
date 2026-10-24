#include "dxShaderIncludes.h"


cbuffer uniforms : register( b0 )
{
    float offset;
    float pad[3];
};

// data structure : before vertex shader (mesh info)
struct vertexInfo
{
    float4 position : POSITION;
};

// data structure : vertex shader to pixel shader
// also called interpolants because values interpolates through the triangle
// from one vertex to another
struct v2p
{
    float4 position : SV_POSITION;
};


v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = input.position; //float4(input.position,1.0)*float4(1,-1,1,1);
    output.position.x+=offset;
    return output;
}

float4 pixelShader(v2p input) : SV_TARGET
{
    float4 outColor= float4(0,1,0,1);

    return outColor;
}
