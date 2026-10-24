#include "dxShaderIncludes.h"
#include "alpha.h"

vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float4 outColor;
    float4 texColor0 = inputTex0.Sample(linearSampler, input.tex1);
    float4 texColor1 = inputTex1.Sample(linearSampler, input.tex2);
    mixColor(outColor, texColor1, texColor0, u.transitionProgressLinear);

#ifdef USE_MASK
    multiplyOpacity(outColor, inputTexMask.Sample(linearSampler, input.texMask).a);
#endif

    return outColor;
}
