
// data structure : before vertex shader (mesh info)
struct vertexInfo
{
    float3 position : POSITION;
    float4 color : COLOR;
};

// data structure : vertex shader to pixel shader
// also called interpolants because values interpolates through the triangle
// from one vertex to another
struct v2p
{
    float4 position : SV_POSITION;
    float4 color : COLOR;
};

v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position,1.0);
    output.color = input.color;
    return output;
}


float4 pixelShader(v2p input) : SV_TARGET
{
   return input.color;
}
