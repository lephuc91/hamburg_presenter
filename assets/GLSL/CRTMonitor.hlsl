#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float strength;
    float pixelSize;
} fxVars;


cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

fxVertexOut vertexShader(fxShaderVerts input)
{
    fxVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy * vec2(.5,.5f) + vec2(.5,.5);
    output.tex1 = input.tex1;
    output.texMask = input.texMask;
    output.texSize = u.texSize;
    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    vec4 texColor = getColor(inputTex, fsTexture);
#ifdef PRE_MULT
    divideAlpha(texColor);
#endif
    int psize=int(vars.pixelSize);
    float pixelSize=float(psize);
    vec2 cor;

    vec2 tmpTexture=input.tex1*input.texSize;
    cor.x =  tmpTexture.x/pixelSize;
    cor.y = (tmpTexture.y+pixelSize*1.5*mod(floor(cor.x),2.0))/(pixelSize*3.0);

    vec2 ico = floor( cor );
    vec2 fco = fract( cor );

    vec3 num=vec3(0.0,1.0,2.0) + ico.x;
    vec3 pix = step( 1.5, mod(num, vec3(3.0,3.0,3.0) ) );
    tmpTexture=pixelSize*ico*vec2(1.0,3.0);
    tmpTexture/=input.texSize;
    vec3 ima = getColor(inputTex,tmpTexture).xyz;

    vec3 col = pix*dot( pix, ima );

    col *= step( abs(fco.x-0.5), 0.4 );
    col *= step( abs(fco.y-0.5), 0.4 );

    col *= vars.strength;
    float4 outColor = vec4(col,texColor.a);

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    outColor.rgb=mix(texColor.rgb,outColor.rgb,blendValue);

#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}
