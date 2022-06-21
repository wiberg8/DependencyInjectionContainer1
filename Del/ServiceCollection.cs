namespace Del;

public class ServiceCollection
{
    private readonly List<ServiceDescriptor> descriptors = new();

    public T GetService<T>()
    {
        return (T)GetService(typeof(T));
    }

    public object GetService(Type serviceType)
    {
        ServiceDescriptor desc;
        if (serviceType.IsAbstract || serviceType.IsInterface)
        {
            desc = descriptors.First(x => x.AbstractType == serviceType);
            serviceType = desc.ServiceType;
        }
        else
        {
            desc = descriptors.First(x => x.ServiceType == serviceType);
        }
        if (desc is SingeltonDescriptor singeltonDesc)
        {
            if (singeltonDesc.Implementation is null)
            {
                singeltonDesc.Implementation = ExtractService(serviceType);
                return singeltonDesc.Implementation;
            }
            return singeltonDesc.Implementation;
        }
        return ExtractService(serviceType);
    }

    private object ExtractService(Type serviceType)
    {
        var parameters = GetParameters(serviceType);
        return Activator.CreateInstance(serviceType, parameters.Select(x => GetService(x)).ToArray())!;
    }

    public ServiceCollection AddSingelton<T>()
    {
        descriptors.Add(new SingeltonDescriptor(typeof(T)));
        return this;
    }
    public ServiceCollection AddSingelton<T, T2>()
    {
        descriptors.Add(new SingeltonDescriptor(typeof(T2), typeof(T)));
        return this;
    }

    public ServiceCollection AddTransient<T>()
    {
        descriptors.Add(new TransientDescriptor(typeof(T)));
        return this;
    }
    public ServiceCollection AddTransient<T, T2>()
    {
        descriptors.Add(new TransientDescriptor(typeof(T2), typeof(T)));
        return this;
    }

    private Type[] GetParameters(Type serviceType)
    {
        var constructors = serviceType.GetConstructors();
        if (constructors.Length > 1) 
            throw new("Only none or 1 constructor allowed");
        var parameterTypes = constructors[0].GetParameters()
            .Select(x => x.ParameterType)
            .ToArray();
        return parameterTypes;
    }
}
