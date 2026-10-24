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

static const float4 deltaTransTable[9] = {
    vec4(-2.,2.,8.,.0),
    vec4(0.,2.,8.,.0),
    vec4(2.,2.,8.,.0),
    vec4(-2.,0.,8.,.0),
    vec4(0.,0.,8.,.0),
    vec4(2.,0.,8.,.0),
    vec4(-2.,-2.,8.,.0),
    vec4(0.,-2.,8.,.0),
    vec4(2.,-2.,8.,.0)
};

static const vec4 transOffsetTable[9] = {
    vec4(-1.,1.,4.0,.0),
    vec4(0.,1.,4.0,.0),
    vec4(1.,1.,4.0,.0),
    vec4(-1.,0.,4.0,.0),
    vec4(0.,0.,4.0,.0),
    vec4(1.,0.,4.0,.0),
    vec4(-1.,-1.,4.0,.0),
    vec4(0.,-1.,4.0,.0),
    vec4(1.,-1.,4.0,.0)
};


vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;

    vec4 deltaTrans=deltaTransTable[vars.direction];
    vec4 transOffset=transOffsetTable[vars.direction];

    mat4 projection = mat4(
        2.4140,0.0000,0.0000,0.0000,
        0.0000,2.4140,0.0000,0.0000,
        0.0000,0.0000,-1.020,-.4870,
        0.0000,0.0000,-1.000,0.0000);
    mat4 translation=mat4(
        1.0, 0.0, 0.0, 0.00,
        0.0, 1.0, 0.0, 0.00,
        0.0, 0.0, 1.0,-2.414,
        0.0, 0.0, 0.0, 1.00);

    vec4 tmpPos=mul(u.worldViewProj,float4(input.position,1));
    vec4 worldPos=tmpPos;

    float progress=.5;
    if(u.transitionState==0)
        progress=u.transitionProgress*.5;
    else if(u.transitionState==2)
        progress=u.transitionProgress*.5+.5;

    transOffset-=deltaTrans*progress;

    translation[0][3]+=transOffset.x;
    translation[1][3]+=transOffset.y;
    translation[2][3]+=transOffset.z;

    worldPos=mul(translation,worldPos);
    output.position=mul(projection,worldPos);

    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.normPos=input.position.xy*vec2(.5,.5f)+vec2(.5,.5);
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float4 outColor = getColor(inputTex0, input.tex1);
    float alpha = u.transitionAlpha * u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);
    return outColor;
}
