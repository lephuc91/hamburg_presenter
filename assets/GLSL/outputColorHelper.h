
#ifndef HDR_FF

_gconstexpr float4 toYUV_X = float4(0.183, 0.614, 0.062, 0.0);
_gconstexpr float4 toYUV_Y = float4(-0.101, -0.338, 0.439, 0.0);
_gconstexpr float4 toYUV_Z = float4(0.439, -0.399, -0.040, 0.0);

float4 toOutput(float4 internalColor)
{
    processAlpha(internalColor);
#ifdef TO_YUV
    internalColor = float4(
        dot(toYUV_X, internalColor) + 0.0625,
        dot(toYUV_Y, internalColor) + 0.5,
        dot(toYUV_Z, internalColor) + 0.5,
        internalColor.a);
#endif
    return internalColor;
}

#else

#ifdef BT2020_PQ_Output

_gconstexpr float4 toYUV_X = float4(0.226, 0.582, 0.051, 0.0);    // Y row
_gconstexpr float4 toYUV_Y = float4(-0.123, -0.317, 0.439, 0.0);  // U (Cb) row
_gconstexpr float4 toYUV_Z = float4(0.439, -0.404, -0.035, 0.0);  // V (Cr) row

_gconstexpr float4 toRGB_R = float4(1.716651187971268, -0.355670783776392, -0.253366281373660, 0.0);
_gconstexpr float4 toRGB_G = float4(-0.666684351832489, 1.616481236634939, 0.015768545813911, 0.0);
_gconstexpr float4 toRGB_B = float4(0.017639857445311, -0.042770613257809, 0.942103121235474, 0.0);

float4 toGamma(float4 linearColor)
{
    // PQ constants (ST 2084)
    _constexpr float m1 = 2610.0 / 16384.0;  // ≈ 0.1593
    _constexpr float m2 = 2523.0 / 32.0;     // ≈ 78.84375
    _constexpr float c1 = 3424.0 / 4096.0;   // ≈ 0.8359
    _constexpr float c2 = 2413.0 / 128.0;    // ≈ 18.8516
    _constexpr float c3 = 2392.0 / 128.0;    // ≈ 18.6875

    float3 L = max(linearColor.rgb, 0.0);

    float3 Lm1 = pow(L, m1);
    float3 numerator = c1 + c2 * Lm1;
    float3 denominator = 1.0 + c3 * Lm1;

    float3 E = clamp(pow(safeDivide(numerator, denominator), m2), 0.0, 1.0);

    return float4(E, linearColor.a);  // Alpha passthrough
}
#endif  // BT2020_PQ_Output

#ifdef BT2020_HLG_Output
_gconstexpr float4 toYUV_X = float4(0.226, 0.582, 0.051, 0.0);    // Y row
_gconstexpr float4 toYUV_Y = float4(-0.123, -0.317, 0.439, 0.0);  // U (Cb) row
_gconstexpr float4 toYUV_Z = float4(0.439, -0.404, -0.035, 0.0);  // V (Cr) row

_gconstexpr float4 toRGB_R = float4(1.7167, -0.3557, -0.2534, 0.0);
_gconstexpr float4 toRGB_G = float4(-0.6667, 1.6165, 0.0158, 0.0);
_gconstexpr float4 toRGB_B = float4(0.0176, -0.0428, 0.9421, 0.0);

float4 toGamma(float4 linearColor)
{
    // BT.2100 HLG OETF constants
    _constexpr float a = 0.17883277;
    _constexpr float b = 0.28466892;
    _constexpr float c = 0.55991073;
    _constexpr float3 threshold = float3(1.0 / 12.0, 1.0 / 12.0, 1.0 / 12.0);

    float3 L = max(linearColor.rgb, 0.0);

    // Avoid log domain errors
    float3 x = max(12.0 * L - b, 1e-6);

    // Compute both branches
    float3 sqrtPart = sqrt(3.0 * L);
    float3 logPart = a * log(x) + c;

    // Choose appropriate branch
    float3 E = mix(sqrtPart, logPart, step(threshold, L));

    return float4(E, linearColor.a);
}

#endif  // BT2020_HLG_Output

