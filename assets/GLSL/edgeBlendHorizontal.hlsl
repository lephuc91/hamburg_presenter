texture2D  inputTex : register(t0);

SamplerState linearSampler : register(s0);


cbuffer uniforms : register( b0 )
{
    float intensity;
    float type;
    float blendValue;
    float offset;
    float scale;
    float start;
    float blackLevel;
    float invGamma;
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
    float progress : POSITION;
};

v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position,1.0)*float4(1,-1,1,1);
    output.uv = input.uv;
    output.progress=start-(output.position.x-offset)*scale;
    return output;
}


float4 pixelShader(v2p input) : SV_TARGET
{
    float width,height;
    inputTex.GetDimensions(width,height);
    float2 texCoord=input.uv/float2(width,height);
    float4 outColor=inputTex.Sample(linearSampler,texCoord);

    float scale=min(1.0,blendValue*(1.0-pow(1.0-input.progress,type)*intensity));
    scale=pow(scale,invGamma);
    outColor.rgb*=float3(scale,scale,scale);

    return outColor;
}


