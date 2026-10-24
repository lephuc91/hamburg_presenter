#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float lightX;
    float lightY;
} fxVars;


cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

// Using a sobel filter to create a normal map and then applying simple lighting.

// This makes the darker areas less bumpy but I like it
#define USE_LINEAR_FOR_BUMPMAP

//#define SHOW_NORMAL_MAP
//#define SHOW_ALBEDO

struct C_Sample
{
    vec3 vAlbedo;
    vec3 vNormal;
};

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



C_Sample SampleMaterial(vec2 vUV,Texture2D inputTex,float2 texSize)
{
    C_Sample result;

    float2 invTexSize=float2(1.0,1.0)/texSize;
    vec4 cSampleNegXNegY = getColor(inputTex, (vUV + (vec2(-1.0, -1.0)*invTexSize) ));
    vec4 cSampleZerXNegY = getColor(inputTex, (vUV + (vec2( 0.0, -1.0)*invTexSize) ));
    vec4 cSamplePosXNegY = getColor(inputTex, (vUV + (vec2( 1.0, -1.0)*invTexSize) ));
#ifdef PRE_MULT
    divideAlpha(cSampleNegXNegY);
    divideAlpha(cSampleZerXNegY);
    divideAlpha(cSamplePosXNegY);
#endif

    vec4 cSampleNegXZerY = getColor(inputTex, (vUV + (vec2(-1.0, 0.0)*invTexSize) ));
    vec4 cSampleZerXZerY = getColor(inputTex, (vUV + (vec2( 0.0, 0.0)*invTexSize) ));
    vec4 cSamplePosXZerY = getColor(inputTex, (vUV + (vec2( 1.0, 0.0)*invTexSize) ));
#ifdef PRE_MULT
    divideAlpha(cSampleNegXZerY);
    divideAlpha(cSampleZerXZerY);
    divideAlpha(cSamplePosXZerY);
#endif

    vec4 cSampleNegXPosY = getColor(inputTex, (vUV + (vec2(-1.0,  1.0)*invTexSize) ));
    vec4 cSampleZerXPosY = getColor(inputTex, (vUV + (vec2( 0.0,  1.0)*invTexSize) ));
    vec4 cSamplePosXPosY = getColor(inputTex, (vUV + (vec2( 1.0,  1.0)*invTexSize) ));
#ifdef PRE_MULT
    divideAlpha(cSampleNegXPosY);
    divideAlpha(cSampleZerXPosY);
    divideAlpha(cSamplePosXPosY);
#endif

    // Scale input to normalize 100 nits (0.01) to ~1.0 for calculations
    const float scale = 100.0; // 100 nits = 0.01 * 100 = 1.0
    vec3 cLSampleNegXNegY = cSampleNegXNegY.rgb * scale;
    vec3 cLSampleZerXNegY = cSampleZerXNegY.rgb * scale;
    vec3 cLSamplePosXNegY = cSamplePosXNegY.rgb * scale;

    vec3 cLSampleNegXZerY = cSampleNegXZerY.rgb * scale;
    vec3 cLSampleZerXZerY = cSampleZerXZerY.rgb * scale;
    vec3 cLSamplePosXZerY = cSamplePosXZerY.rgb * scale;

    vec3 cLSampleNegXPosY = cSampleNegXPosY.rgb * scale;
    vec3 cLSampleZerXPosY = cSampleZerXPosY.rgb * scale;
    vec3 cLSamplePosXPosY = cSamplePosXPosY.rgb * scale;

    // Average samples to get albedo colour
    result.vAlbedo = (cLSampleNegXNegY + cLSampleZerXNegY + cLSamplePosXNegY
                      + cLSampleNegXZerY + cLSampleZerXZerY + cLSamplePosXZerY
                      + cLSampleNegXPosY + cLSampleZerXPosY + cLSamplePosXPosY) / 9.0;

    vec3 vScale = vec3(0.3333,0.3333,0.3333);

#ifdef USE_LINEAR_FOR_BUMPMAP

    float fSampleNegXNegY = dot(cLSampleNegXNegY, vScale);
    float fSampleZerXNegY = dot(cLSampleZerXNegY, vScale);
    float fSamplePosXNegY = dot(cLSamplePosXNegY, vScale);

    float fSampleNegXZerY = dot(cLSampleNegXZerY, vScale);
    float fSamplePosXZerY = dot(cLSamplePosXZerY, vScale);

    float fSampleNegXPosY = dot(cLSampleNegXPosY, vScale);
    float fSampleZerXPosY = dot(cLSampleZerXPosY, vScale);
    float fSamplePosXPosY = dot(cLSamplePosXPosY, vScale);

#else

    float fSampleNegXNegY = dot(cSampleNegXNegY, vScale);
    float fSampleZerXNegY = dot(cSampleZerXNegY, vScale);
    float fSamplePosXNegY = dot(cSamplePosXNegY, vScale);

    float fSampleNegXZerY = dot(cSampleNegXZerY, vScale);
    float fSamplePosXZerY = dot(cSamplePosXZerY, vScale);

    float fSampleNegXPosY = dot(cSampleNegXPosY, vScale);
    float fSampleZerXPosY = dot(cSampleZerXPosY, vScale);
    float fSamplePosXPosY = dot(cSamplePosXPosY, vScale);

#endif

    // Sobel operator - http://en.wikipedia.org/wiki/Sobel_operator

    vec2 vEdge;
    vEdge.x = (fSampleNegXNegY - fSamplePosXNegY) * 0.25
            + (fSampleNegXZerY - fSamplePosXZerY) * 0.5
            + (fSampleNegXPosY - fSamplePosXPosY) * 0.25;

    vEdge.y = (fSampleNegXNegY - fSampleNegXPosY) * 0.25
            + (fSampleZerXNegY - fSampleZerXPosY) * 0.5
            + (fSamplePosXNegY - fSamplePosXPosY) * 0.25;

    float fNormalScale = 10.0;
    result.vNormal = normalize(vec3(vEdge * fNormalScale, 1.0));

    return result;
}



