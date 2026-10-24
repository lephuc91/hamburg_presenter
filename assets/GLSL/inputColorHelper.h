
#ifdef AdobeRGB1998
_gconstexpr float4 toXYZ_R = float4(0.5767, 0.1856, 0.1882, 0.0);
_gconstexpr float4 toXYZ_G = float4(0.2973, 0.6274, 0.0753, 0.0);
_gconstexpr float4 toXYZ_B = float4(0.0270, 0.0707, 0.9913, 0.0);

_gconstexpr float4 profileToRGB_R = float4(1.398283, -0.398283064, 0.0, 0.0);
_gconstexpr float4 profileToRGB_G = float4(0.0, 1.0, 0.0, 0.0);
_gconstexpr float4 profileToRGB_B = float4(0.0, -0.0429382771, 1.04293835, 0.0);

_gconstexpr float4 profileTo2020_R = float4(0.9389, 0.0369, 0.0242, 0.0);
_gconstexpr float4 profileTo2020_G = float4(-0.0172, 1.0145, 0.0027, 0.0);
_gconstexpr float4 profileTo2020_B = float4(0.0058, -0.0156, 1.0098, 0.0);

#ifdef FULL_RANGE
_gconstexpr float4 yuv2R = float4(1.406, 1.0, 0.0, 0.0);
_gconstexpr float4 yuv2G = float4(-0.6657, 1.0, -0.2213, 0.0);
_gconstexpr float4 yuv2B = float4(0.0, 1.0, 1.85, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, 0.0, -0.5, 0.0);
#else
_gconstexpr float4 yuv2R = float4(1.5982, 1.164383, 0.0, 0.0);
_gconstexpr float4 yuv2G = float4(-0.7578, 1.164383, -0.2518, 0.0);
_gconstexpr float4 yuv2B = float4(0.0, 1.164383, 2.1035, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, -0.0625, -0.5, 0.0);
#endif  // FULL_RANGE
#endif

#ifdef DISPLAY_P3
_gconstexpr float4 toXYZ_R = float4(0.5151, 0.2412, 0.1743, 0.0);
_gconstexpr float4 toXYZ_G = float4(0.2918, 0.6922, 0.0419, 0.0);
_gconstexpr float4 toXYZ_B = float4(0.0416, 0.0689, 0.9515, 0.0);

_gconstexpr float4 profileToRGB_R = float4(1.2249, -0.2247, 0.0, 0.0);
_gconstexpr float4 profileToRGB_G = float4(-0.0420, 1.0419, 0.0, 0.0);
_gconstexpr float4 profileToRGB_B = float4(-0.0197, -0.0786, 1.0979, 0.0);

_gconstexpr float4 profileTo2020_R = float4(0.8951, 0.0762, 0.0287, 0.0);
_gconstexpr float4 profileTo2020_G = float4(-0.0146, 1.0082, 0.0064, 0.0);
_gconstexpr float4 profileTo2020_B = float4(0.0052, -0.0136, 1.0084, 0.0);

#ifdef FULL_RANGE
_gconstexpr float4 yuv2R = float4(1.5748, 1.0, 0.0, 0.0);
_gconstexpr float4 yuv2G = float4(-0.4681, 1.0, -0.1873, 0.0);
_gconstexpr float4 yuv2B = float4(0.0, 1.0, 1.8556, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, 0.0, -0.5, 0.0);
#else
_gconstexpr float4 yuv2R = float4(1.7927, 1.164383, 0.0, 0.0);
_gconstexpr float4 yuv2G = float4(-0.5329, 1.164383, -0.2132, 0.0);
_gconstexpr float4 yuv2B = float4(0.0, 1.164383, 2.1124, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, -0.0625, -0.5, 0.0);
#endif  // FULL_RANGE

#endif

#ifdef XYZ
_gconstexpr float4 toXYZ_R = float4(1., 0., 0., 0.0);
_gconstexpr float4 toXYZ_G = float4(0., 1., 0., 0.0);
_gconstexpr float4 toXYZ_B = float4(0., 0., 1., 0.0);

