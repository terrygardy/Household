namespace Household.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Purchase
    {
        public long ID { get; set; }

        public DateTime Occurrence { get; set; }

        public long? Shop_ID { get; set; }

		public long? Payer_ID { get; set; }

		public decimal Amount { get; set; }

        public string Description { get; set; }

		[ForeignKey("Shop_ID")]
        public virtual txx_Shop txx_Shop { get; set; }

		[ForeignKey("Payer_ID")]
		public virtual txx_BankAccount txx_BankAccount { get; set; }
	}
}
