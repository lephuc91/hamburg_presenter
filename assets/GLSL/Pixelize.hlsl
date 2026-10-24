#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float pixelSize;
} fxVars;



cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

fxVertexOut vertexShader(fxShaderVerts input)
{
    fxVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy*vec2(.5,-.5f)+vec2(.5,.5);
    output.tex1 = input.tex1*u.texSize;
    output.texMask = input.texMask;
    output.texSize = u.texSize;
    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    vec2 fsTextureStep=input.texSize*.05;
    fsTextureStep*=vars.pixelSize*max(0.01,u.blendValue);
    fsTextureStep.y=fsTextureStep.x;

    vec4 texel = getColor(inputTex, fsTexture/input.texSize);
    vec2 tmp=(fsTexture+fsTextureStep*.5)/fsTextureStep;
    int2 grad=int2(tmp);
    vec2 pixTexture=vec2(grad);
    pixTexture*=fsTextureStep;

    float4 outColor = getColor(inputTex, pixTexture/input.texSize);

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    mixColor(outColor, texel, outColor, blendValue);

    return outColor;
}
