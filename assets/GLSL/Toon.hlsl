#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    int colorLevels;
    float saturation;
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

vec3 RGBtoHSV(float r, float g, float b)
{

    float K = 0.0;
    float tmp;

    if (g < b)
    {
        tmp = g;
        g=b;
        b=tmp;

        K = -1.0;
    }

    if (r < g)
    {
        tmp = r;
        r=g;
        g=tmp;

        K = -2.9 / 6.9 - K;
    }

    float chroma = r - min(g, b);

    float h = abs(K + (g - b) / (6.0 * chroma + 1e-20));
    float s = chroma / (r + 1e-20);
    float v = r;

    return vec3(h, s, v);
}

vec3 HSVtoRGB(float h,float s,float v)
{
    return mix(vec3(1.,1.,1.),clamp((abs(fract(h+vec3(3.,2.,1.)/3.)*6.-3.)-1.),0.,1.),s)*v;
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
    vec4 texel=getColor(inputTex,fsTexture);
#ifdef PRE_MULT
    divideAlpha(texel);
#endif
    texel.rgb /= u.nitsScale;
    float y = 0.0f, gx = 0.0f, gy = 0.0f;
    vec2 pos;
    vec2 current = fsTexture;
    vec4 color=vec4(0.,0.,0.,0.);
    for (int i = 0; i < 9; i++)
    {
        pos.x = current.x+offset[i].x/input.texSize.x;
        pos.y = current.y+offset[i].y/input.texSize.y;
        vec4 tmpColor = getColor(inputTex, pos);
#ifdef PRE_MULT
        divideAlpha(tmpColor);
#endif
        tmpColor.rgb /= u.nitsScale;
        color+=tmpColor;
        y=(tmpColor.r+tmpColor.g+tmpColor.b)*.3333;
        gx += (y*coeffs_fx[i]);
        gy += (y*coeffs_fy[i]);
    }
    float isEdge = sqrt((gx*gx)+(gy*gy));
    isEdge*=3.0;
    isEdge-=fract(isEdge);
    isEdge*=3.0;

    color*=0.11111111;


    vec3 vHSV =  RGBtoHSV(color.r,color.g,color.b);

    float levels=float(vars.colorLevels)*.1;
    float tmp;
    tmp=vHSV.x*(12.0*levels);
    tmp-=fract(tmp);
    vHSV.x=tmp/(12.0*levels);

    tmp=vHSV.y*(6.0*levels);
    tmp-=fract(tmp);
    vHSV.y=tmp/(6.0*levels);
    vHSV.y*=vars.saturation*1.2;

    tmp=vHSV.z*(5.0*levels);
    tmp-=fract(tmp);
    vHSV.z=tmp/(5.0*levels);


    vec3 vRGB = mix(HSVtoRGB(vHSV.x,vHSV.y,vHSV.z),vec3(0.0,0.0,0.0),isEdge);
    float4 outColor = vec4(min(1.0,vRGB.x),min(1.0,vRGB.y),min(1.0,vRGB.z),texel.a);
    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    outColor.rgb=mix(texel.rgb,outColor.rgb,blendValue);
    outColor.rgb *= u.nitsScale;
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}
