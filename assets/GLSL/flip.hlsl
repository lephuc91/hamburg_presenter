#include "dxShaderIncludes.h"
#include "alpha.h"

vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    float stimer=0.;
    if(u.transitionState==0)
        stimer=3.1415926535897932384626433832795+u.transitionProgress*3.1415926535897932384626433832795;
    else if(u.transitionState==2)
        stimer=u.transitionProgress*3.1415926535897932384626433832795;

    mat4 rotation = mat4(
                         cos(stimer),  0.0,-sin(stimer), 0.0,
                         0.0,  1.0,        0.0, 0.0,
                         sin(stimer),  0.0, cos(stimer), 0.0,
                         0.0,  0.0,        0.0, 1.0);
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

    vec4 tmpPos= mul(u.worldViewProj,float4(input.position,1));

    vec4 worldPos=mul(rotation,tmpPos);
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
    float alpha = u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);
    return outColor;
}
