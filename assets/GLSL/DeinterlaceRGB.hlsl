#include "inputShaderHelperDX.h"
#include "commonMLDX.h"
#include "alpha.h"
#include "inputColorHelper.h"

v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = float4(input.position,1.0);
    output.texCoordY = input.texCoordY;
    output.texCoordUV = input.texCoordY;
    return output;
}




float4 pixelShader(v2p input) : SV_TARGET
{
    float width,height;
    inputTex0.GetDimensions(width,height);
    float2 normalizedTC=input.texCoordY/float2(width,height);

    float isOddLine;
    vec2 tc00;
    vec2 tc10;
    vec2 tc20;
    vec4 c00;
    vec4 c10;
    vec4 c20;
    vec4 avg;

    tc10=normalizedTC;
    
#ifdef IS_ODD
    isOddLine=1.0 - floor(fract(input.texCoordY.y * 0.5) * 2.0);
#else
    isOddLine=floor(fract(input.texCoordY.y * 0.5) * 2.0);
#endif
    isOddLine/=height; // get back to normalized space for line offset

    //above and below lines start with same coordinates
    tc00=tc10;
    tc20=tc10;
    //for above line, subtract 1
    tc00.y-=isOddLine;
    //for below line, add 1
    tc20.y+=isOddLine;
    
#ifdef ARGB
    c00 = textureFetchNearest(inputTex0, tc00).argb;
    c10 = textureFetchNearest(inputTex0, tc10).argb;
    c20 = textureFetchNearest(inputTex0, tc20).argb;
#endif
    
#ifdef ABGR
    c00 = textureFetchNearest(inputTex0, tc00).abgr;
    c10 = textureFetchNearest(inputTex0, tc10).abgr;
    c20 = textureFetchNearest(inputTex0, tc20).abgr;
#endif

#ifdef BGRA
    c00 = textureFetchNearest(inputTex0, tc00).bgra;
    c10 = textureFetchNearest(inputTex0, tc10).bgra;
    c20 = textureFetchNearest(inputTex0, tc20).bgra;
#endif
    
#ifdef RGBA
    c00 = textureFetchNearest(inputTex0, tc00).rgba;
    c10 = textureFetchNearest(inputTex0, tc10).rgba;
    c20 = textureFetchNearest(inputTex0, tc20).rgba;
#endif

    float gray0 = dot(c00.rgb, float3(0.299, 0.587, 0.114));
    float gray1 = dot(c10.rgb, float3(0.299, 0.587, 0.114));
    float gray2 = dot(c20.rgb, float3(0.299, 0.587, 0.114));

    avg=(c00+c20)*0.5;
    
    if(gray1>=gray0)
    {
        if(gray1>gray2)
            c10=avg;
    }
    else
    {
        if(gray1<gray2)
            c10=avg;
    }

    float4 outColor=c10;
    
    outColor=processColorProfile(outColor);

#ifdef USE_MASK
    multiplyOpacity(outColor, textureFetchNearest(maskTex, normalizedTC).a);
#endif

#ifdef USE_END_COLOR
    mixColor(outColor, uniforms.endColor, outColor, uniforms.endOpacity);
#endif

    return outColor;
}
