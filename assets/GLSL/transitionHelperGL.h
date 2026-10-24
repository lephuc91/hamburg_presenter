
#ifdef HAS_BACKGROUND_EFFECT

#define getColor(a, b) backgroundEffect(a, b, inputTex1, maskTex, gl_FragCoord.xy)

#else

#define getColor(a, b) texture(a, b)

#endif
