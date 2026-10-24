#include "dxShaderIncludes.h"
#include "alpha.h"

vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;

    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.normPos=input.position.xy*vec2(.5,.5f)+vec2(.5,.5);

    float zTimer=0.;
    float xTimer=0.;
    float xScale=1.;
    float rTimer=0.;
    if(u.transitionState==0)
    {
        rTimer=3.1415926535897932384626433832795*-.2+u.transitionProgress*3.1415926535897932384626433832795*.2;
        xTimer=3.1415926535897932384626433832795-u.transitionProgress*3.1415926535897932384626433832795;
        zTimer=u.transitionProgress*3.1415926535897932384626433832795;
        xScale=-1.;
    }
    else if(u.transitionState==2)
    {
        rTimer=u.transitionProgress*3.1415926535897932384626433832795*.2;
        xTimer=u.transitionProgress*3.1415926535897932384626433832795;
        zTimer=3.1415926535897932384626433832795-u.transitionProgress*3.1415926535897932384626433832795;
        xScale=1.;
    }

    mat4 rotation = mat4(
                         cos(rTimer),  0.0,-sin(rTimer), 0.0,
                         0.0,  1.0,        0.0, 0.0,
                         sin(rTimer),  0.0, cos(rTimer), 0.0,
                         0.0,  0.0,        0.0, 1.0);
    mat4 projection = mat4(
                           2.4140,0.0000,0.0000,0.0000,
                           0.0000,2.4140,0.0000,0.0000,
                           0.0000,0.0000,-1.020,-2.002,
                           0.0000,0.0000,-1.000,0.0000);

    float zvalue=cos(zTimer)*-2.5-4.9;
    float xvalue=sin(xTimer)*xScale;
    mat4 translation=mat4(
                          1.0, 0.0, 0.0, 0.00,
                          0.0, 1.0, 0.0, 0.00,
                          0.0, 0.0, 1.0, -0.014,
                          0.0, 0.0, 0.0, 1.00);


    vec4 tmpPos=mul(u.worldViewProj,float4(input.position,1));


    translation[0][3]+=xvalue;
    translation[2][3]+=zvalue;

    vec4 worldPos=mul(rotation,tmpPos);
    worldPos=mul(translation,worldPos);

    output.position=mul(projection,worldPos);

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
