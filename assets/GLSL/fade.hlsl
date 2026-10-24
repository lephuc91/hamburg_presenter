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

typedef struct
{
    float4 position: SV_POSITION;
    float2 tex1: TEXCOORD0;
    float2 tex2: TEXCOORD1;
    float2 texMask: TEXCOORD2;
    float2 normPos: POSITION0;
    float mixValue: POSITION1;
} vertexOut2;


vertexOut2 vertexShader(txShaderVerts input)
{
    vertexOut2 output;
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    if(u.transitionState!=2)
    {
        if(u.transitionProgressLinear<=.5)
        {
            output.mixValue=0.;
        }
        else
        {
            output.mixValue=(u.transitionProgressLinear-.5f)*2.;
        }
    }
    else
    {
        if(u.transitionProgressLinear<=.5)
        {
            output.mixValue=(.5-u.transitionProgressLinear)*2.;
        }
        else
        {
            output.mixValue=0.;
        }
    }
    return output;
}

float4 pixelShader(vertexOut2 input) : SV_TARGET
{
    float4 outColor = getColor(inputTex0, input.tex1);
    float alpha = input.mixValue * u.baseAlpha;

#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif

    multiplyOpacity(outColor, alpha);
    return outColor;
}
