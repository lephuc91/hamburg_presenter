#include "dxEffectIncludes.h"
#include "alpha.h"

static const vec4 std601X = vec4(  0.299 ,  0.587,  0.114, 0.0  );
static const vec4 std601Y = vec4( -0.169 , -0.331,  0.500, 0.0  );
static const vec4 std601Z = vec4(  0.500 , -0.419, -0.081, 0.0  );

static const vec4 std601R = vec4( 1.596027*0.85882394366802,1.164383*0.85882394366802, 0.000000,0.0  );
static const vec4 std601G = vec4(-0.812968*0.85882394366802,1.164383*0.85882394366802,-0.391762*0.85882394366802,0.0  );
static const vec4 std601B = vec4( 0.000000,1.164383*0.85882394366802, 2.017232*0.85882394366802,0.0  );


typedef struct
{
    float hue;
    float saturation;
    float brightness;
    float contrast;
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
    vec4 texColor;
    vec4 yuvIn;
    vec4 yuvOut;

    texColor = getColor(inputTex, input.tex1);
#ifdef PRE_MULT
    divideAlpha(texColor);
#endif
    yuvIn = vec4(dot(std601X, texColor),
                 dot(std601Y, texColor),
                 dot(std601Z, texColor),
                 1.0 );

    yuvOut.g = (yuvIn.r * vars.contrast) + vars.brightness * u.nitsScale;
    float tmp=vars.contrast*vars.saturation;
    float fsCosHue=cos(vars.hue);
    float fsSinHue=sin(vars.hue);
    yuvOut.r = (yuvIn.b * fsCosHue + yuvIn.g * fsSinHue) * tmp;
    yuvOut.b = (yuvIn.g * fsCosHue - yuvIn.b * fsSinHue) * tmp;
    yuvOut.a=yuvIn.a;

    float4 outColor=vec4(dot(std601R, yuvOut),
                  dot(std601G, yuvOut),
                  dot(std601B, yuvOut),
                  texColor.a);

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    outColor.rgb=mix(texColor.rgb,outColor.rgb,blendValue);
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;

}
