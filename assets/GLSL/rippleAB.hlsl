#include "dxShaderIncludes.h"
#include "alpha.h"

vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.normPos=input.position.xy*vec2(.5,.5f)+vec2(.5,.5);
    return output;
}


float4 pixelShader(vertexOut input) : SV_TARGET
{
    float rad = 1.3 * u.transitionProgress; // radius from center of the uv texture square
    float swell = 0.5432* u.transitionProgress; // swell region magnitude
    vec2 CPoint = vec2(0.5, 0.5); // center point
    float dist = length((input.tex1 - CPoint)/vec2(0.70,1));
    vec2 uvOrig = input.tex1;
    vec2 uvNew = uvOrig;
    float alpha = 0; // blend factor between the 2 textures
    if (dist < rad) // show the new texture - this expands from center outwards
    {
        alpha = 1; //when inside, show the new texture colour
    }
    if (dist > rad && dist < (rad + swell))
    {
        float lambda = smoothstep(rad, rad+swell, dist); // factor in [0,1]
        alpha = 1 - lambda; // modified blend factor
        vec2 vec = (uvOrig - CPoint) ;
        vec2 dir = ((vec)/(length(vec/vec2(0.70,1)))) ;
        uvNew = CPoint + ((1-lambda) * rad + lambda * (rad+swell)) * dir;
    }
    if (dist >= rad + swell)
        alpha = 0; // show the old texture only

    vec4 colorA=getColor(inputTex1,input.tex2);
    vec4 colorB=getColor(inputTex0,uvNew);
    float4 outColor;
    mixColor(outColor, colorA, colorB, alpha);

    alpha = u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);

    return outColor;
}

