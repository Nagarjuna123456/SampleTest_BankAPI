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
    public class DepositController : ControllerBase
    {
        public readonly IDeposit _depositService;
        public DepositController(IDeposit deposit)
        {
            _depositService = deposit;
        }

        [HttpGet]
        [Route("api/depoist/getdeposits")]
        public IActionResult GetDeposits()
        {
            //return _depositService.GetDeposits();
            return Ok(_depositService.GetDeposits());
        }
        [HttpGet]
        [Route("api/depoist/getDepositByCustomerID/{customerid}")]
        public Deposit GetDepositByCustomerID(string customerid)
        {
            return _depositService.GetDepositByCustomerID(customerid);
        }
        [HttpPost]
        [Route("api/deposit/add")]
        public Deposit AddDeposit(Deposit deposit)
        {
            return _depositService.AddDeposit(deposit);

        }
        [HttpDelete]
        [Route("api/deposit/DeleteDeposit/{id}")]
        public IActionResult DeleteDeposit(int id)
        {
            _depositService.DeleteDeposit(id);
            return Ok("You have Deleted the Record Successfully!");
        }

        [HttpPost]
        [Route("api/deposit/UpdateDeposit")]
        public  IActionResult UpdateDeposit(Deposit deposit)
        {
            _depositService.UpdateDeposit(deposit);
            return Ok("Record updated Successfully!");

        }
    }
}
