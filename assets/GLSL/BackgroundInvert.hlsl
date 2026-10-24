
typedef struct
{
    float notUsed;
} subFXVars;

cbuffer variableBuffer : register(b3)
{
    subFXVars subVars;
}

float4 backgroundEffect(Texture2D objectTexture,
                        float2 objectTextureCoordinates,
                        Texture2D blurredBackgroundTexture,
                        Texture2D backgroundTexture,
                        float2 screenPosition,
                        const txShaderUniforms u,
                        const subFXVars vars)
{
    float4 objectColor=float4(objectTexture.Sample(linearSampler,objectTextureCoordinates));

    float4 backgroundColor=float4(backgroundTexture.Sample(linearSampler,screenPosition*u.uvScale+u.uvOffset));
    float4 invertedBackgroundColor=float4(1.0,1.0,1.0,1.0);
    invertedBackgroundColor.rgb-=backgroundColor.rgb;

    float4 outColor=mix(invertedBackgroundColor,backgroundColor,1.0-objectColor.a);

    outColor*=objectColor.a;
    return outColor;
}
