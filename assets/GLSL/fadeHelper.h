// Copyright (c) Renewed Vision, LLC. All rights reserved.
#ifndef FadeHelper_h
#define FadeHelper_h

#define progress_(fadeIn, progress) fadeIn == 1.0 ? progress : 1.0 - progress

#if defined(PRE_MULT)
#define maxRGB_(inColor) vec3(inColor.a, inColor.a, inColor.a)
#else
#define maxRGB_(inColor) vec3(1.0, 1.0, 1.0)
#endif

#define fadeSetAlpha_(outColor, inColor, progress, firstHalfAlphaScale)                       \
    {                                                                                         \
        outColor.a = inColor.a;                                                               \
        multiplyOpacity(outColor, progress < 0.5 ? progress * 2 * firstHalfAlphaScale : 1.0); \
    }

// Fade White
#define fadeWhite_(outColor, inColor, progress, firstHalfAlphaScale)                                             \
    {                                                                                                            \
        outColor.rgb = progress < 0.5 ? maxRGB_(inColor)                                                         \
                                      : inColor.rgb + (maxRGB_(inColor) - inColor.rgb) * (1.0 - progress) * 2.0; \
        fadeSetAlpha_(outColor, inColor, progress, firstHalfAlphaScale);                                         \
    }

#define fadeWhite(outColor, inColor, progress, fadeIn)          \
    {                                                           \
        float prog = fadeIn == 1.0 ? progress : 1.0 - progress; \
        fadeWhite_(outColor, inColor, prog, 1.0);               \
    }

#define fadeWhiteAB(outColor, colorA, colorB, progress)                     \
    {                                                                       \
        vec4 outColorA_;                                                    \
        fadeWhite_(outColorA_, colorA, progress, (1.0 - colorB.a));         \
        vec4 outColorB_;                                                    \
        fadeWhite_(outColorB_, colorB, (1.0 - progress), (1.0 - colorA.a)); \
        addColors(outColor, outColorA_, outColorB_);                        \
    }

// Fade Black
#define fadeBlack_(outColor, inColor, progress, firstHalfAlphaScale)                                              \
    {                                                                                                             \
        outColor.rgb = progress < 0.5 ? vec3(0.0, 0.0, 0.0) : inColor.rgb - inColor.rgb * (1.0 - progress) * 2.0; \
        fadeSetAlpha_(outColor, inColor, progress, firstHalfAlphaScale);                                          \
    }

#define fadeBlack(outColor, inColor, progress, fadeIn)          \
    {                                                           \
        float prog = fadeIn == 1.0 ? progress : 1.0 - progress; \
        fadeBlack_(outColor, inColor, prog, 1.0);               \
    }

#define fadeBlackAB(outColor, colorA, colorB, progress)                     \
    {                                                                       \
        vec4 outColorA_;                                                    \
        fadeBlack_(outColorA_, colorA, progress, (1.0 - colorB.a));         \
        vec4 outColorB_;                                                    \
        fadeBlack_(outColorB_, colorB, (1.0 - progress), (1.0 - colorA.a)); \
        addColors(outColor, outColorA_, outColorB_);                        \
    }

// Fade Bright
#if defined(PRE_MULT)
#define fadeBrightRGB_(inColor, progress) min(inColor.rgb + (1.0 - progress) * 2.0 * inColor.a, inColor.a)
#else
#define fadeBrightRGB_(inColor, progress) inColor.rgb + (1.0 - progress) * 2.0
#endif

#define fadeBright_(outColor, inColor, progress, firstHalfAlphaScale)                         \
    {                                                                                         \
        outColor.rgb = progress < 0.5 ? maxRGB_(inColor) : fadeBrightRGB_(inColor, progress); \
        fadeSetAlpha_(outColor, inColor, progress, firstHalfAlphaScale);                      \
    }

#define fadeBright(outColor, inColor, progress, fadeIn)         \
    {                                                           \
        float prog = fadeIn == 1.0 ? progress : 1.0 - progress; \
        fadeBright_(outColor, inColor, prog, 1.0);              \
    }

#define fadeBrightAB(outColor, colorA, colorB, progress)                     \
    {                                                                        \
        vec4 outColorA_;                                                     \
        fadeBright_(outColorA_, colorA, progress, (1.0 - colorB.a));         \
        vec4 outColorB_;                                                     \
        fadeBright_(outColorB_, colorB, (1.0 - progress), (1.0 - colorA.a)); \
        addColors(outColor, outColorA_, outColorB_);                         \
    }

// Fade Dark
#if defined(PRE_MULT)
#define fadeDarkRGBAdjust_(progress, alpha) (1.0 - progress) * 2.0 * alpha
#else
#define fadeDarkRGBAdjust_(progress, alpha) (1.0 - progress) * 2.0
#endif

#define fadeDark_(outColor, inColor, progress, firstHalfAlphaScale)                                                  \
    {                                                                                                                \
        outColor.rgb = progress < 0.5 ? vec3(0.0, 0.0, 0.0) : inColor.rgb - fadeDarkRGBAdjust_(progress, inColor.a); \
        fadeSetAlpha_(outColor, inColor, progress, firstHalfAlphaScale);                                             \
    }

#define fadeDark(outColor, inColor, progress, fadeIn)           \
    {                                                           \
        float prog = fadeIn == 1.0 ? progress : 1.0 - progress; \
        fadeDark_(outColor, inColor, prog, 1.0);                \
    }

#define fadeDarkAB(outColor, colorA, colorB, progress)                     \
    {                                                                      \
        vec4 outColorA_;                                                   \
        fadeDark_(outColorA_, colorA, progress, (1.0 - colorB.a));         \
        vec4 outColorB_;                                                   \
        fadeDark_(outColorB_, colorB, (1.0 - progress), (1.0 - colorA.a)); \
        addColors(outColor, outColorA_, outColorB_);                       \
    }

// Color Burn (note: colors passed in must be premultiplied)
#define colorBurn_(outColor, inColor, burnColor, progress)                                      \
    {                                                                                           \
        outColor = inColor;                                                                     \
        outColor += (progress < 0.5 ? progress : 1.0 - progress) * 2.0 * burnColor * inColor.a; \
        outColor = min(outColor, vec4(inColor.a, inColor.a, inColor.a, inColor.a));             \
        outColor *= progress < 0.5 ? progress * 2 : 1.0;                                        \
    }

#define colorBurn(outColor, inColor, burnColor, progress, fadeIn) \
    {                                                             \
        float prog = fadeIn == 1.0 ? progress : 1.0 - progress;   \
        colorBurn_(outColor, inColor, burnColor, prog);           \
    }

#define colorBurnAB(outColor, colorA, colorB, burnColor, progress)   \
    {                                                                \
        vec4 outColorA_;                                             \
        colorBurn_(outColorA_, colorA, burnColor, progress);         \
        vec4 outColorB_;                                             \
        colorBurn_(outColorB_, colorB, burnColor, (1.0 - progress)); \
        outColor = outColorA_ + outColorB_;                          \
    }

#endif  // FadeHelper_h
