#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float speed;
    int numSides;
    float centerX;
    float centerY;
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

fxVertexOut vertexShader(fxShaderVerts input)
{
    fxVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy;
    output.tex1 = input.tex1;
    output.texMask = input.texMask;
    output.texSize = u.texSize;
    return output;
}

bool InBound(float x, float a, float b)
{
    return (x > a && x<=b);
}

#define getTexture(a,b) a.Sample(mirrorSampler,b)

float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    float fsTime=fract(vars.speed*u.localTime*0.3);

    vec2 p=input.normPos-vec2(vars.centerX*2.,vars.centerY*2.);

    float r = length(p);
    float a = atan2(p.y, p.x);
    float tau = 2.0 * 3.1416;
    float sides=float(vars.numSides);
    a = mod(a, tau/sides);
    a = abs(a - tau/sides/2.0);

    vec2 uv;

    uv.x = r *cos(a) + 0.5+fsTime;
    uv.y = r *sin(a) + 0.5+fsTime;

//    uv = 0.5*uv*fsTextureSize;
    uv*=.5;
//
    uv.x = InBound(uv.x, 0., 1.0)?uv.x:fsTexture.x;
    uv.y = InBound(uv.y, 0., 1.0)?uv.y:fsTexture.y;

    vec4 texel=getTexture(inputTex,fsTexture);
    float4 outColor =  getTexture(inputTex,uv);

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    mixColor(outColor, texel, outColor, blendValue);
    return outColor;
}
