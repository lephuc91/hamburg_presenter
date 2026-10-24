#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float cells;
    int gridSize;
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
    float4 outColor;
    vec4 texel=getColor(inputTex,fsTexture);
    float rows=vars.cells;
    float columns=vars.cells;
    vec2 xy;
    if(vars.gridSize!=0)
    {
        xy=input.tex1*vec2(float(columns),float(rows));
        xy=fract(xy);
        vec2 pos=vec2(3.1415926535,3.1415926535)*xy;
        vec2 dim=sqrt(min(vec2(1.0,1.0),sin(pos)*vec2(22.0-float(vars.gridSize),22.0-float(vars.gridSize))));
        outColor = getColor(inputTex, xy);
        multiplyOpacity(outColor, dim.x * dim.y);
    }
    else
    {
        xy=input.tex1*vec2(columns,rows);
        xy=fract(xy);
        outColor = getColor(inputTex,xy);
    }

    float blendValue = u.blendValue;
#ifdef USE_MASK
    blendValue *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    mixColor(outColor, texel, outColor, blendValue);

    return outColor;
}