#ifdef FULL_RANGE
// full range values from wikipedia https://en.wikipedia.org/wiki/YCbCr#ITU-R_BT.709_conversion
_gconstexpr float4 yuv2R = float4(1.5748, 1.0, 0.0, 0.0);
_gconstexpr float4 yuv2G = float4(-0.468124, 1.0, -0.187324, 0.0);
_gconstexpr float4 yuv2B = float4(0.0, 1.0, 1.8556, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, 0.0, -0.5, 0.0);  // Cr, Y, Cb offsets
#else
_gconstexpr float4 yuv2R = float4(1.793, 1.164383, 0.000000, 0.0);
_gconstexpr float4 yuv2G = float4(-0.534, 1.164383, -0.213, 0.0);
_gconstexpr float4 yuv2B = float4(0.000000, 1.164383, 2.115, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, -0.0625, -0.5, 0.0);
#endif  // FULL_RANGE

_gconstexpr float4 profileToRGB_R = float4(1.0, 0.0, 0.0, 0.0);
_gconstexpr float4 profileToRGB_G = float4(0.0, 1.0, 0.0, 0.0);
_gconstexpr float4 profileToRGB_B = float4(0.0, 0.0, 1.0, 0.0);

#endif

#ifdef PRO_PHOTO_RGB
_gconstexpr float4 toXYZ_R = float4(0.7977, 0.1352, 0.0313, 0.0);
_gconstexpr float4 toXYZ_G = float4(0.2880, 0.7119, 0.0001, 0.0);
_gconstexpr float4 toXYZ_B = float4(0.0000, 0.0000, 0.8249, 0.0);

_gconstexpr float4 profileToRGB_R = float4(2.03407574, -0.72733432, -0.306741565, 0.0);
_gconstexpr float4 profileToRGB_G = float4(-0.228813201, 1.23173022, -0.00291692792, 0.0);
_gconstexpr float4 profileToRGB_B = float4(-0.00856976956, -0.153286651, 1.1618564, 0.0);

_gconstexpr float4 profileTo2020_R = float4(0.6816, 0.2790, 0.0394, 0.0);
_gconstexpr float4 profileTo2020_G = float4(-0.0758, 1.0760, 0.0001, 0.0);
_gconstexpr float4 profileTo2020_B = float4(0.0162, -0.0401, 1.0238, 0.0);

#ifdef FULL_RANGE
_gconstexpr float4 yuv2R = float4(1.424, 1.0, 0.0, 0.0);
_gconstexpr float4 yuv2G = float4(-0.5769, 1.0, -0.0028, 0.0);
_gconstexpr float4 yuv2B = float4(0.0, 1.0, 1.998, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, 0.0, -0.5, 0.0);
#else
_gconstexpr float4 yuv2R = float4(1.6192, 1.164383, 0.0, 0.0);
_gconstexpr float4 yuv2G = float4(-0.6567, 1.164383, -0.0032, 0.0);
_gconstexpr float4 yuv2B = float4(0.0, 1.164383, 2.2735, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, -0.0625, -0.5, 0.0);
#endif
#endif

#ifdef BT2020
_gconstexpr float4 toXYZ_R = float4(0.6369580483012911, 0.1446169035862084, 0.1688809751641721, 0.0);
_gconstexpr float4 toXYZ_G = float4(0.2627002120112670, 0.6779980715188710, 0.05930171646986195, 0.0);
_gconstexpr float4 toXYZ_B = float4(0.00000000000000005, 0.02807269304908744, 1.060985057710791, 0.0);

#ifdef FULL_RANGE
_gconstexpr float4 yuv2R = float4(1.4746, 1.0, 0.0, 0.0);
_gconstexpr float4 yuv2G = float4(-0.5714, 1.0, -0.1647, 0.0);
_gconstexpr float4 yuv2B = float4(0.0, 1.0, 1.8814, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, 0.0, -0.5, 0.0);  // Cr, Y, Cb offsets
#else
_gconstexpr float4 yuv2R = float4(1.6836, 1.1678, 0.0, 0.0);
_gconstexpr float4 yuv2G = float4(-0.5591, 1.1678, -0.1879, 0.0);
_gconstexpr float4 yuv2B = float4(0.0, 1.1678, 2.1482, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, -0.0625, -0.5, 0.0);
#endif  // FULL_RANGE

_gconstexpr float4 profileToRGB_R = float4(1.6605, -0.5876, -0.0728, 0.0);
_gconstexpr float4 profileToRGB_G = float4(-0.1246, 1.1329, -0.0083, 0.0);
_gconstexpr float4 profileToRGB_B = float4(-0.0182, -0.1006, 1.1187, 0.0);

