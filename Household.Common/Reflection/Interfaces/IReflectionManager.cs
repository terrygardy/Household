using System;
using System.Collections.Generic;
using System.Reflection;

namespace Household.Common.Reflection.Interfaces
{
    public interface IReflectionManager
    {
		IEnumerable<Type> GetTypesByInterface<T>();
		IEnumerable<Type> GetTypesByInterface(Type interfaceType);

		T CreateInstance<T>()
			where T : class;

		PropertyInfo[] GetProperties<T>();

		T GetCustomAttribute<T>(Type type, bool inherited);
    }
}