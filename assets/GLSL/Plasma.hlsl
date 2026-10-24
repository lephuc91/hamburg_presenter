#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float blendValue;
    float speed;
} fxVars;


cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

static const float PI = 3.14159265;

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
    float color1, color2, color;
    float fsTime=u.globalTime*vars.speed;
    float2 tmpTex=input.tex1*input.texSize;
    color1 = (sin(dot(tmpTex.xy,vec2(sin(fsTime*3.0),cos(fsTime*3.0)))*0.02+fsTime*3.0)+1.0)/2.0;

    vec2 center = vec2(input.texSize.x/2.0,input.texSize.y/2.0) + vec2(sin(-fsTime*3.0),cos(-fsTime*3.0));

    color2 = (cos(length(tmpTex.xy - center)*0.03)+1.0)/2.0;

    color = (color1+ color2)/2.0;

    float red    = (cos(PI*color/0.5+fsTime*3.0)+1.0)/2.0;
    float green    = (sin(PI*color/0.5+fsTime*3.0)+1.0)/2.0;
    float blue    = (sin(+fsTime*3.0)+1.0)/2.0;

    vec4 plasma = vec4(red, green, blue, 1.0);
    float4 outColor=getColor(inputTex,input.tex1);
#ifdef PRE_MULT
    divideAlpha(outColor);
#endif
    float blendValue2=u.blendValue*vars.blendValue;

#ifdef USE_MASK
    blendValue2*=getColor(inputTexMask,input.texMask).a;
#endif
    outColor.rgb = mix(outColor.rgb, plasma.rgb * u.nitsScale, blendValue2);

#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}
