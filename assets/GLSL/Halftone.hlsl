#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float sharpnessValue;
    float gcrValue;
    float ucrValue;
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}


/* Angle of halftone grid (degrees; positive = counterclockwise) */
static const float angle = -45.0;

/* Contrast control */
static const float contrastDelta = 0.3; // higher -> grey gets darker
static const float brightness = 0.0; // analog for white
static const float blackness = 1.1; // higher -> larger areas completely covered by dots

/* smoothness black to white (pseudo anti-aliasing). */
static const float smoothValue = 0.2;

static const vec4 dotColor = vec4(0.0, 0.0, 0.0, 1.0);
static const float kHalftoneWidth = 128.0;


vec4 RGBtoCMYK(vec3 rgb)
{
    vec3 cmycolor = vec3(1.0,1.0,1.0)-rgb;
    float k = min(cmycolor.r, min(cmycolor.g,cmycolor.b));
    vec4 cmyk = vec4((cmycolor-k)/(1.0-k),k);

    return cmyk;
}
vec3 CMYKtoRGB(vec4 cmyk)
{
    float k = cmyk.w;

    float r = (1.0-cmyk.x)*(1.0-k);
    float g = (1.0-cmyk.y)*(1.0-k);
    float b = (1.0-cmyk.z)*(1.0-k);

    return vec3(r,g,b);
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

    vec4 texel = getColor(inputTex, fsTexture);
#ifdef PRE_MULT
    divideAlpha(texel);
#endif
    texel.rgb /= u.nitsScale;
    mat2 rotate = mat2(cos(angle), -sin(angle),
                       sin(angle), cos(angle));
    mat2 inverse_rotate = mat2(cos(angle), sin(angle),
                               -sin(angle), cos(angle));

    /* Distance to next dot divided by two. */
    float halftoneWidth = kHalftoneWidth*min(2000.0, 1.0/vars.sharpnessValue);

    vec2 halfLineDist = halftoneWidth> 0.?vec2(1.0,1.0)/vec2(halftoneWidth,halftoneWidth)/vec2(2.0,2.0):vec2(0.,0.);

    /* Find center of the halftone dot. */
    vec2 st = fsTexture;
    vec2 center =  mul(rotate,st);
    center = halftoneWidth> 0.0?floor(center * vec2(halftoneWidth,halftoneWidth)) / vec2(halftoneWidth,halftoneWidth):center;
    center += halfLineDist;
    center = mul(inverse_rotate, center);

    /* Only red (texture is gray scale) */
    vec4 centerColor = getColor(inputTex, center);
#ifdef PRE_MULT
    divideAlpha(centerColor);
#endif
    centerColor.rgb /= u.nitsScale;
    float luminance = centerColor.r;

    /* Radius of the halftone dot. */
    float blacknessValue = blackness;
    float radius = sqrt(2.0)*halfLineDist.x*(1.0 - luminance)*blacknessValue;

    float contrastDeltaValue = contrastDelta;
    float brightnessValue = brightness;

    float contrast = 1.0 + (contrastDeltaValue)/(2.0);
    float radiusSqrd = contrast * pow(radius,2.0)
    - (contrastDeltaValue * halfLineDist.x*halfLineDist.x)/2.0
    - brightnessValue * halfLineDist.x*halfLineDist.x;


    vec2 power = pow(abs(center-st),vec2(2.0,2.0));
    float pixelDist2 = power.x + power.y; // Distance pixel to center squared.

    float delta = smoothValue*pow(halfLineDist.x,2.0);
    float gradient = smoothstep(radiusSqrd-delta, radiusSqrd+delta, pixelDist2);

    float4 outColor = getColor(inputTex, fsTexture);
#ifdef PRE_MULT
    divideAlpha(outColor);
#endif
    outColor.rgb /= u.nitsScale;
    vec3 irgb = outColor.rgb;

    // do GCR
    vec3 cmycolor = vec3(1,1,1) - irgb;
    float k = min(cmycolor.x, min(cmycolor.y, cmycolor.z))*vars.gcrValue*2.0;
    vec4 cmyk =vec4(cmycolor-vec3(k,k,k), k);

    // do UCR
    irgb = CMYKtoRGB(cmyk);
    cmyk = RGBtoCMYK(irgb);
    k = cmyk.w*vars.ucrValue;
    cmyk =cmyk-vec4(k,k,k,k);
    irgb = CMYKtoRGB(cmyk);

    outColor.rgb=mix(dotColor.rgb,irgb,gradient);
    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    outColor.rgb=mix(texel.rgb,outColor.rgb,blendValue);
    outColor.rgb *= u.nitsScale;
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}
