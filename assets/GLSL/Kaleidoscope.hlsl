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

#define getTexture(a,b) a.Sample(mirrorSampler,b)

float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    vec4 color = getTexture(inputTex, fsTexture);
    float fsTime=(vars.speed+0.01)*u.localTime*10.0;

    vec2 p=input.normPos-vec2(vars.centerX*2.,vars.centerY*2.);

    float r = length(p);
    float a = atan2(p.y, p.x);
    float tau = 2.0 * 3.1416;
    float sides=float(vars.numSides);

    a = mod(a, tau/sides);
    a = abs(a - tau/sides/2.0);

    vec2 uv;
    uv.x = sides*a/3.1416;
    uv.y = sin(sides*r+fsTime) + sides/10.0*cos(fsTime+7.0*a);
    uv.x = 0.5*(uv.x+1.0);
    uv.y = 0.5*(uv.y+1.0);

    float4 outColor = getTexture(inputTex, uv);
    float w = .5+.5*(sin(fsTime+sides*r) + sides/10.0*cos(fsTime+sides*a));
    multiplyOpacity(outColor, w);

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue*=getTexture(inputTexMask,input.texMask).a;
#endif
    mixColor(outColor, color, outColor, blendValue);

    return outColor;
}
