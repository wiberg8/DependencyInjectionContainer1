using System;
namespace Del;

public class SingeltonDescriptor : ServiceDescriptor
{
    public object? Implementation { get; set; }

    public SingeltonDescriptor(Type serviceType) : base(serviceType)
    {
    }
    public SingeltonDescriptor(Type serviceType, Type abstractType) : base(serviceType, abstractType)
    {
    }
}
