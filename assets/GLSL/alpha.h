// Copyright (c) Renewed Vision, LLC. All rights reserved.
#ifndef Alpha_h
#define Alpha_h

// How alpha should be applied to a premultiplied color so as to not alter the color.
#define multiplyOpacityPremultiplied(color, alpha) color *= alpha;

// With premultiplied color the rgb values should not exceed the alpha.  If they do then this will preserve the opacity
// at the expense of distorting the color.  If this is not done then rgb values > a will preserve their color at the
// expense of losing opacity and become opaque.
#define limitRGB(color) color.rgb = min(color.rgb, vec3(color.a, color.a, color.a));

// For safe conversion between straight and premultiplied alpha.
#define divideAlpha(color) color.rgb = ((0.0 < color.a && color.a < 1.0) ? color.rgb / color.a : color.rgb);
#define multiplyAlpha(color) \
    color.rgb *= color.a;    \
    limitRGB(color);

// Used by input, output, and snapshot shaders to convert to and from the external alpha type and render engine's
// internal type.
#if defined(FORCE_ALPHA)
#define processAlpha(color) color.a = 1.0;
#elif defined(MULTIPLY_ALPHA) && !defined(DIVIDE_ALPHA)
#define processAlpha(color) multiplyAlpha(color)
#elif defined(DIVIDE_ALPHA) && !defined(MULTIPLY_ALPHA)
#define processAlpha(color) divideAlpha(color)
#elif defined(LIMIT_RGB)
#define processAlpha(color) limitRGB(color)
#else
#define processAlpha(color)
#endif

// Allows shaders to apply opacity without distorting color depending on if the render engine is using straight or
// premultiplied alpha.
#if defined(PRE_MULT)
#define multiplyOpacity(color, alpha) multiplyOpacityPremultiplied(color, alpha)
#else
#define multiplyOpacity(color, alpha) color.a *= alpha;
#endif

// Allows shaders to mix colors with alpha without distorting color depending on if the render engine is using straight
// or premultiplied alpha.  It needs to be done in premultiplied color space.
#if defined(PRE_MULT)
#define mixColor(blendedColor, colorA, colorB, blend) blendedColor = colorA + (colorB - colorA) * blend;
#else
#define mixColor(blendedColor, colorA, colorB, blend)         \
    {                                                         \
        vec4 colorA_ = colorA;                                \
        vec4 colorB_ = colorB;                                \
        colorA_.rgb *= colorA_.a;                             \
        colorB_.rgb *= colorB_.a;                             \
        blendedColor = colorA_ + (colorB_ - colorA_) * blend; \
        blendedColor.rgb /= blendedColor.a;                   \
    }
#endif

// Allows shaders to add colors with alpha without distorting color depending on if the render engine is using straight
// or premultiplied alpha.  It needs to be done in premultiplied color space.
#if defined(PRE_MULT)
#define addColors(outColor, colorA, colorB) outColor = colorA + colorB;
#else
#define addColors(outColor, colorA, colorB) \
    {                                       \
        vec4 colorA_ = colorA;              \
        vec4 colorB_ = colorB;              \
        colorA_.rgb *= colorA_.a;           \
        colorB_.rgb *= colorB_.a;           \
        outColor = colorA_ + colorB_;       \
        outColor.rgb /= outColor.a;         \
    }
#endif

// Standard layering of a color with alpha over another which must be done in premultiplied color space.  Same as the
// premultiplied blend function / equation in the ssGfxDevice subclasses.
#if defined(PRE_MULT)
#define blendColorSrcOverDst(outColor, src, dst) outColor = dst * (1.0 - src.a) + src;
#else
#define blendColorSrcOverDst(outColor, src, dst) \
    {                                            \
        vec4 src_ = src;                         \
        vec4 dst_ = dst;                         \
        src_.rgb *= src.a;                       \
        dst_.rgb *= dst.a;                       \
        outColor = dst_ * (1.0 - src_.a) + src_; \
        outColor.rgb /= outColor.a;              \
    }
#endif

#if defined(SRC_ALPHA_PREMULTIPLIED)
#define toStraightAlpha(color) divideAlpha(color)
#else
#define toStraightAlpha(color)
#endif

#if defined(SRC_ALPHA_STRAIGHT)
#define toPremultipliedAlpha(color) multiplyAlpha(color)
#else
#define toPremultipliedAlpha(color)
#endif

#endif  // Alpha_h
