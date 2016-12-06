using Household.Common.Reflection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Household.Common.Reflection.Implementations
{
	public class CReflectionManager : IReflectionManager
	{
		public IEnumerable<Type> GetTypesByInterface(Type interfaceType)
		{
			var assembly = Assembly.GetAssembly(interfaceType);

			return assembly.GetTypes().Where(t => t.IsClass && interfaceType.IsAssignableFrom(t));
		}

		public IEnumerable<Type> GetTypesByInterface<T>()
		{
			return GetTypesByInterface(typeof(T));
		}

		public T CreateInstance<T>()
		where T : class
		{
			return (T)Activator.CreateInstance(typeof(T));
		}

		public PropertyInfo[] GetProperties<T>()
		{
			return typeof(T).GetProperties();
		}

		public T GetCustomAttribute<T>(Type type, bool inherited) {
			return (T)type.GetCustomAttributes(typeof(T), false).FirstOrDefault();
		}
	}
}