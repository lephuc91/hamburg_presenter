#include "dxEffectIncludes.h"
#include "alpha.h"

#ifdef LINEAR_16
static const float4 toXYZ_R = float4(0.4124, 0.3576, 0.1805, 0.0);
static const float4 toXYZ_G = float4(0.2126, 0.7152, 0.0722, 0.0);
static const float4 toXYZ_B = float4(0.0193, 0.1192, 0.9505, 0.0);
#endif

typedef struct
{
    float frequency;
    float strobeLength;
    float strobeBlend;
    float randomness;
    float4 strobeColor;
} fxVars;

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

    float strobe=abs(cos(u.globalTime*vars.frequency*31.41592653589793));
    float strobeRandom=floor((vars.frequency+1.0)*u.random);

    strobe=mix(strobe,strobeRandom,vars.randomness);
    if(strobe>(1.0-vars.strobeLength))
        output.floatParam0=strobe;
    else
        output.floatParam0=0.0;

    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    vec4 texel = getColor(inputTex, fsTexture);
#ifdef PRE_MULT
    divideAlpha(texel);
#endif
#ifdef LINEAR_16
    float4 strobeColor = float4(dot(toXYZ_R, vars.strobeColor), dot(toXYZ_G, vars.strobeColor), dot(toXYZ_B, vars.strobeColor), 1.0);
#else
    float4 strobeColor = vars.strobeColor;
#endif

    float4 outColor = vec4(mix(texel.rgb, strobeColor.rgb*u.nitsScale, input.floatParam0*vars.strobeBlend), texel.a);
    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    outColor.rgb=mix(texel.rgb,outColor.rgb,blendValue);
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}
