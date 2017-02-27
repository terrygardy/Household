namespace Household.Data.Context
{
	using Audit;
	using Localisation.Main.ShoppingList;
	using Models.Base;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Runtime.Serialization;
	using System.Xml.Serialization;
	using Text.Error;

	[Serializable]
	public partial class t_ShoppingListItem : DataAuditBase, IValidatableObject, IDataBase
	{
		[Key]
		public long ID { get; set; }

		[Required]
		[Display(Name = "Name", ResourceType = typeof(ShoppingListItemText))]
		public string Name { get; set; }

		public long? Shop_ID { get; set; }

		[Display(Name = "Amount", ResourceType = typeof(ShoppingListItemText))]
		public decimal Amount { get; set; }

		[IgnoreDataMember]
		[XmlIgnore]
		[Display(Name = "Shop", ResourceType = typeof(ShoppingListItemText))]
		[ForeignKey("Shop_ID")]
		public virtual txx_Shop txx_Shop { get; set; }

		public override string EntityName => "ShoppingListItem";
		public string EntityTitle => ShoppingListItemText.ShoppingListItem;

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var list = new List<ValidationResult>();

			if (string.IsNullOrWhiteSpace(Name)) list.Add(new ValidationResult(ShoppingList.EnterName));
			if (Amount < 0) list.Add(new ValidationResult(ShoppingList.EnterAmount));
			
			return list;
		}
	}
}
