
#include "dxShaderIncludes.h"
#include "alpha.h"

vertexOut vertexShader(txShaderVerts input)
{
    vertexOut output;
    output.position = mul(u.worldViewProj,float4(input.position,1));
    output.tex1 = input.tex1;
    output.tex2 = input.tex2;
    output.texMask = input.texMask;
    return output;
}

float4 pixelShader(vertexOut input) : SV_TARGET
{
    vec2 p = input.tex1;

    float T = u.transitionProgress;

    float S0 = 1.0;
    float S1 = 250.0;
    float S2 = 1.0;

    // 2 segments, 1/2 each
    float Half = 0.5;

    float PixelSize = ( T < Half ) ? mix( S0, S1, T / Half ) : mix( S1, S2, (T-Half) / Half );

    float width,height;
    inputTex0.GetDimensions(width,height);
    vec2 D = PixelSize / float2(width,height);

    // remap UV from 0...1 to -0.5...+0.5 to make the mosaic pattern converge torwards the image center
    vec2 UV = ( p + vec2( -0.5,-0.5 ) ) / D;

    // don't forget to remap coords back to 0...1 after ceil()
    vec2 Coord = clamp( D * ( ceil( UV + vec2( -0.5,-0.5 ) ) ) + vec2( 0.5, 0.5 ), vec2( 0.0,0.0 ), vec2( 1.0,1.0 ) );

    vec4 texColor=getColor(inputTex0,Coord);

    vec4 colorA=mix(vec4(0,0,0,0),texColor,u.mix);
    vec4 colorB=mix(texColor,vec4(0,0,0,0),u.mix);
    float4 outColor;
    mixColor(outColor, colorB, colorA, u.transitionProgressLinear);

    float alpha = u.baseAlpha;
#ifdef USE_MASK
    alpha *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    multiplyOpacity(outColor, alpha);
    return outColor;
}
