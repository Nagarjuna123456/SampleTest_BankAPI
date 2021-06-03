using SampleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTest.Repository
{
    public class WithdrawService : IWithdraw
    {
        SampleTestContext dbcontext;

        public WithdrawService(SampleTestContext _db)
        {
            dbcontext = _db;
        }
        public Withdraw createWithdraw(Withdraw create)
        {
            if (create != null)
            {
                dbcontext.withdraws.Add(create);
                dbcontext.SaveChanges();
                return create;
            }
            return null;

        }

        public void DeleteWithdraw(int id)
        {
            var delete = dbcontext.withdraws.FirstOrDefault(d => d.ID == id);
            if (delete != null)
            {
                dbcontext.withdraws.Remove(delete);
                dbcontext.SaveChanges();
            }
        }

        public Withdraw GetWithdrawByCustomerID(string customerID)
        {
            var single = dbcontext.withdraws.FirstOrDefault(w => w.CustomerID == customerID);
            return single;
        }

        public IEnumerable<Withdraw> GetWithdraws()
        {
            var withdraws = dbcontext.withdraws.ToList();
            return withdraws;
        }
        
        public List<TranHistory> TransactionHistory()
        {
            var translist = (from d in dbcontext.depositdata
                             join w in dbcontext.withdraws on d.CustomerId equals w.CustomerID
                             select new TranHistory
                             {
                                 DepositAmount = d.Amount,
                                 DepostiDate = d.CreatedDate,
                                 WithdrawAmount = w.Withdrawamount,
                                 WithdrawDate = w.WithdrawDate,
                                 CustomerID = d.CustomerId
                             }).ToList();
            return translist;
        }

    }

    
}