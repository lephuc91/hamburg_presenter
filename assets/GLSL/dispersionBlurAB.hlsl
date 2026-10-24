#include "dxShaderIncludes.h"
#include "alpha.h"

typedef struct
{
    float size;
    float angle;
    float pad[2];
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

#define QUALITY 8


static const float GOLDEN_ANGLE = 2.399963229728653; // PI * (3.0 - sqrt(5.0))

vec4 blur(Texture2D tpipe,vec2 c,float radius)
{
    vec4 sum = vec4(0,0,0,0);
    float q = float(QUALITY);
    // Using a "spiral" to propagate points.
    for (int i=0; i<QUALITY; ++i)
    {
        float fi = float(i);
        float a = fi * GOLDEN_ANGLE;
        float r = sqrt(fi / q) * radius;
        vec2 p = c + r * vec2(cos(a), sin(a));
        sum += getColor(tpipe, p);
    }
    return sum / q;
}

float rand(vec2 co)
{
    float a = 12.9898;
    float b = 78.233;
    float c = 43758.5453;
    float dt= dot(co.xy ,vec2(a,b));
    float sn= mod(dt,3.14);
    return fract(sin(sn) * c);
}


vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.normPos=input.position.xy*vec2(.5,.5f)+vec2(.5,.5);
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{

    float fsMix=1.0;
    if(u.transitionProgress<=.5)
        fsMix=u.transitionProgress*2.;
    else
        fsMix=(1.-u.transitionProgress)*2.;

    vec4 color1=blur(inputTex0,input.tex1,fsMix*vars.size);
    vec4 color2=blur(inputTex1,input.tex2,fsMix*vars.size);
    float4 outColor;
    mixColor(outColor, color2, color1, u.transitionProgressLinear);

#ifdef USE_MASK
    multiplyOpacity(outColor, float(inputTexMask.Sample(linearSampler, input.texMask).a));
#endif

    return outColor;
}
