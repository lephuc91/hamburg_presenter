using Pro.Common.Operations;

namespace Pro.Common.Mathematics;

public struct Matrix<T>
{
	public static readonly Matrix<T> Identity = new Matrix<T>(Constants<T>.One, Constants<T>.Zero, Constants<T>.Zero, Constants<T>.Zero, Constants<T>.Zero, Constants<T>.One, Constants<T>.Zero, Constants<T>.Zero, Constants<T>.Zero, Constants<T>.Zero, Constants<T>.One, Constants<T>.Zero, Constants<T>.Zero, Constants<T>.Zero, Constants<T>.Zero, Constants<T>.One);

	private T _m00;

	private T _m10;

	private T _m20;

	private T _m30;

	private T _m01;

	private T _m11;

	private T _m21;

	private T _m31;

	private T _m02;

	private T _m12;

	private T _m22;

	private T _m32;

	private T _m03;

	private T _m13;

	private T _m23;

	private T _m33;

	public Matrix(T m00, T m10, T m20, T m30, T m01, T m11, T m21, T m31, T m02, T m12, T m22, T m32, T m03, T m13, T m23, T m33)
	{
		_m00 = m00;
		_m10 = m10;
		_m20 = m20;
		_m30 = m30;
		_m01 = m01;
		_m11 = m11;
		_m21 = m21;
		_m31 = m31;
		_m02 = m02;
		_m12 = m12;
		_m22 = m22;
		_m32 = m32;
		_m03 = m03;
		_m13 = m13;
		_m23 = m23;
		_m33 = m33;
	}

	public Matrix(T m00, T m10, T m20, T m01, T m11, T m21, T m02, T m12, T m22)
	{
		_m00 = m00;
		_m10 = m10;
		_m20 = Constants<T>.Zero;
		_m30 = m20;
		_m01 = m01;
		_m11 = m11;
		_m21 = Constants<T>.Zero;
		_m31 = m21;
		_m02 = Constants<T>.Zero;
		_m12 = Constants<T>.Zero;
		_m22 = Constants<T>.One;
		_m32 = Constants<T>.Zero;
		_m03 = m02;
		_m13 = m12;
		_m23 = Constants<T>.Zero;
		_m33 = m22;
	}

	public Matrix<T> Inverse()
	{
		T val = _m00.Multiply(_m33.Multiply(_m11).Subtract(_m13.Multiply(_m31))).Subtract(_m01.Multiply(_m33.Multiply(_m10).Subtract(_m13.Multiply(_m30))).Add(_m03.Multiply(_m33.Multiply(_m31).Subtract(_m11.Multiply(_m30)))));
		if (!val.Equal(Constants<T>.Zero))
		{
			return new Matrix<T>(_m33.Multiply(_m11).Subtract(_m13.Multiply(_m31)).Divide(val), _m33.Multiply(_m10).Subtract(_m13.Multiply(_m30)).Negate()
				.Divide(val), _m31.Multiply(_m10).Subtract(_m11.Multiply(_m30)).Divide(val), _m33.Multiply(_m01).Subtract(_m03.Multiply(_m31)).Negate()
				.Divide(val), _m33.Multiply(_m00).Subtract(_m03.Multiply(_m30)).Divide(val), _m31.Multiply(_m00).Subtract(_m01.Multiply(_m30)).Negate()
				.Divide(val), _m13.Multiply(_m01).Subtract(_m03.Multiply(_m11)).Divide(val), _m13.Multiply(_m00).Subtract(_m03.Multiply(_m10)).Negate()
				.Divide(val), _m11.Multiply(_m00).Subtract(_m01.Multiply(_m10)).Divide(val));
		}
		return Identity;
	}

	public Vector2<T> Transform(Vector2<T> point)
	{
		return Transform(point.X, point.Y);
	}

	public Vector2<T> Transform(T x, T y)
	{
		return new Vector2<T>(_m00.Multiply(x).Add(_m10.Multiply(y)).Add(_m30), _m01.Multiply(x).Add(_m11.Multiply(y)).Add(_m31));
	}

	public Rect<T> Transform(Rect<T> rect)
	{
		return new Vector2<T>[4]
		{
			Transform(rect.TopLeft),
			Transform(rect.TopRight),
			Transform(rect.BottomRight),
			Transform(rect.BottomLeft)
		}.GetBoundingBox();
	}

