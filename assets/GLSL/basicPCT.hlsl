Texture2D  inputTex;

SamplerState linearSampler
{
    Filter = MIN_MAG_MIP_LINEAR;
    AddressU = Wrap;
    AddressV = Wrap;
};


// data structure : before vertex shader (mesh info)
struct vertexInfo
{
    float3 position : POSITION;
    float4 color : COLOR;
    float2 uv: TEXCOORD0;
};

// data structure : vertex shader to pixel shader
// also called interpolants because values interpolates through the triangle
// from one vertex to another
struct v2p
{
    float4 position : SV_POSITION;
    float2 uv : TEXCOORD0;
    float4 color : COLOR;
};

v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position,1.0);
    output.uv = input.uv;
    output.color = input.color;
    return output;
}


float4 pixelShader(v2p input) : SV_TARGET
{
    return inputTex.Sample(linearSampler,input.uv)*input.color;
}
