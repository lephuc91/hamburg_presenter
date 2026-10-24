#include "dxShaderIncludes.h"
#include "alpha.h"

vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = mul(u.worldViewProj, float4(input.position, 1));
    if (u.transitionState == 0)
    {
        output.position.z = .10;
    }
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    return output;
}

static const float softEdgeMaxWidth = 0.09;
static const float edgeRamp = 0.3;

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float4 outColor = float4(0,0,0,0);
    float4 colorB;
    float4 colorA;
    float alpha = u.baseAlpha;
    if (u.transitionState == 0)
    {
        colorA = getColor(inputTex0, input.tex1);
        colorB = float4(0,0,0,0);
    }
    else
    {
        colorB = getColor(inputTex0, input.tex1);
        colorA = float4(0,0,0,0);
    }

    //expanding old texture and splitting in middle
    float2 tadj = input.tex1;
    float open = u.transitionProgressLinear * 0.5;
    float middle = 0.5;
    if (input.tex1.x < middle)
    {
        tadj.x += open;
        if (tadj.x > middle)
        {
            outColor = colorA;
        }
        else
        {
            outColor = colorB;
            float distanceFromMiddle = abs(0.5 - tadj.x);
            float softEdgeWidth = min(softEdgeMaxWidth, u.transitionProgressLinear * edgeRamp);
            if (distanceFromMiddle < softEdgeWidth)
            {
                float blend = smoothstep(0.0, 0.7, distanceFromMiddle / softEdgeWidth);
                mixColor(outColor, colorA, colorB, blend);
            }
        }
    }
    else
    {
        tadj.x -= open;
        if (tadj.x < middle)
        {
            outColor = colorA;
        }
        else
        {
            outColor = colorB;
            float distanceFromMiddle = abs(0.5 - tadj.x);
            float softEdgeWidth = min(softEdgeMaxWidth, u.transitionProgressLinear * edgeRamp);
            if (distanceFromMiddle < softEdgeWidth)
            {
                float blend = smoothstep(0.0, 0.7, distanceFromMiddle / softEdgeWidth);
                mixColor(outColor, colorA, colorB, blend);
            }
        }
    }

#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);
    return outColor;
}
