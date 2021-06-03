using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTest.Models
{
    [Table("tblWithdraw")]
    public class Withdraw
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }
        public string CustomerID { get; set; }
        public decimal Withdrawamount { get; set; }
        public string WithdrawDate { get; set; }

    }

    public class TranHistory
    {
        public decimal DepositAmount { get; set; }
        public string DepostiDate { get; set; }
        public decimal WithdrawAmount { get; set; }
        public string WithdrawDate { get; set; }
        public string CustomerID { get; set; }
    }
}
