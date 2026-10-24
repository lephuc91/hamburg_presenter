#include "dxEffectIncludes.h"


typedef struct
{
    float outlineAmount;
    float colorLevel;
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}


static const float coeffs_fx[9] = {-1.0, 0.0, 1.0,-2.0, 0.0, 2.0,-1.0, 0.0, 1.0};

static const float coeffs_fy[9] = {+1.0f, +2.0f, +1.0f,
                                      +0.0f, +0.0f, +0.0f,
                               -1.0f, -2.0f, -1.0f};

static const vec2 offset[9] = {vec2(-1.0f, +1.0f), vec2(+0.0f, +1.0f), vec2(+1.0f, +1.0f),
                                 vec2(-1.0f, +0.0f), vec2(+0.0f, +0.0f), vec2(+1.0f, +0.0f),
    vec2(-1.0f, -1.0f), vec2(+0.0f, -1.0f), vec2(+1.0f, -1.0f)};

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
    vec2 pos;
    float y = 0.0f, gx = 0.0f, gy = 0.0f;
    vec2 current = fsTexture*input.texSize;;
    for (int i = 0; i < 9; i++)
    {
        pos.x = current.x+offset[i].x;
        pos.y = current.y+offset[i].y;
        y=dot(getColor(inputTex, pos/input.texSize).rgb, vec3(0.299, 0.587, 0.114));
        gx += (y*coeffs_fx[i]);
        gy += (y*coeffs_fy[i]);
    }
    y = sqrt((gx*gx)+(gy*gy))*vars.outlineAmount;


    vec4 texel=getColor(inputTex,fsTexture);
    float4 outColor = texel*vec4(vars.colorLevel,vars.colorLevel,vars.colorLevel,1.);

    outColor.r+=y;
    outColor.r=min(255.,outColor.r);
    outColor.g+=y;
    outColor.g=min(255.,outColor.g);
    outColor.b+=y;
    outColor.b=min(255.,outColor.b);

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    outColor.rgb=mix(texel.rgb,outColor.rgb,blendValue);
    return outColor;
}

