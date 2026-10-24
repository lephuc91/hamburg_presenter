#ifdef AdobeRGB1998
const vec4 profileToRGB_R = vec4(1.398283, -0.398283064, 0.0, 0.0);
const vec4 profileToRGB_G = vec4(0.0, 1.0, 0.0, 0.0);
const vec4 profileToRGB_B = vec4(0.0, -0.0429382771, 1.04293835, 0.0);
#endif

#ifdef DISPLAY_P3
const vec4 profileToRGB_R = vec4(1.2249, -0.2247, 0.0, 0.0);
const vec4 profileToRGB_G = vec4(-0.0420, 1.0419, 0.0, 0.0);
const vec4 profileToRGB_B = vec4(-0.027, -0.0786, 1.0979, 0.0);
#endif

#ifdef PRO_PHOTO_RGB
const vec4 profileToRGB_R = vec4(2.03407574, -0.72733432, -0.306741565, 0.0);
const vec4 profileToRGB_G = vec4(-0.228813201, 1.23173022, -0.00291692792, 0.0);
const vec4 profileToRGB_B = vec4(-0.00856976956, -0.153286651, 1.1618564, 0.0);
#endif

#ifdef BT2020
// values obtained from:
// Report ITU-R BT.2407-0 (10/2017) - Colour gamut conversion from Recommendation ITU-R BT.2020 to Recommendation ITU-R
// BT.709
const vec4 profileToRGB_R = vec4(1.6605, -0.5876, -0.0728, 0.0);
const vec4 profileToRGB_G = vec4(-0.1246, 1.1329, -0.0083, 0.0);
const vec4 profileToRGB_B = vec4(-0.0182, -0.1006, 1.1187, 0.0);
#endif

vec4 toGamma(vec4 linearRGB)
{
    bvec3 cutoff = lessThan(linearRGB.rgb, vec3(0.0031308));
    vec3 higher = (1.055) * pow(linearRGB.rgb, vec3(1.0 / 2.4)) - vec3(0.055);
    vec3 lower = linearRGB.rgb * vec3(12.92);

    return vec4(mix(higher, lower, cutoff), linearRGB.a);
}

// Converts a color from sRGB gamma to linear light gamma
vec4 toLinear(vec4 sRGB)
{
    bvec3 cutoff = lessThan(sRGB.rgb, vec3(0.04045));
    vec3 higher = pow((sRGB.rgb + vec3(0.055)) / vec3(1.055), vec3(2.4));
    vec3 lower = sRGB.rgb / vec3(12.92);

    return vec4(mix(higher, lower, cutoff), sRGB.a);
}

vec4 linearizeBT709(vec4 bt709)
{
    bvec3 cutoff = lessThan(bt709.rgb, vec3(0.081));
    vec3 higher = pow(bt709.rgb + vec3(0.099), vec3(2.2));
    vec3 lower = bt709.rgb / vec3(4.5);

    return vec4(mix(higher, lower, cutoff), bt709.a);
}

#ifdef USE_COLOR_PROFILE
vec4 processColorProfile(vec4 colorIn)
{
#ifdef BT709
    // BT709 has same color primaries as sRGB so not color correction is required
    vec4 srgbLinear = linearizeBT709(colorIn);
#else
    vec4 linear = toLinear(colorIn);

    vec4 srgbLinear =
        vec4(dot(profileToRGB_R, linear), dot(profileToRGB_G, linear), dot(profileToRGB_B, linear), colorIn.a);
#endif
    return (toGamma(srgbLinear));
}
#else
vec4 processColorProfile(vec4 colorIn)
{
    return colorIn;
}
#endif
