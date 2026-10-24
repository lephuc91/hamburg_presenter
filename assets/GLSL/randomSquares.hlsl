#include "dxShaderIncludes.h"
#include "alpha.h"

typedef struct
{
    float squareSize;
    float pad[3];
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

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
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    output.normPos=input.position.xy*vec2(.5,.5f)+vec2(.5,.5);
    return output;
}

static const float smoothness=1.0;

float4 pixelShader(vertexOut input) : SV_TARGET
{
    vec2 p = input.normPos;
    float r = rand(floor(vec2((11.0-vars.squareSize)*3.5,(11.0-vars.squareSize)*3.5) * p));
    float m = smoothstep(0.0, -smoothness, r - (u.transitionProgressLinear * (1.0 + smoothness)));
    vec4 texColor=getColor(inputTex0,input.tex1);
    vec4 texelA=mix(vec4(0,0,0,0),texColor,u.mix);
    vec4 texelB=mix(texColor,vec4(0,0,0,0),u.mix);
    float4 outColor;
    mixColor(outColor, texelB, texelA, m);

    float alpha = u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);

    return outColor;
}
