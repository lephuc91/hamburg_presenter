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

static const vec4 dirMult[9]={
    vec4(1.,-1.,1.,0.),
    vec4(0.,-1.,1.,0.),
    vec4(-1.,-1.,1.,0.),
    vec4(1.,0.,1.,0.),
    vec4(0.,0.,1.,0.),
    vec4(-1.,0.,1.,0.),
    vec4(1.,1.,1.,0.),
    vec4(0.,1.,1.,0.),
    vec4(-1.,1.,1.,0.)
};



vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;

    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;

    vec4 deltaTransIn=vec4(-7.,-5.,-16.,.0)*dirMult[vars.direction];
    vec4 transOffsetIn=vec4(-3.5,-2.5,-8.0,.0)*dirMult[vars.direction];

    vec4 deltaTransOut=vec4(5.5,4.,10.0,0.0)*dirMult[vars.direction];
    vec4 transOffsetOut=vec4(0.0,0.0,0.0,0.0);

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

    if(u.transitionState==0)
    {
        float progress=u.transitionProgress*.5;
        transOffsetIn-=deltaTransIn*progress;
        float offset=(.5-progress)*6.5*u.transitionProgress;
        vec2 toff=dirMult[vars.direction].xy*offset;
        transOffsetIn.xy+=toff;

        translation[0][3]+=transOffsetIn.x;
        translation[1][3]+=transOffsetIn.y;
        translation[2][3]+=transOffsetIn.z;
    }
    else if(u.transitionState==2)
    {
        float progress=-u.transitionProgress*.5;
        transOffsetOut-=deltaTransOut*progress;
        float offset=(.5-progress)*3.*u.transitionProgress;
        vec2 toff=dirMult[vars.direction].xy*offset;
        transOffsetIn.xy+=toff;

        translation[0][3]+=transOffsetOut.x;
        translation[1][3]+=transOffsetOut.y;
        translation[2][3]+=transOffsetOut.z;
    }


    worldPos=mul(translation,worldPos);
    output.position=mul(projection,worldPos);

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
