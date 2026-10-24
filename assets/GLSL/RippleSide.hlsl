#include "dxEffectIncludes.h"
#include "alpha.h"

static const float PI = 3.1415926535897932;

//speed
static const float speed = 0.2;
static const float speed_x = 0.3;
static const float speed_y = 0.3;

// geometry
static const float intensity = 3.;
static const int steps = 8;
static const float frequency = 4.0;
static const int angle = 7; // better when a prime

// reflection and emboss
static const float delta = 20.;
static const float intence = 400.;
static const float emboss = 0.3;

//---------- crystals effect

float col(vec2 coord,float fsTime)
{
    float delta_theta = 2.0 * PI / float(angle);
    float col = 0.0;
    float theta = 0.0;

    for (int i = 0; i < steps; i++)
    {
        vec2 adjc = coord;
        theta = delta_theta*float(i);
        adjc.x += cos(theta)*fsTime*speed + fsTime * speed_x;
        adjc.y -= sin(theta)*fsTime*speed - fsTime * speed_y;
        col = col + cos( (adjc.x*cos(theta) - adjc.y*sin(theta))*frequency)*intensity;
    }

    return cos(col);
}

typedef struct
{
    float speed;
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
    float fsTime=u.localTime*vars.speed;

    vec2 c1 = input.tex1;
    vec2 c2 = input.tex1;
    float cc1 = col(c1,fsTime);

    c2.x += 64.0;
    float dx = emboss*(cc1-col(c2,fsTime))/delta;

    c2.x = input.tex1.x;
    c2.y += 39.0;
    float dy = emboss*(cc1-col(c2,fsTime))/delta;

    c1.x += dx;
    c1.y += dy;
    //  c1.y = -c1.y;

    float alpha = 1.0 + dot(vec2(dx, dx), vec2(dy, dy)) * intence;

    //    vec2 uv=clamp(c1,vec2(0.0,0.0),vec2(1.0,1.0))*fsTextureSize;
    vec2 uv=c1;

    vec4 texel=getColor(inputTex,fsTexture);
    vec4 texColor=getColor(inputTex,uv);

#ifdef PRE_MULT
    divideAlpha(texColor);
#endif
    float4 outColor;
    outColor.rgb = texColor.rgb * alpha;
    outColor.a = texColor.a;
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif

    float blendValue = u.blendValue;
#ifdef USE_MASK
    blendValue *= getColor(inputTexMask, input.texMask).a;
#endif
    mixColor(outColor, texel, outColor, blendValue);

    return outColor;
}
