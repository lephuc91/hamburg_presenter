#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float blendValue;
    float speed;
    float iterations;
    float decay;
} fxVars;


// 2x1 hash. Used to jitter the samples.
float hash( vec2 p ){ return fract(sin(dot(p, vec2(41, 289)))*45758.5453); }


// Light offset.
//
// I realized, after a while, that determining the correct light position doesn't help, since
// radial blur doesn't really look right unless its focus point is within the screen boundaries,
// whereas the light is often out of frame. Therefore, I decided to go for something that at
// least gives the feel of following the light. In this case, I normalized the light position
// and rotated it in unison with the camera rotation. Hacky, for sure, but who's checking? :)
vec3 lOff(float fsTime)
{

    vec2 u = sin(vec2(1.57, 0) - fsTime/2.);
    mat2 a = mat2(u.x,u.y, -u.y, u.x);

    vec3 l = normalize(vec3(1.5, 1., -0.5));
    l.xz = mul(a , l.xz);
    l.xy = mul(a , l.xy);

    return l;

}


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
    float fsTime=u.globalTime*vars.speed;

    // Screen coordinates.
    vec2 uv = input.tex1;

    // Radial blur factors.
    //
    // Falloff, as we radiate outwards.
//    float decay = 0.97;
    // Controls the sample density, which in turn, controls the sample spread.
    float density = 0.5;
    // Sample weight. Decays as we radiate outwards.
    float weight = 0.1;

    // Light offset. Kind of fake. See above.
    vec3 l = lOff(fsTime);

    // Offset texture position (uv - .5), offset again by the fake light movement.
    // It's used to set the blur direction (a direction vector of sorts), and is used
    // later to center the spotlight.
    //
    // The range is centered on zero, which allows the accumulation to spread out in
    // all directions. Ie; It's radial.
    vec2 tuv =  uv - .5 - l.xy*.45;

    // Dividing the direction vector above by the sample number and a density factor
    // which controls how far the blur spreads out. Higher density means a greater
    // blur radius.
    vec2 dTuv = tuv*density/vars.iterations;

    // Grabbing a portion of the initial texture sample. Higher numbers will make the
    // scene a little clearer, but I'm going for a bit of abstraction.
    vec4 col = getColor(inputTex, uv.xy)*0.25;

    // Jittering, to get rid of banding. Vitally important when accumulating discontinuous
    // samples, especially when only a few layers are being used.
    uv += dTuv*(hash(uv.xy + fract(fsTime))*2. - 1.);

    // The radial blur loop. Take a texture sample, move a little in the direction of
    // the radial direction vector (dTuv) then take another, slightly less weighted,
    // sample, add it to the total, then repeat the process until done.
    for(float i=0.; i < vars.iterations; i++)
    {
        uv -= dTuv;
        col += getColor(inputTex, uv) * weight;
        weight *= vars.decay;
    }

    // Multiplying the final color with a spotlight centered on the focal point of the radial
    // blur. It's a nice finishing touch... that Passion came up with. If it's a good idea,
    // it didn't come from me. :)
    col *= (1. - dot(tuv, tuv)*.75);

    // Smoothstepping the final color, just to bring it out a bit, then applying some
    // loose gamma correction.
    vec4 blurColor = sqrt(smoothstep(0., 1., col));

    float4 outColor=getColor(inputTex,fsTexture);

    float blendValue2=u.blendValue*vars.blendValue;
#ifdef USE_MASK
    blendValue2*=getColor(inputTexMask,input.texMask).a;
#endif
    mixColor(outColor, outColor, blurColor, blendValue2);

    return outColor;
}
