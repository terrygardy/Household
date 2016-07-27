namespace Household.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbr_BankAccountPerson
    {
        public long ID { get; set; }

        public long BankAccount_ID { get; set; }

        public long Person_ID { get; set; }

        public virtual t_Person t_Person { get; set; }

        public virtual txx_BankAccount txx_BankAccount { get; set; }
    }
}
