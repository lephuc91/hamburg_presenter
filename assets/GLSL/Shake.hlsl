#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float frequency;
    float intensity;
} fxVars;


cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}


float hash(float2 p)
{
    p  = 50.0*fract( p*0.3183099 + float2(0.71,0.113));
    return -1.0+2.0*fract( p.x*p.y*(p.x+p.y) );
}

float noise(float2 p )
{
    float2 i = floor( p );
    float2 f = fract( p );

    float2 u = f*f*(3.0-2.0*f);

    return mix( mix( hash( i + float2(0.0,0.0) ),
                    hash( i + float2(1.0,0.0) ), u.x),
               mix( hash( i + float2(0.0,1.0) ),
                   hash( i + float2(1.0,1.0) ), u.x), u.y);
}


fxVertexOut vertexShader(fxShaderVerts input)
{
    fxVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy * vec2(.5,.5f) + vec2(.5,.5);

    vec2 tmp = input.tex1; //0,0 -> 1,1
    output.normPos=tmp;
    tmp-=.5;    //-.5,-.5 -> .5,.5
    tmp*=2.;    //-1,-1 -> 1,1
    tmp/=(vars.intensity+1.);
    float dx=u.globalTime*4.*(vars.frequency+.1);

    tmp.x+=noise(float2(dx,-dx))*(vars.intensity*.5);
    tmp.y-=noise(float2(-dx,dx))*(vars.intensity*.5);

    tmp*=.5;
    tmp+=.5;
    output.tex1 = tmp;

    output.texMask = input.texMask;
    output.texSize = u.texSize;
    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    float4 outColor = getColor(inputTex, fsTexture);
    float4 texel = getColor(inputTex, input.normPos);

    float blendValue = u.blendValue;
#ifdef USE_MASK
    blendValue *= getColor(inputTexMask, input.texMask).a;
#endif
    mixColor(outColor, texel, outColor, blendValue);

    return outColor;
}
