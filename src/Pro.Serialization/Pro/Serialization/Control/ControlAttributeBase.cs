using System;

namespace Pro.Serialization.Control;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public abstract class ControlAttributeBase : Attribute
{
}
