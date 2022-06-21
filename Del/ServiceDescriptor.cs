namespace Del;

public abstract class ServiceDescriptor
{
    public Type ServiceType { get; }
    public Type? AbstractType { get; }

    protected ServiceDescriptor(Type serviceType)
    {
        ServiceType = serviceType;
        AbstractType = null;
    }

    protected ServiceDescriptor(Type serviceType, Type abstractType)
    {
        ServiceType = serviceType;
        AbstractType = abstractType;
    }
}
