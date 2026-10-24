Texture2D  inputTex : register(t0);
Texture2D  inputTexMask : register(t1);
SamplerState linearSampler : register(s0);

// data structure : before vertex shader (mesh info)
struct vertexInfo
{
    float3 position : POSITION;
    float2 uv: TEXCOORD0;
    float2 uv2: TEXCOORD1;
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
    output.uv=input.uv;
    output.uv2=input.uv2;
    return output;
}

float4 pixelShader(v2p input) : SV_TARGET
{
    float4 outColor=inputTex.Sample(linearSampler,input.uv);
    // Currently this shader is only used in ProPresenter with premultiplied alpha.
    outColor*=inputTexMask.Sample(linearSampler,input.uv2).a;
    return outColor;

    //// useful for debuging mask positioning, mask corners are colored:
    //// top left blue, bottom left green, bottom right yellow, top right red
    //// texture outside mask is still visible but 0.5 brightness
    //float4 outColor = inputTex.Sample(linearSampler, input.uv);
    //float4 maskColor = inputTexMask.Sample(linearSampler, input.uv2);
    //float red = input.uv2.x;
    //float green = input.uv2.y;
    //float blue = 0.5 * (1.0 - red + 1.0 - green);
    //outColor *= (1.0 - maskColor.a) * 0.5 + float4(red, green, blue, 1.0) * maskColor.a;
    //return outColor;
}
