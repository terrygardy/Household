using Household.Localisation.Main.MasterData;

namespace Household.Data.Context
{
	using Models.Base;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using Text.Error;

	public partial class txx_Shop : IValidatableObject, IDataBase
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public txx_Shop()
		{
			t_Purchase = new HashSet<t_Purchase>();
		}

		public long ID { get; set; }

		[Required]
		[StringLength(255)]
		[Display(Name = "Name", ResourceType = typeof(ShopText))]
		public string Name { get; set; }

		[Display(Name = "Description", ResourceType = typeof(ShopText))]
		public string Description { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<t_Purchase> t_Purchase { get; set; }

		public override string ToString()
		{
			return GARTE.TypeHandling.Base.convertString(Name);
		}

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var list = new List<ValidationResult>();

			if (string.IsNullOrEmpty(Name)) { list.Add(new ValidationResult(Shop.EnterName)); }

			if (Db.CDbConnection.getInstance().txx_Shop.Count(x => string.Equals(x.Name, Name) && x.ID != ID) > 0) { list.Add(new ValidationResult(Shop.NameExists)); }

			return list;
		}
	}
}
