using System;

namespace Pro.Loro;

internal interface CallStatusErrorHandler<E> where E : Exception
{
	E Lift(RustBuffer error_buf);
}
