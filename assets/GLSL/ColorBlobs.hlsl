#include "dxEffectIncludes.h"

typedef struct
{
    float blendValue;
    float speed;
} fxVars;


float makePoint(float x,float y,float fx,float fy,float sx,float sy,float t)
{
    float xx=x+sin(t*fx)*sx;
    float yy=y+cos(t*fy)*sy;
    return 1.0/sqrt(xx*xx+yy*yy);
}

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

fxVertexOut vertexShader(fxShaderVerts input)
{
    fxVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy * vec2(.5,.5f) + vec2(.5,.5);
    output.tex1 = input.tex1;
    output.texMask = input.texMask;
    output.texSize = u.texSize;
    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    vec2 p=input.tex1*2.0-vec2(1.,1.);

    float time=u.localTime*vars.speed;

    p=p*.70;

    float x=p.x;
    float y=p.y;

    float a=
    makePoint(x,y,3.3,2.9,0.3,0.3,time);
    a=a+makePoint(x,y,1.9,2.0,0.4,0.4,time);
    a=a+makePoint(x,y,0.8,0.7,0.4,0.5,time);
    a=a+makePoint(x,y,2.3,0.1,0.6,0.3,time);
    a=a+makePoint(x,y,0.8,1.7,0.5,0.4,time);
    a=a+makePoint(x,y,0.3,1.0,0.4,0.4,time);
    a=a+makePoint(x,y,1.4,1.7,0.4,0.5,time);
    a=a+makePoint(x,y,1.3,2.1,0.6,0.3,time);
    a=a+makePoint(x,y,1.8,1.7,0.5,0.4,time);

    float b=
    makePoint(x,y,1.2,1.9,0.3,0.3,time);
    b=b+makePoint(x,y,0.7,2.7,0.4,0.4,time);
    b=b+makePoint(x,y,1.4,0.6,0.4,0.5,time);
    b=b+makePoint(x,y,2.6,0.4,0.6,0.3,time);
    b=b+makePoint(x,y,0.7,1.4,0.5,0.4,time);
    b=b+makePoint(x,y,0.7,1.7,0.4,0.4,time);
    b=b+makePoint(x,y,0.8,0.5,0.4,0.5,time);
    b=b+makePoint(x,y,1.4,0.9,0.6,0.3,time);
    b=b+makePoint(x,y,0.7,1.3,0.5,0.4,time);

    float c=
    makePoint(x,y,3.7,0.3,0.3,0.3,time);
    c=c+makePoint(x,y,1.9,1.3,0.4,0.4,time);
    c=c+makePoint(x,y,0.8,0.9,0.4,0.5,time);
    c=c+makePoint(x,y,1.2,1.7,0.6,0.3,time);
    c=c+makePoint(x,y,0.3,0.6,0.5,0.4,time);
    c=c+makePoint(x,y,0.3,0.3,0.4,0.4,time);
    c=c+makePoint(x,y,1.4,0.8,0.4,0.5,time);
    c=c+makePoint(x,y,0.2,0.6,0.6,0.3,time);
    c=c+makePoint(x,y,1.3,0.5,0.5,0.4,time);

    vec3 d=(vec3(a,b,c)-16.0)/32.0;
    d=clamp(vec3(0.,0.,0.),vec3(1.0,1.0,1.0),d);

    float4 outColor = getColor(inputTex, fsTexture);

    float combinedBlendValue=u.blendValue*vars.blendValue*u.nitsScale;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    d*=combinedBlendValue;
    outColor.rgb = (vec3(1.0, 1.0, 1.0) - ((vec3(1.0, 1.0, 1.0) - outColor.rgb) * (vec3(1.0, 1.0, 1.0) - d)));

    return outColor;
}
