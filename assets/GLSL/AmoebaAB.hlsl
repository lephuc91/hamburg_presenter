#include "dxShaderIncludes.h"
#include "alpha.h"

typedef struct
{
    float scale;
    float pad[3];
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}


float hash(float2 p)
{
    p  = 50.0*fract( p*0.3183099 + float2(0.71,0.113));
    return -1.0+2.0*fract( p.x*p.y*(p.x+p.y) );
}

float noise(float2 p )
{
    float2 i = floor( p );
    float2 f = fract( p );

    float2 u = f*f*(3.0-2.0*f);

    return mix( mix( hash( i + float2(0.0,0.0) ),
                    hash( i + float2(1.0,0.0) ), u.x),
               mix( hash( i + float2(0.0,1.0) ),
                   hash( i + float2(1.0,1.0) ), u.x), u.y);
}

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
    float4 newColor = float4(inputTex0.Sample(linearSampler,input.tex1));
    float4 oldColor = float4(inputTex1.Sample(linearSampler,input.tex2));

    float2 p=input.tex2;
    float inputTex1Width;
    float inputTex1Height;
    inputTex1.GetDimensions(inputTex1Width, inputTex1Height);
    float2 uv2 = p*float2(inputTex1Width/inputTex1Height,1.0);

    float f = 0.0;
    f = noise( vars.scale*uv2 );
    f = 0.5 + 0.5*f;

    f *= smoothstep( 0.0, 0.005, abs(p.x-0.0) );

    float2 uv0 = (input.tex1*2.0 - 1.0) * 0.5;
    float length0 = sqrt(dot(uv0, uv0));
    float time = u.transitionProgress * 150.0;
    float mask = 1.0 - clamp(length0 * 100.0 - (time*(f*0.5+0.5)),0.0,1.0);

    float4 outColor=mix(oldColor,newColor,mask);

#ifdef USE_MASK
    multiplyOpacity(outColor, float(inputTexMask.Sample(linearSampler, input.texMask).a));
#endif

    return outColor;
}
