#include "dxShaderIncludes.h"
#include "alpha.h"

static const vec4 deltaTransTable[9] = {
    vec4(-2.,2.,0.,.0),
    vec4( 0.,2.,0.,.0),
    vec4( 2.,2.,0.,.0),
    vec4(-2.,0.,0.0,.0),
    vec4( 0.,0.,0.0,.0),
    vec4( 2.,0.,0.0,.0),
    vec4(-2.,-2.,0.,.0),
    vec4( 0.,-2.,0.,.0),
    vec4( 2.,-2.,0.,.0)
};

static const vec4 transOffsetTable[9] = {
    vec4(-2.,2.,0.0,.0),
    vec4( 0.,2.,0.0,.0),
    vec4( 2.,2.,0.0,.0),
    vec4(-2.,0.,0.0,.0),
    vec4( 0.,0.,0.0,.0),
    vec4( 2.,0.,0.0,.0),
    vec4(-2.,-2.,0.,.0),
    vec4( 0.,-2.,0.,.0),
    vec4( 2.,-2.,0.,.0)
};

typedef struct
{
    int direction;
    float pad[3];
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}


vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;


    vec4 deltaTrans=deltaTransTable[vars.direction];
    vec4 transOffsetIn=transOffsetTable[vars.direction];
    vec4 transOffsetOut=vec4(0.,0.,0.0,.0);

    mat4 translation=mat4(
                          1.0, 0.0, 0.0, 0.00,
                          0.0, 1.0, 0.0, 0.00,
                          0.0, 0.0, 1.0, 0.00,
                          0.0, 0.0, 0.0, 1.00);


    vec4 tmpPos=mul(u.worldViewProj,float4(input.position,1));
    if(u.transitionState==0)
    {
        transOffsetIn-=deltaTrans*u.transitionProgress;

        translation[0][3]+=transOffsetIn.x;
        translation[1][3]+=transOffsetIn.y;
        translation[2][3]+=transOffsetIn.z;
    }
    else if(u.transitionState==2)
    {
        transOffsetOut-=deltaTrans*u.transitionProgress;

        translation[0][3]+=transOffsetOut.x;
        translation[1][3]+=transOffsetOut.y;
        translation[2][3]+=transOffsetOut.z;
    }
    output.position=mul(translation,tmpPos);

    return output;
}


float4 pixelShader(vertexOut input) : SV_TARGET
{
    float4 outColor = getColor(inputTex0, input.tex1);
    float alpha = u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);
    return outColor;
}