	public Matrix<T> Combine(Matrix<T> matrix)
	{
		Matrix<T> matrix2 = this;
		Matrix<T> matrix3 = matrix;
		return new Matrix<T>(matrix2._m00.Multiply(matrix3._m00).Add(matrix2._m10.Multiply(matrix3._m01)).Add(matrix2._m30.Multiply(matrix3._m03)), matrix2._m00.Multiply(matrix3._m10).Add(matrix2._m10.Multiply(matrix3._m11)).Add(matrix2._m30.Multiply(matrix3._m13)), matrix2._m00.Multiply(matrix3._m30).Add(matrix2._m10.Multiply(matrix3._m31)).Add(matrix2._m30.Multiply(matrix3._m33)), matrix2._m01.Multiply(matrix3._m00).Add(matrix2._m11.Multiply(matrix3._m01)).Add(matrix2._m31.Multiply(matrix3._m03)), matrix2._m01.Multiply(matrix3._m10).Add(matrix2._m11.Multiply(matrix3._m11)).Add(matrix2._m31.Multiply(matrix3._m13)), matrix2._m01.Multiply(matrix3._m30).Add(matrix2._m11.Multiply(matrix3._m31)).Add(matrix2._m31.Multiply(matrix3._m33)), matrix2._m03.Multiply(matrix3._m00).Add(matrix2._m13.Multiply(matrix3._m01)).Add(matrix2._m33.Multiply(matrix3._m03)), matrix2._m03.Multiply(matrix3._m10).Add(matrix2._m13.Multiply(matrix3._m11)).Add(matrix2._m33.Multiply(matrix3._m13)), matrix2._m03.Multiply(matrix3._m30).Add(matrix2._m13.Multiply(matrix3._m31)).Add(matrix2._m33.Multiply(matrix3._m33)));
	}

	public Matrix<T> Translate(Vector2<T> offset)
	{
		return Translate(offset.X, offset.Y);
	}

	public Matrix<T> Translate(T x, T y)
	{
		return Combine(new Matrix<T>(Constants<T>.One, Constants<T>.Zero, x, Constants<T>.Zero, Constants<T>.One, y, Constants<T>.Zero, Constants<T>.Zero, Constants<T>.One));
	}

	public Matrix<T> Rotate(T a)
	{
		return Rotate(a, Vector2<T>.Zero);
	}

	public Matrix<T> Rotate(T a, Vector2<T> center)
	{
		double a2 = a.Cast<double, T>();
		T val = a2.Cos().Cast<T, double>();
		T val2 = a2.Sin().Cast<T, double>();
		return Combine(new Matrix<T>(val, val2.Negate(), center.X.Multiply(Constants<T>.One.Subtract(val)).Add(center.Y.Multiply(val2)), val2, val, center.Y.Multiply(Constants<T>.One.Subtract(val)).Subtract(center.X.Multiply(val2)), Constants<T>.Zero, Constants<T>.Zero, Constants<T>.One));
	}

	public Matrix<T> Scale(T scale)
	{
		return Scale(scale, scale);
	}

	public Matrix<T> Scale(Vector2<T> scale)
	{
		return Scale(scale.X, scale.Y);
	}

	public Matrix<T> Scale(T scaleX, T scaleY)
	{
		return Scale(scaleX, scaleY, Vector2<T>.Zero);
	}

	public Matrix<T> Scale(T scaleX, T scaleY, Vector2<T> center)
	{
		return Combine(new Matrix<T>(scaleX, Constants<T>.Zero, center.X.Multiply(Constants<T>.One.Subtract(scaleX)), Constants<T>.Zero, scaleY, center.Y.Multiply(Constants<T>.One.Subtract(scaleY)), Constants<T>.Zero, Constants<T>.Zero, Constants<T>.One));
	}

	public static Matrix<T> operator *(Matrix<T> lhs, Matrix<T> rhs)
	{
		return lhs.Combine(rhs);
	}

	public static Vector2<T> operator *(Vector2<T> point, Matrix<T> matrix)
	{
		return matrix.Transform(point);
	}

	public static Rect<T> operator *(Rect<T> rect, Matrix<T> matrix)
	{
		return matrix.Transform(rect);
	}
}
