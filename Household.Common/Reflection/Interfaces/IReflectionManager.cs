using System;
using System.Collections.Generic;

namespace Household.Common.Reflection.Interfaces
{
    public interface IReflectionManager
    {
		List<Type> GetTypesByInterface(Type interfaceType);
    }
}