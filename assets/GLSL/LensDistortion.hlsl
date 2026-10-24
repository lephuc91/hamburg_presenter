#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float lensSize;
    float colorDistort;
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

fxVertexOut vertexShader(fxShaderVerts input)
{
    fxVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy*vec2(.5,-.5f);
    output.tex1 = input.tex1;
    output.texMask = input.texMask;
    output.texSize = u.texSize;
    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    float k  = -vars.lensSize;//-0.15; //distortion coefficient
    float kcube = .5;//.15; //cubic distortion value
    float scale = .9;
    float dispersion = vars.colorDistort*.01;

    //    float r2 = (x- .5) * (x-.5) + (y - .5) * (y-.5);
    float r2=length(input.normPos);

    //compute cubic distortion, if necessary
    float mult = -vars.lensSize;
    if( kcube != 0.0 )
        mult = k + kcube * r2;

    float f= 1.0 + r2*r2 * mult;  //factor of distortion

    //chromatic aberration variable distortion depending on color
    vec2 tCoord = input.normPos; //x , y coord, not image coord
    vec3 eta = vec3(1.0+dispersion*8.0, 1.0+dispersion*3.0, 1.0+dispersion*1.0);//strong red distortion, weak green and blue

    vec2 rCoords = (f*eta.r)*scale*(tCoord.xy)+0.5;
    vec2 gCoords = (f*eta.g)*scale*(tCoord.xy)+0.5;
    vec2 bCoords = (f*eta.b)*scale*(tCoord.xy)+0.5;

    rCoords=clamp(rCoords,vec2(0.0,0.0),vec2(1.0,1.0));
    gCoords=clamp(gCoords,vec2(0.0,0.0),vec2(1.0,1.0));
    bCoords=clamp(bCoords,vec2(0.0,0.0),vec2(1.0,1.0));
    vec4 texel=getColor(inputTex,fsTexture);
    float4 outColor=getColor(inputTex,rCoords);
    outColor.g=getColor(inputTex,gCoords).g;
    outColor.b=getColor(inputTex,bCoords).b;
    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    mixColor(outColor, texel, outColor, blendValue);
    return outColor;
}
