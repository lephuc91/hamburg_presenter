#include "dxShaderIncludes.h"
#include "alpha.h"

typedef struct
{
    int direction;
    float pad[3];
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

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


vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;

    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;

    vec4 deltaTrans=deltaTransTable[vars.direction];
    vec4 transOffset=transOffsetTable[vars.direction];

    mat4 translation=mat4(
                          1.0, 0.0, 0.0, 0.00,
                          0.0, 1.0, 0.0, 0.00,
                          0.0, 0.0, 1.0, 0.00,
                          0.0, 0.0, 0.0, 1.00);

    vec4 tmpPos=mul(u.worldViewProj,float4(input.position,1));

    if(u.transitionState==0)
    {
        transOffset-=deltaTrans*u.transitionProgress;

        translation[0][3]+=transOffset.x;
        translation[1][3]+=transOffset.y;
        translation[2][3]+=transOffset.z;
    }
    output.position=mul(translation,tmpPos);

    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float4 outColor = getColor(inputTex0, input.tex1);
    float alpha = u.transitionState == 0 ? 1.0 : 1.0 - u.transitionProgress;
    alpha *= u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);
    return outColor;
}
