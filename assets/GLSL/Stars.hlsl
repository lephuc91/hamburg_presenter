#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float speed;
    float blendValue;
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}



static const float PI = 3.1415926;

vec2 rotate(float a, vec2 p)
{
    return vec2(cos(a) * p.x + sin(a) * p.y,
                cos(a) * p.y - sin(a) * p.x);
}
float starsLayer(vec2 p)
{
    p *= vec2(4.0, 3.0);
    return clamp(1e-2 / abs(cos(p.x) * sin(p.y)) * cos(p.x + PI * 0.5) * sin(p.y + PI * 0.5), 0.0, 1.0);
}

vec3 stars(vec2 p,vec2 fsTime,float cosTime1,float cosTime2,float cosTime3)
{
    vec2 p2 = floor(p * 100.0) / 100.0;

    float b = fract(atan2(p2.y, p2.x) / PI * 10.0 + length(p2) * 3.0 * cosTime1 + cosTime2 * 2.0);

    b = smoothstep(0.4, 0.5, b) - smoothstep(0.9, 1.0, b);

    b *= (0.8 + 0.2 * cos(p.y * 200.0 * PI)) * (0.95 + 0.05 * cosTime3);

    float sl=starsLayer(rotate(-0.9, p * 4.0) + fsTime) * 0.1 +
        starsLayer(rotate(0.1, p + fsTime)) +
        starsLayer(rotate(1.0, p * 2.0 + fsTime));
    return vec3(b,b,b) * 0.1 + vec3(sl,sl,sl) * vec3(1.0, 1.2, 1.3) * 0.5;
}

float vignette(vec2 p)
{
    return 1.0 - (p.x * p.x * p.x * p.x  + p.y * p.y * p.y * p.y) * 0.5;
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
    float timeValue=u.localTime*vars.speed;
    float cosTime1=cos(timeValue*.3);
    float cosTime2=cos(timeValue*.5);
    float cosTime3=cos(timeValue*40.0);
    vec2 fsTime=vec2(timeValue*0.1,timeValue*0.1);

    vec3 starColor= stars(input.normPos.xy,fsTime,cosTime1,cosTime2,cosTime3) * smoothstep(0.0, 0.4, length(input.normPos.xy));
    starColor *= vignette(input.normPos.xy);

    vec4 texColor = getColor(inputTex, fsTexture);
#ifdef PRE_MULT
    divideAlpha(texColor);
#endif

    float4 outColor=texColor;
    float blendValue2=u.blendValue;
#ifdef USE_MASK
    blendValue2*=getColor(inputTexMask,input.texMask).a;
#endif
    outColor.rgb += starColor * vars.blendValue * u.nitsScale;
    outColor.rgb=mix(texColor.rgb,outColor.rgb,blendValue2);
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}
