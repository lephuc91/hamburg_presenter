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
    float isOddUV;
    vec2 tc00;
    vec2 tc10;
    vec2 tc20;
    vec4 c00;
    vec4 c10;
    vec4 c20;
    vec4 avg;

    tc10=normalizedTC;


#ifdef IS_ODD
    isOddLine=1.0-floor(fract(input.texCoordY.y * 0.5) * 2.0);
#else
    isOddLine=floor(fract(input.texCoordY.y * 0.5) * 2.0);
#endif
    isOddLine/=height; // get back to normalized space for line offset
    isOddUV = floor(fract(input.texCoordY.x * 0.5) * 2.0);


    tc10.x*=.5;

    //above and below lines start with same coordinates
    tc00=tc10;
    tc20=tc10;
    //for above line, subtract 1
    tc00.y-=isOddLine;
    //for below line, add 1
    tc20.y+=isOddLine;

    float alpha = 1.0;
#ifdef YUYV
    c00 = textureFetchNearest(inputTex0, tc00).abgr;
    c10 = textureFetchNearest(inputTex0, tc10).abgr;
    c20 = textureFetchNearest(inputTex0, tc20).abgr;
#endif

#ifdef UYVY
    c00 = textureFetchNearest(inputTex0, tc00);
    c10 = textureFetchNearest(inputTex0, tc10);
    c20 = textureFetchNearest(inputTex0, tc20);
#endif

#ifdef YUVA
    c00 = textureFetchNearest(inputTex0, tc00);
    c10 = textureFetchNearest(inputTex0, tc10);
    c20 = textureFetchNearest(inputTex0, tc20);
    alpha = textureFetchNearest(inputTex1, tc10).r;
#endif

    c00.g=mix(c00.g,c00.a,isOddUV);
    c10.g=mix(c10.g,c10.a,isOddUV);
    c20.g=mix(c20.g,c20.a,isOddUV);

    avg=(c00+c20)*0.5;

    if(c10.g>=c00.g)
    {
        if(c10.g>c20.g)
            c10=avg;
    }
    else
    {
        if(c10.g<c20.g)
            c10=avg;
    }

    c10+=stdbias;

    float4 outColor=vec4(dot(yuv2R, c10),
        dot(yuv2G, c10),
        dot(yuv2B, c10),
        alpha);

    outColor=processColorProfile(outColor);

#ifdef USE_MASK
    multiplyOpacity(outColor, textureFetchNearest(maskTex, input.maskCoord).a);
#endif

#ifdef USE_END_COLOR
    mixColor(outColor, uniforms.endColor, outColor, uniforms.endOpacity);
#endif

    return outColor;
}
