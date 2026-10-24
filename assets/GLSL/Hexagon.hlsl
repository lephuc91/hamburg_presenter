#include "dxEffectIncludes.h"

typedef struct
{
    float hexSize;
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

static const float PI = 3.14159265359;
static const float TAU = 2.0*PI;
static const float deg30 = TAU/12.0;

// http://www.gamedev.net/page/resources/_/technical/game-programming/coordinates-in-hexagon-based-tile-maps-r1800
// nearest hexagon sampling, not quite sure if it's correct

vec2 nearestHex(float s, vec2 st)
{
    float h = sin(deg30)*s;
    float r = cos(deg30)*s;
    float m = h/r;

    vec2 sect = st/vec2(2.0*r, h+s);
    vec2 sectPxl = mod(st, vec2(2.0*r, h+s));

    float aSection = mod(floor(sect.y), 2.0);

    vec2 coord = floor(sect);
    if(aSection > 0.0)
    {
        if(sectPxl.y < (h-sectPxl.x*m))
        {
            coord -= 1.0;
        }
        else if(sectPxl.y < (-h + sectPxl.x*m))
        {
            coord.y -= 1.0;
        }

    }
    else
    {
        if(sectPxl.x > r)
        {
            if(sectPxl.y < (2.0*h - sectPxl.x * m))
            {
                coord.y -= 1.0;
            }
        }
        else
        {
            if(sectPxl.y < (sectPxl.x*m))
            {
                coord.y -= 1.0;
            }
            else
            {
                coord.x -= 1.0;
            }
        }
    }

    float xoff = mod(coord.y, 2.0)*r;
    return vec2(coord.x*2.0*r-xoff, coord.y*(h+s))+vec2(r*2.0, s);
}

float hexDist(vec2 a, vec2 b)
{
    vec2 p = abs(b-a);
    float s = sin(deg30);
    float c = cos(deg30);

    float diagDist = s*p.x + c*p.y;
    return max(diagDist, p.x)/c;
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
    float s = input.texSize.x/((110-vars.hexSize)*4.0);
    vec2 nearest = nearestHex(s, input.tex1*input.texSize);
    vec4 texel = getColor(inputTex, nearest/input.texSize);
    vec4 texColor=getColor(inputTex,fsTexture);
    float dist = hexDist(input.tex1*input.texSize, nearest);

    float interiorSize = s;
    float interior = 1.0 - smoothstep(interiorSize-1.0, interiorSize, dist);
    //fragColor = vec4(dist);
    float4 outColor = vec4(texel.rgb*interior, texColor.a);

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    outColor.rgb=mix(texColor.rgb,outColor.rgb,blendValue);

    return outColor;
}
