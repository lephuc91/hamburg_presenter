#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float speed;
} fxVars;


cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

fxVertexOut vertexShader(fxShaderVerts input)
{
    fxVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy * vec2(.5, .5f);//+vec2(.5, .5);
    output.tex1 = input.tex1;
    output.texMask = input.texMask;
    output.texSize = u.texSize;
    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    float fsTime=u.localTime*vars.speed;

    float cLength = length(input.normPos.xy);

    vec2 uv=input.tex1+(input.normPos.xy/cLength)*cos(cLength*12.0-fsTime*4.0)*0.03;

    vec4 texel=getColor(inputTex,fsTexture);
    float4 outColor=getColor(inputTex,uv);

    float blendValue = u.blendValue;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    mixColor(outColor, texel, outColor, blendValue);

    return outColor;
}
