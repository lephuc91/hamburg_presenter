#include "dxShaderIncludes.h"
#include "alpha.h"

typedef struct
{
    float fadeLeft;
    float fadeRight;
    float fadeTop;
    float fadeBottom;
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

typedef struct
{
    float4 position : SV_POSITION;
    float2 normPos : POSITION;
    float2 tex1 : TEXCOORD0;
    float2 texMask : TEXCOORD2;
    float2 texSize : TEXCOORD3;
    float2 mixValue : TEXCOORD4;
} fsVertexOut;

fsVertexOut vertexShader(fxShaderVerts input)
{
    fsVertexOut output;
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.position.y*=-1.0;
    output.tex1 = input.tex1;
    output.texMask = input.texMask;
    output.mixValue=(output.position.xy+float2(1.0,1.0))*.5;
    return output;
}


float4 pixelShader(fsVertexOut input) : SV_TARGET
{
    float4 outColor = float4(inputTex0.sample(linearSampler,input.tex1));
    float2 t=input.mixValue;
    float blend = smoothstep(0.0, vars.fadeLeft, t.x) * (1 - smoothstep(vars.fadeRight, 1.0, t.x)) * smoothstep(0.0, vars.fadeTop, t.y) * (1 - smoothstep(vars.fadeBottom, 1.0, t.y));
#ifdef USE_MASK
    blend *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, blend);
    return outColor;
}
