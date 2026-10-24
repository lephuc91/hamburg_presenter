#include "dxShaderIncludes.h"
#include "alpha.h"

typedef struct
{
    float4 burnColor;
    float pad[3];
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
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

static const float FPS=60.;
static const float Seed=2.31;
static const float3 toXYZ_R = float3(0.4124, 0.3576, 0.1805);
static const float3 toXYZ_G = float3(0.2126, 0.7152, 0.0722);
static const float3 toXYZ_B = float3(0.0193, 0.1192, 0.9505);

//#define progress (floor(progress*FPS)/(FPS+1.))

float sigmoid(float x, float a)
{
    float b = pow(x*2.,a)/2.;
    if (x > .5) {
        b = 1.-pow(2.-(x*2.),a)/2.;
    }
    return b;
}

float rand(float co)
{
    return fract(sin((co*24.9898)+Seed)*43758.5453);
}

float rand(vec2 co)
{
    return fract(sin(dot(co.xy ,vec2(12.9898,78.233))) * 43758.5453);
}

float apow(float a,float b)
{
    return pow(abs(a),b)*sign(b);
}

vec3 pow3(vec3 a,vec3 b)
{
    return vec3(apow(a.r,b.r),apow(a.g,b.g),apow(a.b,b.b));
}

float smooth_mix(float a,float b,float c)
{
    return mix(a,b,sigmoid(c,2.));
}

float random(vec2 co, float shft)
{
    co += 10.;
    return smooth_mix(fract(sin(dot(co.xy ,vec2(12.9898+(floor(shft)*.5),78.233+Seed))) * 43758.5453),fract(sin(dot(co.xy ,vec2(12.9898+(floor(shft+1.)*.5),78.233+Seed))) * 43758.5453),fract(shft));
}

float smooth_random(vec2 co, float shft)
{
    return smooth_mix(smooth_mix(random(floor(co),shft),random(floor(co+vec2(1.,0.)),shft),fract(co.x)),smooth_mix(random(floor(co+vec2(0.,1.)),shft),random(floor(co+vec2(1.,1.)),shft),fract(co.x)),fract(co.y));
}

vec4 getTextureA(Texture2D tpipe,vec2 p,float abSelect)
{
    vec4 texColor = getColor(tpipe,p);
    vec4 color=mix(vec4(0,0,0,0),texColor,abSelect);
    return(color);
}

vec4 getTextureB(Texture2D tpipe,vec2 p,float abSelect)
{
    vec4 texColor = getColor(tpipe,p);
    vec4 color=mix(texColor,vec4(0,0,0,0),abSelect);

    return(color);
}

#define pi 3.14159265358979323
#define clamps(x) clamp(x,0.,1.)

float4 pixelShader(vertexOut input) : SV_TARGET
{
    vec2 p = input.tex1;
    vec3 f = vec3(0,0,0);
    float progress=floor(u.transitionProgressLinear*FPS)/(FPS+1.);

    for (float i = 0.; i < 13.; i++)
    {
        f += sin(((p.x*rand(i)*6.)+(progress*8.))+rand(i+1.43))*sin(((p.y*rand(i+4.4)*6.)+(progress*6.))+rand(i+2.4));
        //        f += 1.-clamps(length(p-vec2(smooth_random(vec2(progress*1.3),i+1.),smooth_random(vec2(progress*.5),i+6.25)))*mix(20.,70.,rand(i)));
    }

    f += 4.;
    f /= 11.;
    f = pow3(f*vec3(1.,0.7,0.6),vec3(1.,2.-sin(progress*pi),1.3));
    f *= sin(progress*pi);
#ifdef LINEAR_16
    f *= u.nitsScale * .4;
    f = float3(dot(toXYZ_R, f), dot(toXYZ_G, f), dot(toXYZ_B, f));
#endif
    p -= .5;
    p *= 1.+(smooth_random(vec2(progress*5.,progress*5.),6.3)*sin(progress*pi)*.05);
    p += .5;

    vec4 blurred_image = vec4(0,0,0,0);
    float bluramount = sin(progress*pi)*.03;
#define repeats 8.
    for (float i = 0.; i < repeats; i++)
    {
        vec2 q = vec2(cos(((i/repeats)*pi*2.)),sin(((i/repeats)*pi*2))) *  (rand(vec2(i,p.x+p.y))+bluramount);
        vec2 uv2 = p+(q*bluramount);
        blurred_image += getColor(inputTex0,uv2);
    }
    blurred_image /= repeats;

    blurred_image.rgb+=f.rgb*blurred_image.a;

    vec4 colorA;
    mixColor(colorA, vec4(0,0,0,0), blurred_image, u.transitionProgressLinear);
    vec4 colorB;
    mixColor(colorB, blurred_image, vec4(0,0,0,0), u.transitionProgressLinear);

    float fsABSelect=1.0;
    if(u.transitionState==2)
        fsABSelect=0.0;
    float4 outColor = mix(colorB, colorA, fsABSelect);

    float alpha = u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);

    return outColor;
}
