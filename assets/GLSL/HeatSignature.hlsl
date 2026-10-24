#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float none;
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
    vec4 color = getColor(inputTex, fsTexture);
#ifdef PRE_MULT
    divideAlpha(color);
#endif

#ifdef LINEAR_16
    float gray = dot(color.rgb / u.nitsScale, vec3(0.355, 0.658, 0.004));
#else
    float gray = dot(color.rgb, vec3(0.299, 0.587, 0.114));
#endif

    // compute the heat signature value

    vec4 heatSig = vec4( 0.0, 0.0, 0.0, 0.0 );

    if ( gray < 0.25 )
    {
        // black to blue
        gray *= 4.0;

        heatSig.r = 0.0;
        heatSig.g = 0.0;
        heatSig.b = gray;
    }
    else if ( gray < 0.5 )
    {
        // blue to green
        gray -= 0.25;
        gray *= 4.0;

        heatSig.r = 0.0;
        heatSig.g = gray;
        heatSig.b = 1.0 - gray;
    }
    else if ( gray < 0.75 )
    {
        // green to yellow
        gray -= 0.5;
        gray *= 4.0;

        heatSig.r = gray;
        heatSig.g = 1.0;
        heatSig.b = 0.0;
    }
    else
    {
        // yellow to red
        gray -= 0.75;
        gray *= 4.0;

        heatSig.r = 1.0;
        heatSig.g = 1.0 - gray;
        heatSig.b = 0.0;
    }
    heatSig.rgb *= u.nitsScale;

    heatSig.a = color.a;

    float4 outColor = heatSig;


    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    outColor.rgb = lerp(color.rgb, outColor.rgb, blendValue);
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}
