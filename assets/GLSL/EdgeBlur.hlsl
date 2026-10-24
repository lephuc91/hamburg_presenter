#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float blurAmount;
    float blurRadius;
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}


typedef struct
{
    float4 position : SV_POSITION;
    float2 normPos : POSITION;
    float2 tex1 : TEXCOORD0;
    float2 texMask : TEXCOORD2;
    float2 texSize : TEXCOORD3;
    float floatParam0 : PSIZE0;
    float floatParam1 : PSIZE1;
    float floatParam2 : PSIZE2;

    float2 texCoords0 : TEXCOORD4;
    float2 texCoords1 : TEXCOORD5;
    float2 texCoords2 : TEXCOORD6;
    float2 texCoords3 : TEXCOORD7;
    float2 texCoords4 : TEXCOORD8;
    float2 texCoords5 : TEXCOORD9;
    float2 texCoords6 : TEXCOORD10;
    float2 texCoords7 : TEXCOORD11;
    float2 texCoords8 : TEXCOORD12;
    float2 texCoords9 : TEXCOORD13;
    float2 texCoords10 : TEXCOORD14;
    float2 texCoords11 : TEXCOORD15;
    float2 texCoords12 : TEXCOORD16;
    float2 texCoords13 : TEXCOORD17;
    float2 texCoords14 : TEXCOORD18;
} fsVertexOut;


fsVertexOut vertexShader(fxShaderVerts input)
{
    fsVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy;// * vec2(.5,.5f) + vec2(.5,.5);
    output.tex1 = input.tex1;
    output.texMask = input.texMask;
    output.texSize = u.texSize;
    float fsScale=vars.blurAmount*3.0;
    if(fsScale==0.0)
        fsScale=0.1;

    float2 direction;
    float blurPass=u.renderPass;
    if(blurPass>1)
        blurPass-=2;
    if(blurPass==0)
    {
        direction=vec2((fsScale+fsScale*.5)/output.texSize.x,0.0);
    }
    else
    {
        direction=vec2(0.0,(fsScale+fsScale*.5)/output.texSize.y);
    }

    output.texCoords0 = input.tex1 + vec2(-7.0,-7.0)*direction;
    output.texCoords1 = input.tex1 + vec2(-6.0,-6.0)*direction;
    output.texCoords2 = input.tex1 + vec2(-5.0,-5.0)*direction;
    output.texCoords3 = input.tex1 + vec2(-4.0,-4.0)*direction;
    output.texCoords4 = input.tex1 + vec2(-3.0,-3.0)*direction;
    output.texCoords5 = input.tex1 + vec2(-2.0,-2.0)*direction;
    output.texCoords6 = input.tex1 + vec2(-1.0,-1.0)*direction;
    output.texCoords7 = input.tex1 + vec2( 1.0, 1.0)*direction;
    output.texCoords8 = input.tex1 + vec2( 2.0, 2.0)*direction;
    output.texCoords9 = input.tex1 + vec2( 3.0, 3.0)*direction;
    output.texCoords10 = input.tex1 + vec2( 4.0, 4.0)*direction;
    output.texCoords11 = input.tex1 + vec2( 5.0, 5.0)*direction;
    output.texCoords12 = input.tex1 + vec2( 6.0, 6.0)*direction;
    output.texCoords13 = input.tex1 + vec2( 7.0, 7.0)*direction;
    output.texCoords14 = input.tex1;
    return output;
}

#define getTexture(a,b) a.Sample(blurSampler,b)


float4 pixelShader(fsVertexOut input) : SV_TARGET
{
    vec2 center=vec2(.5,.5);
    float dist = length(input.tex1 - center);

    vec4 texel = getTexture(inputTex, fsTexture);
    float4 outColor=vec4(0.0,0.0,0.0,0.0);

    outColor += getTexture(inputTex, input.texCoords0);
    outColor += getTexture(inputTex, input.texCoords1);
    outColor += getTexture(inputTex, input.texCoords2);
    outColor += getTexture(inputTex, input.texCoords3);
    outColor += getTexture(inputTex, input.texCoords4);
    outColor += getTexture(inputTex, input.texCoords5);
    outColor += getTexture(inputTex, input.texCoords6);

    vec4 srcColor = getColor(inputTex, input.texCoords14);
    outColor+=srcColor;

    outColor += getTexture(inputTex, input.texCoords7);
    outColor += getTexture(inputTex, input.texCoords8);
    outColor += getTexture(inputTex, input.texCoords9);
    outColor += getTexture(inputTex, input.texCoords10);
    outColor += getTexture(inputTex, input.texCoords11);
    outColor += getTexture(inputTex, input.texCoords12);
    outColor += getTexture(inputTex, input.texCoords13);

    outColor*=vec4(1.0/15.0,1.0/15.0,1.0/15.0,1.0/15.0);

    float blend=(dist*vars.blurRadius)*4.;
    blend=min(1.0,blend);
    mixColor(outColor, srcColor, outColor, blend);

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    mixColor(outColor, texel, outColor, blendValue);
    return outColor;
}
