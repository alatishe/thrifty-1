﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thrifty.Abstractions;
using Thrifty.Abstractions.Services;
using Thrifty.Models;

namespace Thrifty.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {
        private ITransactionService _transactionService;
        private IAccountService _accountService;

        public TransactionController(ITransactionService transactionService, IAccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }

        // GET: api/Transaction
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Transaction/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Transaction
        [HttpPost]
        public async Task Post([FromBody] TransactionInput input)
        {
            await _transactionService.CreateTransaction(input.creditAccount, input.debitAccount, input.amount, input.description);
        }

        public class TransactionInput
        {
            public string creditAccount;
            public string debitAccount;
            public decimal amount;
            public string description;
        }
        
        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



    }

    internal class TransactionCreateDto
    {
        private int id;

    }
}
