#include "dxEffectIncludes.h"
#include "alpha.h"

#ifdef LINEAR_16
static const float4 toXYZ_R = float4(0.4124, 0.3576, 0.1805, 0.0);
static const float4 toXYZ_G = float4(0.2126, 0.7152, 0.0722, 0.0);
static const float4 toXYZ_B = float4(0.0193, 0.1192, 0.9505, 0.0);
#endif

typedef struct
{
    float4 darkColor;
    float4 brightColor;
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
    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    vec4 texel = getColor(inputTex, fsTexture);
#ifdef PRE_MULT
    divideAlpha(texel);
#endif

#ifdef LINEAR_16
    float4 darkColor = float4(dot(toXYZ_R, vars.darkColor), dot(toXYZ_G, vars.darkColor), dot(toXYZ_B, vars.darkColor), 1.0);
    float4 brightColor = float4(dot(toXYZ_R, vars.brightColor), dot(toXYZ_G, vars.brightColor), dot(toXYZ_B, vars.brightColor), 1.0);

    float gray = dot(texel.rgb  / u.nitsScale, vec3(0.355, 0.658, 0.004));

    // linear interp between darkColor and brightColor using gray scale
    float4 outColor;
    outColor.rgb=mix(darkColor.rgb*u.nitsScale,brightColor.rgb*u.nitsScale,gray);
#else
    // Convert to grayscale using NTSC conversion weights
    float gray = dot(texel.rgb, vec3(0.299, 0.587, 0.114));

    // linear interp between darkColor and brightColor using gray scale
    float4 outColor;
    outColor.rgb = mix(vars.darkColor.rgb*u.nitsScale, vars.brightColor.rgb*u.nitsScale, gray);
#endif
    outColor.a=texel.a;

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
