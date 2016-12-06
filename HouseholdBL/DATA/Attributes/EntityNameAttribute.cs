using System;

namespace Household.BL.DATA.Attributes
{
	public class EntityNameAttribute : Attribute
	{
		public string EntityName { get; }

		public EntityNameAttribute(Type resourceType, string resourcePropertyName)
		{
			EntityName = resourceType.GetProperty(resourcePropertyName, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).GetValue(null)?.ToString();
		}
	}
}