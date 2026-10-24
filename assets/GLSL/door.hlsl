#include "dxShaderIncludes.h"
#include "alpha.h"

float rand(vec2 co)
{
    float a = 12.9898;
    float b = 78.233;
    float c = 43758.5453;
    float dt= dot(co.xy ,vec2(a,b));
    float sn= mod(dt,3.14);
    return fract(sin(sn) * c);
}


vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.normPos=input.position.xy*vec2(.5,.5f)+vec2(.5,.5);

    vec4 deltaTransIn=vec4(0.,0.,-3.0,.0);
    vec4 transOffsetIn=vec4(0.0,0.0,-3.0,.0);

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

    vec4 worldPos= mul(u.worldViewProj,float4(input.position,1));

    if(u.transitionState==0)
    {
        float progress=u.transitionProgress*1.;
        transOffsetIn-=deltaTransIn*progress;

        translation[0][3]+=transOffsetIn.x;
        translation[1][3]+=transOffsetIn.y;
        translation[2][3]+=transOffsetIn.z;
    }

    worldPos=mul(translation,worldPos);
    output.position=mul(projection,worldPos);


    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    float4 outColor=vec4(0,0,0,0);
    float alpha = u.baseAlpha;
    if(u.transitionState==0)
    {
        outColor=getColor(inputTex0,input.tex1);
        alpha *= u.transitionProgress;
    }
    else
    {
        //expanding old texture and splitting in middle
        vec2 tadj=input.tex1;
        float open=u.transitionProgress*.5;
        float middle=.5;
        if(input.tex1.x<middle)
        {
            tadj.x+=open;
            if(tadj.x>middle)
                discard;
        }
        else
        {
            tadj.x-=open;
            if(tadj.x<middle)
                discard;
        }
        outColor=getColor(inputTex0,tadj);
    }
#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);
    return outColor;
}
