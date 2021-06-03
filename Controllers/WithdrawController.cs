using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleTest.Models;
using SampleTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {
        private readonly IWithdraw withdrawService;

        public WithdrawController(IWithdraw service)
        {
            withdrawService = service;
        }
        [HttpGet]
        [Route("api/withdraw/GetWithdraws")]
        public IEnumerable<Withdraw> GetWithdraws()
        {
            return withdrawService.GetWithdraws();
        }
        [HttpPost]
        [Route("api/Withdraw/add")]
        public Withdraw createWithdraw(Withdraw add)
        {
            return withdrawService.createWithdraw(add);

        }
        [HttpDelete]
        [Route("api/Withdraw/DeleteWithdraw/{id}")]
        public IActionResult DeleteWithdraw(int id)
        {
            withdrawService.DeleteWithdraw(id);
            return Ok("You have Deleted the Record Successfully!");
        }

        [HttpGet]
        [Route("api/Withdraw/TransactionHistory")]
        public List<TranHistory> TransactionHistory()
        {
            return withdrawService.TransactionHistory();
        }

    }
}
