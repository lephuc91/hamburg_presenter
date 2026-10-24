#include "dxShaderIncludes.h"
#include "alpha.h"
#include "fadeHelper.h"

vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = mul(u.worldViewProj, float4(input.position, 1.0));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.normPos = input.position.xy * 0.5 + 0.5;
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    vec4 texColorA = getColor(inputTex0, input.tex1);
    vec4 texColorB = getColor(inputTex1, input.tex2);
    vec4 outColor;
    fadeWhiteAB(outColor, texColorA, texColorB, u.transitionProgress);
    float alpha = u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);
    return outColor;
}