float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    vec2 vUV = input.tex1;

    C_Sample materialSample = SampleMaterial(vUV, inputTex,input.texSize);

    // Random Lighting...

    float fLightHeight = 0.2;
    float fViewHeight = 2.0;

    vec3 vSurfacePos = vec3(vUV, 0.0);

    vec3 vViewPos = vec3(0.5, 0.5, fViewHeight);

    vec3 vLightPos = vec3( vec2(vars.lightX,vars.lightY), fLightHeight);


    vec3 vDirToView = normalize( vViewPos - vSurfacePos );
    vec3 vDirToLight = normalize( vLightPos - vSurfacePos );

    float fNDotL = clamp( dot(materialSample.vNormal, vDirToLight), 0.0, 1.0);
    float fDiffuse = fNDotL;

    vec3 vHalf = normalize( vDirToView + vDirToLight );
    float fNDotH = clamp( dot(materialSample.vNormal, vHalf), 0.0, 1.0);
    float fSpec = pow(fNDotH, 10.0) * fNDotL * 0.5;

    vec3 vResult = materialSample.vAlbedo * fDiffuse + fSpec;

    vResult *= u.nitsScale;

#ifdef SHOW_NORMAL_MAP
    vResult = materialSample.vNormal * 0.5 + 0.5;
#endif

#ifdef SHOW_ALBEDO
    vResult = materialSample.vAlbedo * u.nitsScale;
#endif

    vec4 texel=getColor(inputTex,input.tex1);
#ifdef PRE_MULT
    divideAlpha(texel);
#endif
    float blendValue = u.blendValue;
#ifdef USE_MASK
    blendValue *= float(inputTexMask.Sample(linearSampler, input.texMask).a);
#endif
    float4 outColor = lerp(texel,vec4(vResult,texel.a),blendValue);
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}