_gconstexpr float4 profileTo2020_R = float4(1.0, 0.0, 0.0, 0.0);
_gconstexpr float4 profileTo2020_G = float4(0.0, 1.0, 0.0, 0.0);
_gconstexpr float4 profileTo2020_B = float4(0.0, 0.0, 1.0, 0.0);
#endif  // BT2020

#ifdef BT709
_gconstexpr float4 toXYZ_R = float4(0.4124, 0.3576, 0.1805, 0.0);
_gconstexpr float4 toXYZ_G = float4(0.2126, 0.7152, 0.0722, 0.0);
_gconstexpr float4 toXYZ_B = float4(0.0193, 0.1192, 0.9505, 0.0);

#ifdef FULL_RANGE
// full range values from wikipedia https://en.wikipedia.org/wiki/YCbCr#ITU-R_BT.709_conversion
_gconstexpr float4 yuv2R = float4(1.5748, 1.0, 0.0, 0.0);
_gconstexpr float4 yuv2G = float4(-0.468124, 1.0, -0.187324, 0.0);
_gconstexpr float4 yuv2B = float4(0.0, 1.0, 1.8556, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, 0.0, -0.5, 0.0);  // Cr, Y, Cb offsets
#else
_gconstexpr float4 yuv2R = float4(1.793, 1.164383, 0.000000, 0.0);
_gconstexpr float4 yuv2G = float4(-0.534, 1.164383, -0.213, 0.0);
_gconstexpr float4 yuv2B = float4(0.000000, 1.164383, 2.115, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, -0.0625, -0.5, 0.0);
#endif  // FULL_RANGE

_gconstexpr float4 profileToRGB_R = float4(1.0, 0.0, 0.0, 0.0);
_gconstexpr float4 profileToRGB_G = float4(0.0, 1.0, 0.0, 0.0);
_gconstexpr float4 profileToRGB_B = float4(0.0, 0.0, 1.0, 0.0);
#endif  // BT709

#ifdef BT601
_gconstexpr float4 toXYZ_R = float4(0.4306, 0.3415, 0.1784, 0.0);
_gconstexpr float4 toXYZ_G = float4(0.2220, 0.7067, 0.0713, 0.0);
_gconstexpr float4 toXYZ_B = float4(0.0202, 0.1296, 0.9393, 0.0);

#ifdef FULL_RANGE
_gconstexpr float4 yuv2R = float4(1.402, 1., 0.0, 0.0);
_gconstexpr float4 yuv2G = float4(-0.714136, 1., -0.344136, 0.0);
_gconstexpr float4 yuv2B = float4(0.000000, 1., 1.772, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, 0.0, -0.5, 0.0);
#else
_gconstexpr float4 yuv2R = float4(1.596, 1.164383, 0.0, 0.0);
_gconstexpr float4 yuv2G = float4(-0.813, 1.164383, -0.391, 0.0);
_gconstexpr float4 yuv2B = float4(0.0, 1.164383, 2.018, 0.0);
_gconstexpr float4 stdbias = float4(-0.5, -0.0625, -0.5, 0.0);
#endif  // FULL_RANGE

_gconstexpr float4 profileToRGB_R = float4(0.9786, 0.0195, 0.0019, 0.0);
_gconstexpr float4 profileToRGB_G = float4(0.0058, 0.9942, 0.0000, 0.0);
_gconstexpr float4 profileToRGB_B = float4(0.0000, 0.0058, 0.9942, 0.0);

_gconstexpr float4 profileTo2020_R = float4(0.6369580, 0.3205400, 0.0426020, 0.0);
_gconstexpr float4 profileTo2020_G = float4(0.0690870, 0.9195440, 0.0113690, 0.0);
_gconstexpr float4 profileTo2020_B = float4(0.0163940, 0.0880110, 0.8955950, 0.0);
#endif  // BT601

float3 lessThan(float3 a, float3 b)
{
    float3 retVal = float3(0.0, 0.0, 0.0);
    if (a.x < b.x)
        retVal.x = 1.0;
    if (a.y < b.y)
        retVal.y = 1.0;
    if (a.z < b.z)
        retVal.z = 1.0;
    return retVal;
}

