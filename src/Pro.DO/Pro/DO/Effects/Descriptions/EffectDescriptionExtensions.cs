using Pro.Localization;

namespace Pro.DO.Effects.Descriptions;

public static class EffectDescriptionExtensions
{
	public static bool TryGetLocalizedName(this string effectName, out string localizedName)
	{
		string text = getKey();
		if (text == null)
		{
			localizedName = string.Empty;
			return false;
		}
		localizedName = LocalizedStrings.Get(text);
		return !string.IsNullOrEmpty(localizedName);
		string? getKey()
		{
			return effectName switch
			{
				"Amoeba" => "TRANSITIONS_AMOEBA_name", 
				"Color Burn" => "TRANSITIONS_COLOR_BURN_name", 
				"Color Push" => "TRANSITIONS_COLOR_PUSH_name", 
				"Color Warp" => "TRANSITIONS_COLOR_WARP_name", 
				"Cross Hatch" => "TRANSITIONS_CROSS_HATCH_name", 
				"Cube" => "TRANSITIONS_CUBE_name", 
				"Cut" => "TRANSITIONS_CUT_name", 
				"Dispersion Blur" => "TRANSITIONS_DISPERSION_BLUR_name", 
				"Dissolve" => "TRANSITIONS_DISSOLVE_name", 
				"Door" => "TRANSITIONS_DOOR_name", 
				"Door Wipe" => "TRANSITIONS_DOOR_WIPE_name", 
				"Fade" => "TRANSITIONS_FADE_name", 
				"Fade Black" => "TRANSITIONS_FADE_BLACK_name", 
				"Fade Bright" => "TRANSITIONS_FADE_BRIGHT_name", 
				"Fade Dark" => "TRANSITIONS_FADE_DARK_name", 
				"Fade Gray" => "TRANSITIONS_FADE_GRAY_name", 
				"Fade White" => "TRANSITIONS_FADE_WHITE_name", 
				"Film Burn" => "TRANSITIONS_FILM_BURN_name", 
				"Flip" => "TRANSITIONS_FLIP_name", 
				"Fly In" => "TRANSITIONS_FLY_IN_name", 
				"Iris" => "TRANSITIONS_IRIS_name", 
				"Kaleidoscope Wipe" => "TRANSITIONS_KALEIDOSCOPE_WIPE_name", 
				"Mosaic" => "TRANSITIONS_MOSAIC_name", 
				"Move In" => "TRANSITIONS_MOVE_IN_name", 
				"Noisy Zoom" => "TRANSITIONS_NOISY_ZOOM_name", 
				"Push" => "TRANSITIONS_PUSH_name", 
				"Random Pixels" => "TRANSITIONS_RANDOM_PIXELS_name", 
				"Random Squares" => "TRANSITIONS_RANDOM_SQUARES_name", 
				"Random Squares Flicker" => "TRANSITIONS_RANDOM_SQUARES_FLICKER_name", 
				"Reveal" => "TRANSITIONS_REVEAL_name", 
				"Ripple" => "TRANSITIONS_RIPPLE_name", 
				"Square Wipe" => "TRANSITIONS_SQUARE_WIPE_name", 
				"Swap" => "TRANSITIONS_SWAP_name", 
				"Warp Fade" => "TRANSITIONS_WARP_FADE_name", 
				"Wave Dissolve" => "TRANSITIONS_WAVE_DISSOLVE_name", 
				"Wipe" => "TRANSITIONS_WIPE_name", 
				"Zoom In" => "TRANSITIONS_ZOOM_IN_name", 
				"Adjust Color" => "EFFECT_ADJUST_COLOR_name", 
				"RGB Adjust" => "EFFECT_RBG_ADJUST_name", 
				"Blur" => "EFFECT_BLUR_name", 
				"Color Filter" => "EFFECT_COLOR_FILTER_name", 
				"Color Invert" => "EFFECT_COLOR_INVERT_name", 
				"Color Key" => "EFFECT_COLOR_KEY_name", 
				"Color Posterize" => "EFFECT_COLOR_POSTERIZE_name", 
				"Color Swap" => "EFFECT_COLOR_SWAP_name", 
				"CRT Monitor" => "EFFECT_CRT_MONITOR_name", 
				"Dots" => "EFFECT_DOTS_name", 
				"Edge Blur" => "EFFECT_EDGE_BLUR_name", 
				"Edge Outline" => "EFFECT_EDGE_OUTLINE_name", 
				"Emboss" => "EFFECT_EMBOSS_name", 
				"Gray Invert" => "EFFECT_GRAY_INVERT_name", 
				"Halftone" => "EFFECT_HALFTONE_name", 
				"Heat Signature" => "EFFECT_HEAT_SIGATURE_name", 
				"Hexagon" => "EFFECT_HEXAGON_name", 
				"Image Distortion" => "EFFECT_IMAGE_DISTORTION_name", 
				"Kaleidoscope 1" => "EFFECT_KALEIDOSCOPE_1_name", 
				"Kaleidoscope 2" => "EFFECT_KALEIDOSCOPE_2_name", 
				"Kaleidoscope 3" => "EFFECT_KALEIDOSCOPE_3_name", 
				"Lens Distortion" => "EFFECT_LENS_DISTORTION_name", 
				"Old Film" => "EFFECT_OLD_FILM_name", 
				"Picasso" => "EFFECT_PICASSO_name", 
				"Pixelize" => "EFFECT_PIXELIZE_name", 
				"Plasma" => "EFFECT_PLASMA_name", 
				"Radial Blur" => "EFFECT_RADIAL_BLUR_name", 
				"Ripple Center" => "EFFECT_RIPPLE_CENTER_name", 
				"Ripple Side" => "EFFECT_RIPPLE_SIDE_name", 
				"Sepia" => "EFFECT_SEPIA_name", 
				"Shake" => "EFFECT_SHAKE_name", 
				"Stars" => "EFFECT_STARS_name", 
				"Strobe" => "EFFECT_STROBE_name", 
				"Tile" => "EFFECT_TILE_name", 
				"Toon" => "EFFECT_TOON_name", 
				"Two Color" => "EFFECT_TWOCOLOR_name", 
				"Vignette" => "EFFECT_VIGNETTE_name", 
				_ => null, 
			};
		}
	}

