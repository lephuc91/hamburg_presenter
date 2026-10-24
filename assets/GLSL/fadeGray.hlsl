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

vec4 grayscale (vec4 color)
{
    float gray=0.2126*color.r + 0.7152*color.g + 0.0722*color.b;
    return vec4(gray,gray,gray,color.a);
}


vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.normPos=input.position.xy*vec2(.5,.5f)+vec2(.5,.5);
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float4 texColor = getColor(inputTex0, input.tex1);

#ifndef PRE_MULT
    multiplyAlpha(texColor);
#endif

    float4 colorA = mix(float4(0,0,0,0), texColor, u.mix);
    float4 colorB = mix(texColor, float4(0,0,0,0), u.mix);
    float4 color1 = mix(grayscale(colorA), colorA, smoothstep(0.6, 1.0, u.transitionProgress));
    float4 color2 = mix(grayscale(colorB), colorB, smoothstep(0.6, 1.0, 1.0 - u.transitionProgress));
    float4 outColor = mix(color2, color1, u.transitionProgress);

// #ifdef OPACITY_MASK
//     float maxOpacity = texColor.a;
//     outColor = min(outColor, float4(maxOpacity, maxOpacity, maxOpacity, maxOpacity));
// #endif

    float alpha = u.baseAlpha;

#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif

    multiplyOpacityPremultiplied(outColor, alpha);

#ifndef PRE_MULT
    divideAlpha(outColor);
#endif

    return outColor;
}
