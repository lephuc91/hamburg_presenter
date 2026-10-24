#include "dxEffectIncludes.h"

typedef struct
{
    float outlineAmount;
    float colorLevel;
} fxVars;

cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}


static const float coeffs_fx[9] = {-1.0, 0.0, 1.0,-2.0, 0.0, 2.0,-1.0, 0.0, 1.0};

static const float coeffs_fy[9] = {+1.0f, +2.0f, +1.0f,
                                      +0.0f, +0.0f, +0.0f,
                               -1.0f, -2.0f, -1.0f};

static const vec2 offset[9] = {vec2(-1.0f, +1.0f), vec2(+0.0f, +1.0f), vec2(+1.0f, +1.0f),
                                 vec2(-1.0f, +0.0f), vec2(+0.0f, +0.0f), vec2(+1.0f, +0.0f),
    vec2(-1.0f, -1.0f), vec2(+0.0f, -1.0f), vec2(+1.0f, -1.0f)};

vec3 mod289(vec3 x) { return (x - floor(x * (1.0 / 289.0)) * 289.0); }
vec2 mod289(vec2 x)  { return x - floor(x * (1.0 / 289.0)) * 289.0; }
vec3 permute(vec3 x) { return mod289(((x*34.0)+1.0)*x); }

float Snoise (vec2 v)
{
    const vec4 C = vec4(0.211324865405187,    // (3.0-sqrt(3.0))/6.0
                        0.366025403784439,    // 0.5*(sqrt(3.0)-1.0)
                        -0.577350269189626,    // -1.0 + 2.0 * C.x
                        0.024390243902439);    // 1.0 / 41.0

    // First corner
    vec2 i  = floor(v + dot(v, C.yy) );
    vec2 x0 = v -   i + dot(i, C.xx);

    // Other corners
    vec2 i1;
    i1 = (x0.x > x0.y) ? vec2(1.0, 0.0) : vec2(0.0, 1.0);
    vec4 x12 = x0.xyxy + C.xxzz;
    x12.xy -= i1;

    // Permutations
    i = mod289(i); // Avoid truncation effects in permutation
    vec3 p = permute( permute( i.y + vec3(0.0, i1.y, 1.0 ))
                     + i.x + vec3(0.0, i1.x, 1.0 ));

    vec3 m = max(0.5 - vec3(dot(x0,x0), dot(x12.xy,x12.xy), dot(x12.zw,x12.zw)), 0.0);
    m = m*m ;
    m = m*m ;

    // Gradients: 41 points uniformly over a line, mapped onto a diamond.
    // The ring size 17*17 = 289 is close to a multiple of 41 (41*7 = 287)

    vec3 x = 2.0 * fract(p * C.www) - 1.0;
    vec3 h = abs(x) - 0.5;
    vec3 ox = floor(x + 0.5);
    vec3 a0 = x - ox;

    // Normalise gradients implicitly by scaling m
    // Approximation of: m *= inversesqrt( a0*a0 + h*h );
    m *= 1.79284291400159 - 0.85373472095314 * ( a0*a0 + h*h );

    // Compute final noise value at P
    vec3 g;
    g.x  = a0.x  * x0.x  + h.x  * x0.y;
    g.yz = a0.yz * x12.xz + h.yz * x12.yw;
    return 130.0 * dot(m, g);
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
    vec2 pos;
    float y = 0.0f, gx = 0.0f, gy = 0.0f;
    vec2 current = fsTexture*input.texSize;
    for (int i = 0; i < 9; i++)
    {
        pos.x = current.x+offset[i].x;
        pos.y = current.y+offset[i].y;
        y = getColor(inputTex, pos/input.texSize).r;
        gx += (y*coeffs_fx[i]);
        gy += (y*coeffs_fy[i]);
    }
    y = sqrt((gx*gx)+(gy*gy))*vars.outlineAmount;


    vec4 texel=getColor(inputTex,fsTexture);
    float4 outColor = texel*vec4(vars.colorLevel,vars.colorLevel,vars.colorLevel,1.);

    float noise=Snoise(fsTexture*vec2(1024. + u.randomOnce * 512.0, 1024.0 + u.randomOnce * 512.0)) * 1.0;
    y*=noise;
    outColor.r+=y;
    outColor.r=min(255.,outColor.r);
    outColor.g+=y;
    outColor.g=min(255.,outColor.g);
    outColor.b+=y;
    outColor.b=min(255.,outColor.b);
    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    outColor.rgb=mix(texel.rgb,outColor.rgb,blendValue);
    return outColor;
}
