#include "dxShaderIncludes.h"
#include "alpha.h"

typedef struct
{
    float shadowEnable;
    float pad[3];
} fxVars;


cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = float4(input.position,1);
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.normPos=input.position.xy*vec2(.5,.5f)+vec2(.5,.5);
    return output;
}

#define getBackgroundColor(a, b) a.Sample(blurSampler, b)

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float4 blur = getBackgroundColor(inputTex0, input.tex1);
    float4 org=getColor(inputTex1,input.tex2);

    float shadowWidth = 0.05;
    float edgeDistX = abs(input.tex2.x - clamp(input.tex2.x, 0.0, 1.0));
    float edgeDistY = abs(input.tex2.y - clamp(input.tex2.y, 0.0, 1.0));
    float edgeDist = max(edgeDistX, edgeDistY);
    float shadowStrength = smoothstep(0.0, shadowWidth, edgeDist);

    float minShadowStrength = 0.55; // we don't want it completely dark on edges, so limit to 55%
    float maxShadowStrength = 0.85; // we want to darken the entire blurred area a bit as well

    float remappedShadowStrength = minShadowStrength + (maxShadowStrength - minShadowStrength) * shadowStrength;

    float3 shadowBlur=blur.rgb*remappedShadowStrength;

    blur.rgb=mix(blur.rgb,shadowBlur.rgb,vars.shadowEnable);

    float4 outColor;
    blendColorSrcOverDst(outColor, org, blur);

#ifdef USE_MASK
    float alpha = float(inputTexMask.sample(linearSampler, input.texMask).a);
    multiplyOpacity(outColor, alpha);
#endif

    return outColor;
}