#ifdef TF_ARIB_STD_B67
float4 toLinear(float4 colorIn)
{
    _constexpr float a = 0.17883277;
    _constexpr float b = 0.28466892;
    _constexpr float c = 0.55991073;

    float3 val_low = (colorIn.rgb * colorIn.rgb) / 3.0;
    float3 val_high = (exp((colorIn.rgb - c) / a) + b) / 12.0;

    float3 mask = step(float3(0.5, 0.5, 0.5), colorIn.rgb);  // 0 if < 0.5, 1 if >= 0.5
    float3 linearRGB = mix(val_low, val_high, mask);

    return float4(linearRGB, colorIn.a);
}
#endif

#ifdef TF_SMPTE428
float4 toLinear(float4 smpte428)
{
    _constexpr float gamma = 2.6;  // SMPTE ST 428-1 specifies a pure 2.6 gamma
    float3 linear_rgb = pow(smpte428.rgb, gamma);
    return float4(linear_rgb, smpte428.a);
}
#endif

#ifdef TF_SMPTE2084
float4 toLinear(float4 pq)
{
    _constexpr float m1 = 0.1593017578125;  // 2610 / 16384
    _constexpr float m2 = 78.84375;         // 2523 / 32
    _constexpr float c1 = 0.8359375;        // 3424 / 4096
    _constexpr float c2 = 18.8515625;       // 2413 / 128
    _constexpr float c3 = 18.6875;          // 2392 / 128

    _constexpr float EPS = 1e-6;  // small safety margin

    float3 Y = pow(pq.rgb, 1.0 / m2);

    float3 denom = max(c2 - c3 * Y, EPS);  // clamp denominator
    float3 num = max(Y - c1, 0.0);

    float3 linear_rgb = pow(num / denom, 1.0 / m1);

    return float4(linear_rgb, pq.a);
}
#endif

#ifdef TF_sRGB
float4 toLinear(float4 c)
{
    float3 low = c.rgb / 12.92;
    float3 high = pow((c.rgb + 0.055) / 1.055, float3(2.4, 2.4, 2.4));
    float3 linearRGB = mix(low, high, step(float3(0.04045, 0.04045, 0.04045), c.rgb));
    return float4(linearRGB, c.a);
}
#endif

#ifdef TF_BT2020
float4 toLinear(float4 c)
{
    float3 low = c.rgb / 4.5;
    _constexpr float exp = 1.0 / 0.45;
    float3 high = pow((c.rgb + 0.099) / 1.099, float3(exp, exp, exp));
    float3 linearRGB = mix(low, high, step(float3(0.081, 0.081, 0.081), c.rgb));
    return float4(linearRGB, c.a);
}
#endif

#ifdef TF_PRO_PHOTO_RGB
float4 toLinear(float4 c)
{
    return float4(pow(c.rgb, 1.8), c.a);
}
#endif

#ifdef TF_Gamma_22
float4 toLinear(float4 c)
{
    return float4(pow(c.rgb, 2.2), c.a);
}
#endif

#ifdef TF_Gamma_28
float4 toLinear(float4 c)
{
    return float4(pow(c.rgb, 2.8), c.a);
}
#endif

#ifdef TF_SMPTE170M
float4 toLinear(float4 c)
{
    float3 below = c.rgb / 4.5;
    float3 above = pow((c.rgb + 0.099) / 1.099, float3(1.0 / 0.45, 1.0 / 0.45, 1.0 / 0.45));

    float3 mask = step(float3(0.081, 0.081, 0.081), c.rgb);  // 0 if less than 0.081, 1 otherwise
    float3 linearRGB = mix(below, above, mask);

    return float4(linearRGB, c.a);
}
#endif

#ifdef TF_SMPTE240M
float4 toLinear(float4 c)
{
    float3 below = c.rgb / 4.0;
    float3 above = pow((c.rgb + 0.1115) / 1.1115, float3(1.0 / 0.45, 1.0 / 0.45, 1.0 / 0.45));

    float3 mask = step(float3(0.0912, 0.0912, 0.0912), c.rgb);  // 0 if less, 1 if greater or equal
    float3 linearRGB = mix(below, above, mask);

    return float4(linearRGB, c.a);
}
#endif

