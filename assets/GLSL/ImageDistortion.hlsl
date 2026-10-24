#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float scale;
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


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    float x=input.normPos.x;
    float y=-input.normPos.y;

    //Then transform to polar coordinates
    float ratio = min(input.texSize.x/input.texSize.y, input.texSize.y/input.texSize.x);
    float r = ratio*sqrt(x*x + y*y);
    float phi = atan2(y,x);//equivalent to atan2

    float t = 90.0;//mod( float( time ), 30000.0 ) / 1000.0; //0 - 30 seconds
    float fac =  abs( sin( t ) )*vars.scale + .125;//+1.5;/// 2.0 + 1.5;
    r = pow( r, fac );//fac );//magnifier

    //Map from polar to x, y
    x = r*cos( phi );
    y = r*sin( phi );
    vec2 uv;
    uv.x=x;
    uv.y=y;
    uv+=vec2(1.0,1.0);
    uv*=vec2(.5,.5f);
//    uv=clamp(uv,vec2(0.0,0.0),vec2(1.0,1.0));
    float4 color = getColor(inputTex, fsTexture);
    float4 outColor = getColor(inputTex, uv);

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    mixColor(outColor, color, outColor, blendValue);
    return outColor;
}
