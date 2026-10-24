using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media.Imaging;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.DO.Transitions;

namespace ProPresenter.Controller.Outputs.ssAPI;

internal sealed record TransitionPreviewKey(TransitionParameters Transition, BitmapSource StartImage, BitmapSource EndImage, Vector2<int> TargetSize)
{
	private readonly int _hashCode = HashCodeHelper.GenerateHashCode(Transition, StartImage, EndImage, TargetSize);

	public bool Equals(TransitionPreviewKey? other)
	{
		Vector2<int> targetSize = TargetSize;
		Vector2<int>? vector = other?.TargetSize;
		if (vector.HasValue && targetSize == vector.GetValueOrDefault() && StartImage == other?.StartImage && EndImage == other.EndImage)
		{
			return Transition.NullableEquals(other.Transition, (TransitionParameters lhs, TransitionParameters rhs) => lhs?.Equals(rhs, ignoreDuration: false, ignoreName: true) ?? false);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	[CompilerGenerated]
	private bool PrintMembers(StringBuilder builder)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("Transition = ");
		builder.Append(Transition);
		builder.Append(", StartImage = ");
		builder.Append(StartImage);
		builder.Append(", EndImage = ");
		builder.Append(EndImage);
		builder.Append(", TargetSize = ");
		builder.Append(TargetSize.ToString());
		return true;
	}
}
