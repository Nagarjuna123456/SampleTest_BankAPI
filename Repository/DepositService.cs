using SampleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTest.Repository
{
    public class DepositService : IDeposit
    {

        //private List<Deposit> deposits = new List<Deposit>()
        //{
        //    new Deposit()
        //    {
        //        ID =1,
        //        CustomerId ="1a1b",
        //        Amount =1000,
        //        CreatedDate = DateTime.Today.ToString("yyyy/MM/dd")
        //    },
        //     new Deposit()
        //    {
        //        ID =2,
        //        CustomerId ="2a2b",
        //        Amount =15000,
        //        CreatedDate = DateTime.Today.ToString("yyyy/MM/dd")
        //    }
        //};
        SampleTestContext dbcontext;

        public DepositService(SampleTestContext _db)
        {
            dbcontext = _db;
        }

        public Deposit AddDeposit(Deposit addDeposit)
        {
            if(addDeposit != null)
            {
                dbcontext.depositdata.Add(addDeposit);
                dbcontext.SaveChanges();
                return addDeposit;
            }
            return null;
        }

        public void DeleteDeposit(int id)
        {
            var delete = dbcontext.depositdata.FirstOrDefault(d=>d.ID == id);
            if(delete != null)
            {
                dbcontext.depositdata.Remove(delete);
                dbcontext.SaveChanges();
            }
        }

        public Deposit GetDepositByCustomerID(string customerid)
        {
            var deposit = dbcontext.depositdata.FirstOrDefault(d => d.CustomerId == customerid);
            return deposit;
        }

        public IEnumerable<Deposit> GetDeposits()
        {
            var dlist = dbcontext.depositdata.ToList();
            return dlist;

        }

        public void UpdateDeposit(Deposit updateDeposit)
        {
            dbcontext.depositdata.Update(updateDeposit);
            dbcontext.SaveChanges();
           // return updateDeposit;
            
        }
    }
}

