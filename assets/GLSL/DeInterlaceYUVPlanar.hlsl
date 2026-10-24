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

    vec4 yuv0;
    vec4 yuv1;
    vec4 yuv2;
    vec4 avg;
    vec2 tc00;
    vec2 tc10;
    vec2 tc20;

    tc10=normalizedTC;
    
    float isOddLine=0.0;
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
    
    
    yuv0.g = textureFetchNearest(inputTex0, tc00).r;
    yuv1.g = textureFetchNearest(inputTex0, tc10).r;
    yuv2.g = textureFetchNearest(inputTex0, tc20).r;

    yuv0.b = textureFetchNearest(inputTex1, tc00).r;
    yuv1.b = textureFetchNearest(inputTex1, tc10).r;
    yuv2.b = textureFetchNearest(inputTex1, tc20).r;

    yuv0.r = textureFetchNearest(inputTex2, tc00).r;
    yuv1.r = textureFetchNearest(inputTex2, tc10).r;
    yuv2.r = textureFetchNearest(inputTex2, tc20).r;

#ifdef HAS_ALPHA
    yuv0.a = textureFetchNearest(inputTex3, tc00).r;
    yuv1.a = textureFetchNearest(inputTex3, tc10).r;
    yuv2.a = textureFetchNearest(inputTex3, tc20).r;
#endif

    
    avg=(yuv0+yuv2)*0.5;
    
    if(yuv1.g>=yuv0.g)
    {
        if(yuv1.g>yuv2.g)
            yuv1=avg;
    }
    else
    {
        if(yuv1.g<yuv2.g)
            yuv1=avg;
    }

#ifdef IS_10BIT
    yuv1*=float4(64.0, 64.0, 64.0, 64.0);;
#endif
    
#ifdef IS_12BIT
    yuv1*=float4(16.0, 16.0, 16.0, 16.0);
#endif

#ifndef HAS_ALPHA
    yuv1.a=1.0;
#endif

    yuv1+=stdbias;

    float4 outColor=vec4(dot(yuv2R, yuv1),
                  dot(yuv2G, yuv1),
                  dot(yuv2B, yuv1),
                  yuv1.a);

    outColor=processColorProfile(outColor);

#ifdef USE_MASK
    multiplyOpacity(outColor, textureFetchNearest(maskTex, normalizedTC).a);
#endif

#ifdef USE_END_COLOR
    mixColor(outColor, uniforms.endColor, outColor, uniforms.endOpacity);
#endif

    return outColor;
}
