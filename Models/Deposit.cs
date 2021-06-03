using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTest.Models
{
    [Table("tblDeposit")]
    public class Deposit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }
        public string CustomerId { get; set; }
        public decimal DepositID { get; set; }
        public decimal Amount { get; set; }
        public string CreatedDate { get; set; }
    }
}
