using SampleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTest.Repository
{
   public interface IWithdraw
    {
        Withdraw createWithdraw(Withdraw create);
        void DeleteWithdraw (int id);
        Withdraw GetWithdrawByCustomerID(string customerID);
        IEnumerable<Withdraw> GetWithdraws();
        List<TranHistory> TransactionHistory();

    }
}
