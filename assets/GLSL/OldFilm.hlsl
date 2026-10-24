#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float sepiaValue;
    float noiseValue;
    float scratchValue;
    float radius;
    float frequency;
    float intensity;
} fxVars;


typedef struct
{
    float4 position : SV_POSITION;
    float2 normPos : POSITION;
    float2 tex1 : TEXCOORD0;
    float2 tex2 : TEXCOORD1;
    float2 texMask : TEXCOORD2;
    float2 texSize : TEXCOORD3;
    float floatParam0 : PSIZE0;
    float floatParam1 : PSIZE1;
    float floatParam2 : PSIZE2;
} fsVertexOut;

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


vec3 Overlay(vec3 src, vec3 dst )
{
    return vec3( (dst.x <= 0.5) ? (2.0 * src.x * dst.x) : (1.0 - 2.0 * (1.0 - dst.x) * (1.0 - src.x)),
                (dst.y <= 0.5) ? (2.0 * src.y * dst.y) : (1.0 - 2.0 * (1.0 - dst.y) * (1.0 - src.y)),
                (dst.z <= 0.5) ? (2.0 * src.z * dst.z) : (1.0 - 2.0 * (1.0 - dst.z) * (1.0 - src.z)) );
}

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

fsVertexOut vertexShader(fxShaderVerts input)
{
    fsVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy * vec2(.5,.5f) + vec2(.5,.5);
    output.tex2 = input.tex1;

    vec2 tmp = input.tex1; //0,0 -> 1,1
    tmp-=.5;    //-.5,-.5 -> .5,.5
    tmp*=2.;    //-1,-1 -> 1,1
    tmp/=(vars.intensity+1.);

    float dx=u.globalTime*4.*(vars.frequency+.1);

    tmp.x+=noise(float2(dx,-dx))*(vars.intensity*.5);
    tmp.y-=noise(float2(-dx,dx))*(vars.intensity*.5);


    tmp*=.5;
    tmp+=.5;
    output.tex1=tmp;

    output.texMask = input.texMask;
    output.texSize = u.texSize;
    return output;
}


float4 pixelShader(fsVertexOut input) : SV_TARGET
{
    float fsOuterRadius=2.0;
    float fsInnerRadius=fsOuterRadius*vars.radius;

#ifdef LINEAR_16
    vec3 sepia = vec3(0.248, 0.281, 0.098);
#else
    vec3 sepia = vec3(0.439216, 0.258824, 0.078431);
#endif

    // Convert to grayscale
    vec2 texCoord=fsTexture;
    vec4 texel = getColor(inputTex,texCoord);
#ifdef PRE_MULT
    divideAlpha(texel);
#endif
    float gray = (texel.r + texel.g + texel.b) / 3.0;
    vec3 grayscale = vec3(gray,gray,gray);

    // Appy sepia overlay
    vec3 finalColour = Overlay(sepia, grayscale);

    // Lerp final sepia colour
    finalColour = grayscale + vars.sepiaValue * (finalColour - grayscale);

    // Add noise
    float noise = Snoise(texCoord * vec2(1024.0 + u.random * 512.0, 1024.0 + u.random * 512.0)) * 0.5;
    finalColour += (noise * vars.noiseValue) * u.nitsScale;

    // Apply scratches

    if ( u.random < vars.scratchValue )
    {
        // Pick a random spot to show scratches
        float dist = 1.0 / vars.scratchValue;

        float d = distance(input.tex1, vec2(u.random * dist, u.random * dist));
        if ( d < 0.4 )
        {
            // Generate the scratch
            float xPeriod = 8.0;
            float yPeriod = 1.0;
            float pi = 3.141592;
            float phase = u.localTime*pi;
            float turbulence = Snoise(input.tex1 * 2.5);
            float vScratch = 0.5 + (sin(((input.tex1.x * xPeriod + input.tex1.y * yPeriod + turbulence)) * pi + phase) * 0.5);
            vScratch = clamp((vScratch * 10000.0) + 0.35, 0.0, 1.0);

            finalColour.xyz *= vScratch;
            // finalColour = vec3(0,0,1);
        }
    }

    float dist=distance(input.normPos,vec2(0.0,0.0));
    float darken=clamp((fsOuterRadius-dist)/(fsOuterRadius-fsInnerRadius),0.0,1.0);

    float4 outColor;
    outColor.rgb=darken*finalColour.rgb;
    outColor.a=texel.a;
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif

    float blendValue = u.blendValue;
#ifdef USE_MASK
    blendValue *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    vec4 inColor = getColor(inputTex, input.tex2);
    mixColor(outColor, inColor, outColor, blendValue);

    return outColor;
}
