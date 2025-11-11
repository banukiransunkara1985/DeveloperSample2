using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            _mappings[interfaceType] = implementationType;
        }
        public T Get<T>()
        {
            var interfaceType = typeof(T);

            if(! _mappings.ContainsKey(interfaceType))
                throw new Exception($" No Binding for type {interfaceType.Name}");

            var implementationType = _mappings[interfaceType];

            return (T)Activator.CreateInstance(implementationType);
        }
    }
}