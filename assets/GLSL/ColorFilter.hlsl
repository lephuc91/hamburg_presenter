#include "dxEffectIncludes.h"


typedef struct
{
    float4 pickedColor;
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}


vec3 RGBtoHSV( float r, float g, float b )
{
    float minf, maxf, delta;
    vec3 hsv;

    minf = min(min( r, g), b);
    maxf = max(max( r, g), b);
    hsv.z = maxf;                 // v

    delta = maxf - minf;

    if( abs(maxf) > 0.0 ) {
        hsv.y = delta/maxf;            // s


    }
    else {
        // r = g = b = 0        // s = 0, v is undefined
        hsv.y = 0.0;  // *s = 0;
        hsv.x = -1.0;  //*h = -1;
    }

    if( abs(r-maxf)<0.0001)
        hsv.x = ( g - b ) / delta;        // between yellow & magenta
    else if( abs(g-maxf)<0.0001 )
        hsv.x = 2.0 + ( b - r ) / delta;    // between cyan & yellow
    else
        hsv.x = 4.0 + ( r - g ) / delta;    // between magenta & cyan

    hsv.x = hsv.x*60.0;                  // degrees
    if( hsv.x < 0.0 )
        hsv.x = hsv.x+ 360.0;

    return hsv;
}


vec3 HSVtoRGB( float h, float s, float v )
{
    int i;
    float f, p, q, t;
    vec3 rgb;

    if( abs(s) > 0.0 ) {
        h  = h/60.0;            // sector 0 to 5
        i = int(floor(h ));
        f = h - floor(h);            // factorial part of h
        p = v * ( 1.0 - s );
        q = v * ( 1.0 - s * f );
        t = v * ( 1.0 - s * ( 1.0 - f ) );

        if ( i == 0 ) {
            rgb.r = v;
            rgb.g = t;
            rgb.b = p;
        }
        else if (i == 1) {
            rgb.r = q;
            rgb.g = v;
            rgb.b = p;
        }
        else if (i == 2 ){
            rgb.r = p;
            rgb.g = v;
            rgb.b = t;
        }
        else if (i == 3){
            rgb.r = p;
            rgb.g = q;
            rgb.b = v;
        }
        else if ( i == 4){
            rgb.r = t;
            rgb.g = p;
            rgb.b = v;
        }
        else {
            rgb.r = v;
            rgb.g = p;
            rgb.b = q;
        }
    }
    else {
        // achromatic (grey)
        rgb.r = v;
        rgb.g = v;
        rgb.b = v;
    }
    return rgb;

}


const float pickedHue;

fxVertexOut vertexShader(fxShaderVerts input)
{
    fxVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy * vec2(.5,.5f) + vec2(.5,.5);
    output.tex1 = input.tex1;
    output.texMask = input.texMask;
    output.texSize = u.texSize;

    vec3 tmp=RGBtoHSV(vars.pickedColor.r,vars.pickedColor.g,vars.pickedColor.b);

    output.floatParam0=tmp.r;

    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    vec3 hsv;
    vec4 texel = getColor(inputTex, fsTexture);

    float4 outColor=texel;

    hsv = RGBtoHSV(texel.r, texel.g, texel.b);
    hsv.r = input.floatParam0;
    outColor.rgb = HSVtoRGB(hsv.r, hsv.g, hsv.b);
    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    outColor.rgb=mix(texel.rgb,outColor.rgb,blendValue);
    return outColor;
}