#ifdef BT709_Output
_gconstexpr float4 toYUV_X = float4(0.183, 0.614, 0.062, 0.0);
_gconstexpr float4 toYUV_Y = float4(-0.101, -0.338, 0.439, 0.0);
_gconstexpr float4 toYUV_Z = float4(0.439, -0.399, -0.040, 0.0);

_gconstexpr float4 toRGB_R = float4(3.2406, -1.5372, -0.4986, 0.0);
_gconstexpr float4 toRGB_G = float4(-0.9689, 1.8758, 0.0415, 0.0);
_gconstexpr float4 toRGB_B = float4(0.0557, -0.2040, 1.0570, 0.0);

float4 toGamma(float4 linearColor)
{
    float3 rgb = max(linearColor.rgb, 0.0);
    float3 result =
        mix(4.5 * rgb,                              // Linear segment: V = 4.5 * L
            1.099 * pow(rgb, 0.45) - 0.099,         // Power-law segment: V = 1.099 * L^0.45 - 0.099
            step(float3(0.018, 0.018, 0.018), rgb)  // Condition: L >= 0.018
        );
    return float4(result, linearColor.a);
}
#endif  // BT709_Output

#ifdef sRGB_Output
_gconstexpr float4 toYUV_X = float4(0.183, 0.614, 0.062, 0.0);
_gconstexpr float4 toYUV_Y = float4(-0.101, -0.338, 0.439, 0.0);
_gconstexpr float4 toYUV_Z = float4(0.439, -0.399, -0.040, 0.0);

_gconstexpr float4 toRGB_R = float4(3.2406, -1.5372, -0.4986, 0.0);
_gconstexpr float4 toRGB_G = float4(-0.9689, 1.8758, 0.0415, 0.0);
_gconstexpr float4 toRGB_B = float4(0.0557, -0.2040, 1.0570, 0.0);

float4 toGamma(float4 c)
{
    float3 sRGB =
        mix(c.rgb * 12.92, 1.055 * pow(c.rgb, 1.0 / 2.4) - 0.055, step(float3(0.0031308, 0.0031308, 0.0031308), c.rgb));
    return float4(sRGB, c.a);
}
#endif  // sRGB_Output

float3 HDR2SDR(float3 hdr, float targetWhiteNits, float hdrMaxNits, float shadowGamma, float toeA)
{
    const float EPS = 1e-6;

    // --- 1) Invert Reinhard-style rolloff ---
    float3 sceneNits = hdr * hdrMaxNits / (1.0 - hdr + EPS);

    // --- 2) Invert scale to targetWhiteNits ---
    float3 postToe = sceneNits / targetWhiteNits;

    // --- 3) Invert black-preserving toe ---
    // Compute k from post-toe luma approximation (green channel)
    float postLuma = postToe.y;
    float k = postLuma / (1.0 - postLuma + EPS);

    // Solve for original pre-toe luma
    float preLuma = k * (toeA + EPS) / (1.0 + k * toeA);

    // Compute common offset c
    float c = toeA * (1.0 - preLuma) + EPS;

    // Recover pre-toe values per channel
    float3 preToe = postToe * c / (1.0 - postToe + EPS);

    // --- 4) Invert shadow gamma ---
    float3 sdrLin = pow(preToe, 1.0 / shadowGamma) - EPS;

    // Clamp to valid range (optional, but recommended for shader stability)
    sdrLin = max(0.0, sdrLin);

    return sdrLin;
}

float4 toOutput(float4 internalColor)
{
#ifdef TONE_MAP_SDR
    internalColor.rgb = HDR2SDR(internalColor.rgb, SDR_TARGET_NITS, MAX_NITS, 1.4, 3.);
#else
    internalColor.rgb *= LINEAR_SCALE;
#endif

    float4 linearColor =
        float4(dot(toRGB_R, internalColor), dot(toRGB_G, internalColor), dot(toRGB_B, internalColor), internalColor.a);

    float4 outputColor = toGamma(linearColor);
    outputColor = clamp(outputColor, 0.0, 1.0);

    processAlpha(outputColor);

#ifdef TO_YUV
    outputColor = float4(
        dot(toYUV_X, outputColor) + 0.0625,
        dot(toYUV_Y, outputColor) + 0.5,
        dot(toYUV_Z, outputColor) + 0.5,
        outputColor.a);
#endif
    return outputColor;
}

#endif