#ifdef TF_BT1361_ECG
float4 toLinear(float4 c)
{
    float3 val_neg = -(c.rgb / 4.0);
    float3 val_mid = pow((c.rgb + 0.1115) / 1.1115, float3(1.0 / 0.45, 1.0 / 0.45, 1.0 / 0.45));
    float3 val_pos = c.rgb / 4.0;

    float3 mask_neg = step(c.rgb, float3(-0.0912, -0.0912, -0.0912));  // 1 where c.rgb <= -0.0912
    float3 mask_pos = step(float3(0.0912, 0.0912, 0.0912), c.rgb);     // 1 where c.rgb >= 0.0912
    float3 mask_mid = float3(1.0, 1.0, 1.0) - mask_neg - mask_pos;     // 1 where -0.0912 < c.rgb < 0.0912

    float3 linearRGB = val_neg * mask_neg + val_mid * mask_mid + val_pos * mask_pos;

    return float4(linearRGB, c.a);
}
#endif

#ifdef TF_LINEAR
float4 toLinear(float4 c)
{
    return c;  // No transformation needed
}
#endif

#ifdef TF_LOG
float4 toLinear(float4 c)
{
    float3 linearRGB = (pow(10.0, c.rgb) - 1.0) / 100.0;
    return float4(linearRGB, c.a);
}
#endif

#ifdef TF_LOGSQRT
float4 toLinear(float4 c)
{
    float3 linearRGB = (pow(10.0, c.rgb * c.rgb) - 1.0) / 100.0;
    return float4(linearRGB, c.a);
}
#endif

#ifdef TF_BT709
float4 toLinear(float4 c)
{
    float3 rgb = c.rgb;
    float3 result =
        mix(rgb / 4.5,                              // Linear segment: L = V / 4.5
            pow((rgb + 0.099) / 1.099, 2.2222),     // Power-law segment: L = ((V + 0.099) / 1.099)^(1/0.45)
            step(float3(0.081, 0.081, 0.081), rgb)  // Condition: V >= 0.081
        );
    return float4(result, c.a);
}
#endif

// linear -> sRGB gamma
float4 toGamma(float4 c)
{
    float3 sRGB =
        mix(c.rgb * 12.92, 1.055 * pow(c.rgb, 1.0 / 2.4) - 0.055, step(float3(0.0031308, 0.0031308, 0.0031308), c.rgb));
    return float4(sRGB, c.a);
}

float3 SDR2HDR(float3 sdrLin, float targetWhiteNits, float hdrMaxNits, float shadowGamma, float toeA)
{
    const float EPS = 1e-6;

    float3 x = pow(sdrLin + EPS, shadowGamma);  // ensures no zero/negative base

    // --- 3) Black-preserving toe ---
    const float luma = x.y;  // Y component is relative luminance in XYZ colorspace
    x = x / (x + toeA * (1.0 - luma) + EPS);

    // --- 4) Scale to targetWhiteNits ---
    float3 sceneNits = x * targetWhiteNits;

    // --- 5) Reinhard-style rolloff to HDR max ---
    float3 hdrOut = sceneNits / (sceneNits + hdrMaxNits);

    return hdrOut;
}

#ifdef HDR_FF

float4 processColorProfile(float4 colorIn)
{
    colorIn = clamp(colorIn, 0.0, 1.0);
    processAlpha(colorIn);
    float4 linearColor = toLinear(colorIn);

    float4 internalColor = clamp(
        float4(dot(toXYZ_R, linearColor), dot(toXYZ_G, linearColor), dot(toXYZ_B, linearColor), linearColor.a),
        0.0,
        3.0);

#ifdef TONE_MAP_SDR
    internalColor.rgb = SDR2HDR(internalColor.rgb, SDR_TARGET_NITS, MAX_NITS, 1.4, 3.);
#else
    internalColor.rgb *= LINEAR_SCALE;
#endif

    return internalColor;
}

#else

float4 processColorProfile(float4 colorIn)
{
    processAlpha(colorIn);
#ifdef USE_COLOR_PROFILE
    float4 linearColor = toLinear(colorIn);
    float4 internalColor = float4(
        dot(profileToRGB_R, linearColor),
        dot(profileToRGB_G, linearColor),
        dot(profileToRGB_B, linearColor),
        linearColor.a);
    internalColor = toGamma(internalColor);
    return internalColor;
#else
    return colorIn;
#endif
}

#endif  // HDR_FF
