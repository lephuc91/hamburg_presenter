#include "dxEffectIncludes.h"


// Fragment shader for doing downsampling

typedef struct
{
    float downsampleStep;
    float textureStep;
    float pad[2];
} fxVars;


cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}


typedef struct
{
    float3 position : POSITION;
    float2 tex1 : TEXCOORD0;
    float2 tex2 : TEXCOORD1;
} fsVertexIn;

typedef struct
{
    float4 position : SV_POSITION;
    float2 tex0 : TEXCOORD0;
    float2 tex1 : TEXCOORD1;
    float2 tex2 : TEXCOORD2;
    float2 tex3 : TEXCOORD3;
} fsVertexOut;


fsVertexOut vertexShader(fsVertexIn input)
{
    fsVertexOut output;
    output.position = float4(input.position,1);

    float2 pixelOffset=vec2(1.0,1.0)/u.texSize;

    output.tex0=input.tex1+pixelOffset*float2(0.,0.)*vars.downsampleStep;
    output.tex1=input.tex1+pixelOffset*float2(1.,0.)*vars.downsampleStep;
    output.tex2=input.tex1+pixelOffset*float2(1.,1.)*vars.downsampleStep;
    output.tex3=input.tex1+pixelOffset*float2(0.,1.)*vars.downsampleStep;

    return output;
}

#define getTexture(a,b) a.Sample(blurSampler,b)

float4 pixelShader(fsVertexOut input) : SV_TARGET
{
    float4 outColor=getTexture(inputTex,input.tex0);
    outColor+=getTexture(inputTex,input.tex1);
    outColor+=getTexture(inputTex,input.tex2);
    outColor+=getTexture(inputTex,input.tex3);
    outColor*=vec4(1.0/4.0,1.0/4.0,1.0/4.0,1.0/4.0);
 
    return outColor;
}
