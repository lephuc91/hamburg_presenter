#include "dxShaderIncludes.h"
#include "alpha.h"

typedef struct
{
    float4 burnColor;
    float pad[3];
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    vec4 red,green,blue;
    vec2 texA,texB;

    texA=input.tex1;
    texA.x-=(1.0-u.transitionProgress);
    
    texB=input.tex1;
    texB.x-=u.transitionProgress;

    texA=mix(texB,texA,u.mix);
    red=getColor(inputTex0,texA)*u.baseAlpha;
    red*=vec4(1.,0.,0.,.33333);

    texA=input.tex1;
    texA.x+=(1.0-u.transitionProgress);

    texB=input.tex1;
    texB.x+=u.transitionProgress;

    texA=mix(texB,texA,u.mix);
    green=getColor(inputTex0,texA)*u.baseAlpha;
    green*=vec4(0.,1.,0.,.33333);

    texA=input.tex1;
    texA.y-=(1.0-u.transitionProgress);

    texB=input.tex1;
    texB.y-=u.transitionProgress;

    texA=mix(texB,texA,u.mix);
    blue=getColor(inputTex0,texA)*u.baseAlpha;
    blue*=vec4(0.,0.,1.,.33333);
    float4 outColor = red+green+blue;

#ifdef USE_MASK
    multiplyOpacity(outColor, float(inputTexMask.Sample(linearSampler, input.texMask).a));
#endif

    return outColor;
}
