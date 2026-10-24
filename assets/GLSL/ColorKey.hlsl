#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float4 srcColor;
    float tolerance;
} fxVars;

#ifdef LINEAR_16
static const float4 toXYZ_R = float4(0.4124, 0.3576, 0.1805, 0.0);
static const float4 toXYZ_G = float4(0.2126, 0.7152, 0.0722, 0.0);
static const float4 toXYZ_B = float4(0.0193, 0.1192, 0.9505, 0.0);
#endif

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
    vec4 texColor = getColor(inputTex, fsTexture);
#ifdef PRE_MULT
    divideAlpha(texColor);
#endif
#ifdef LINEAR_16
    float4 srcColor = float4(dot(toXYZ_R, vars.srcColor), dot(toXYZ_G, vars.srcColor), dot(toXYZ_B, vars.srcColor), 1.0);
#else
    float4 srcColor = vars.srcColor;
#endif
    float4 outColor=texColor;
    vec3 diff = abs(texColor.rgb / u.nitsScale - srcColor.rgb);
    if(diff.r<vars.tolerance)
    {
        if(diff.g<vars.tolerance)
        {
            if(diff.b<vars.tolerance)
            {
                outColor.a *= 1.0 - u.blendValue;
            }
        }
    }

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    outColor.rgb = mix(texColor.rgb, outColor.rgb, blendValue);
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}
