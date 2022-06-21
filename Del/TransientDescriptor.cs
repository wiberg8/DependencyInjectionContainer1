namespace Del;

public class TransientDescriptor : ServiceDescriptor
{
    public TransientDescriptor(Type serviceType) : base(serviceType)
    {
    }
    public TransientDescriptor(Type serviceType, Type abstractType) : base(serviceType, abstractType)
    {
    }
}
