static const float4 std601X = float4(  0.299 ,  0.587,  0.114, 0.0  );
static const float4 std601Y = float4( -0.169 , -0.331,  0.500, 0.0  );
static const float4 std601Z = float4(  0.500 , -0.419, -0.081, 0.0  );

static const float4 std601R = float4( 1.596027*0.85882394366802,1.164383*0.85882394366802, 0.000000,0.0  );
static const float4 std601G = float4(-0.812968*0.85882394366802,1.164383*0.85882394366802,-0.391762*0.85882394366802,0.0  );
static const float4 std601B = float4( 0.000000,1.164383*0.85882394366802, 2.017232*0.85882394366802,0.0  );

typedef struct
{
    float saturation;
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
    float4 blurredBackgroundColor=float4(blurredBackgroundTexture.Sample(linearSampler,screenPosition*u.uvScale+u.uvOffset));

    float4 yuvIn = vec4(dot(std601X, blurredBackgroundColor),
        dot(std601Y, blurredBackgroundColor),
        dot(std601Z, blurredBackgroundColor),
        1.0 );

    float4 yuvOut;

    yuvOut.g = yuvIn.r;
    yuvOut.r = yuvIn.b * (vars.saturation+1.0);
    yuvOut.b = yuvIn.g * (vars.saturation+1.0);
    yuvOut.a = yuvIn.a;

    float4 outColor=vec4(dot(std601R, yuvOut),
        dot(std601G, yuvOut),
        dot(std601B, yuvOut),
        1);

    outColor*=objectColor.a;

    return outColor;
}