	public static bool TryGetLocalizedParameter(this string parameterName, out string localizedName)
	{
		string text = getKey();
		if (text == null)
		{
			localizedName = string.Empty;
			return false;
		}
		localizedName = LocalizedStrings.Get(text);
		return !string.IsNullOrEmpty(localizedName);
		string? getKey()
		{
			return parameterName switch
			{
				"Amount" => "EFFECT_PARAMETER_AMOUNT_name", 
				"Angle" => "EFFECT_PARAMETER_ANGLE_name", 
				"Animate" => "EFFECT_PARAMETER_ANIMATE_name", 
				"Blend Color" => "EFFECT_PARAMETER_BLEND_COLOR_name", 
				"Blend" => "EFFECT_PARAMETER_BLEND_name", 
				"Blue" => "EFFECT_PARAMETER_BLUE_name", 
				"Brightness" => "EFFECT_PARAMETER_BRIGHTNESS_name", 
				"Bright Color" => "EFFECT_PARAMETER_BRIGHT_COLOR_name", 
				"Burn Color" => "EFFECT_PARAMETER_BURN_COLOR_name", 
				"Cells" => "EFFECT_PARAMETER_CELLS_name", 
				"Center X" => "EFFECT_PARAMETER_CENTER_X_name", 
				"Center Y" => "EFFECT_PARAMETER_CENTER_Y_name", 
				"Color Count" => "EFFECT_PARAMETER_COLOR_COUNT_name", 
				"Color Distortion" => "EFFECT_PARAMETER_COLOR_DISTORTION_name", 
				"Color Separation" => "EFFECT_PARAMETER_COLOR_SEPARATION_name", 
				"Color" => "EFFECT_PARAMETER_COLOR_name", 
				"Contrast" => "EFFECT_PARAMETER_CONSRAST_name", 
				"Dark Color" => "EFFECT_PARAMETER_DARK_COLOR_name", 
				"Decay" => "EFFECT_PARAMETER_DECAY_name", 
				"Direction" => "EFFECT_PARAMETER_DIRECTION_name", 
				"Frequency" => "EFFECT_PARAMETER_FREQUENCY_name", 
				"Gamma" => "EFFECT_PARAMETER_GAMMA_name", 
				"Color Removal" => "EFFECT_PARAMETER_COLOR_REMOVAL_name", 
				"Gray Components" => "EFFECT_PARAMETER_GRAY_COMPONENTS_name", 
				"Green" => "EFFECT_PARAMETER_GREEN_name", 
				"Hue" => "EFFECT_PARAMETER_HUE_name", 
				"Intensity" => "EFFECT_PARAMETER_INTENSITY_name", 
				"Iterations" => "EFFECT_PARAMETER_ITERATIONS_name", 
				"Length" => "EFFECT_PARAMETER_LENGTH_name", 
				"Lens Size" => "EFFECT_PARAMETER_LENS_SIZE_name", 
				"Light X" => "EFFECT_PARAMETER_LIGHT_X_name", 
				"Light Y" => "EFFECT_PARAMETER_LIGHT_Y_name", 
				"New Color" => "EFFECT_PARAMETER_NEW_COLOR_name", 
				"Noise Level" => "EFFECT_PARAMETER_NOISE_LEVEL_name", 
				"Number of colors" => "EFFECT_PARAMETER_NUMBER_OF_COLORS_name", 
				"Old Color" => "EFFECT_PARAMETER_OLD_COLOR_name", 
				"Radius" => "EFFECT_PARAMETER_RADIUS_name", 
				"Randomness" => "EFFECT_PARAMETER_RANDOMNESS_name", 
				"Red" => "EFFECT_PARAMETER_RED_name", 
				"Saturation" => "EFFECT_PARAMETER_SATURATION_name", 
				"Scale" => "EFFECT_PARAMETER_SCALE_name", 
				"Scratches" => "EFFECT_PARAMETER_SCRATCHES_name", 
				"Sepia Effect" => "EFFECT_PARAMETER_SEPIA_EFFECT_name", 
				"Sharpness" => "EFFECT_PARAMETER_SHARPNESS_name", 
				"Sides" => "EFFECT_PARAMETER_SIDES_name", 
				"Size" => "EFFECT_PARAMETER_SIZE_name", 
				"Speed" => "EFFECT_PARAMETER_SPEED_name", 
				"Strength" => "EFFECT_PARAMETER_STRENGTH_name", 
				"Tolerance" => "EFFECT_PARAMETER_TOLERANCE_name", 
				"Vignette" => "EFFECT_PARAMETER_VIGNETTE_name", 
				"Zoom" => "EFFECT_PARAMETER_ZOOM_name", 
				_ => null, 
			};
		}
	}
}
