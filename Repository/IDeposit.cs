using SampleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTest.Repository
{
    public interface IDeposit
    {
        IEnumerable<Deposit> GetDeposits();
        Deposit GetDepositByCustomerID(string customerid);
        Deposit AddDeposit(Deposit addDeposit);
        void DeleteDeposit(int id);
        void UpdateDeposit(Deposit updateDeposit);

    }
}
