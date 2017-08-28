using LenLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOC
{
    public class Injector
    {
        private static Logger log = Logger.Instance;

        private Dictionary<Type, Func<object>> providers = new Dictionary<Type, Func<object>>();

        public void Bind<TKey, TConcrete>() where TConcrete : TKey
        {
            log.Write($"Binding Type {typeof(TKey)} to {typeof(TConcrete)}");

            providers[typeof(TKey)] = () => ResolveByType(typeof(TConcrete));
        }

        public void Bind<T>(T instance)
        {
            log.Write($"Binding instance {typeof(T)} to {typeof(T)}");
            providers[typeof(T)] = () => instance;
        }

        private object ResolveByType(Type type)
        {
            log.Write($"Resolving By Type {type}");

            var constructor = type.GetConstructors().SingleOrDefault();

            if (constructor != null)
            {
                var arguments = constructor.GetParameters()
                                        .Select(parameterInfo => Resolve(parameterInfo.ParameterType))
                                        .ToArray();

                return constructor.Invoke(arguments);
            }
            var instanceField = type.GetField("Instance");
            return instanceField.GetValue(null);

            //   var instanceProperty = type.GeProperty("Instance", BindingFlags.Public | BindingFlags.Static);
            //       return instanceProperty.GetValue(null, new object[0]);

        }

        public TKey Resolve<TKey>()
        {
            log.Write($"Resolve TKey: {typeof(TKey)}");
            return (TKey)Resolve(typeof(TKey));
        }

        private object Resolve(Type type)
        {
            log.Write($"Resolve  type: {type}");
            Func<object> provider;
            if (providers.TryGetValue(type, out provider))
            {
                return provider();
            }
            return ResolveByType(type);
        }

    }
}