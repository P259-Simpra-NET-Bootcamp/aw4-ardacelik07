using Microsoft.AspNetCore.Mvc;
using SimApi.Base;
using SimApi.Data;
using SimApi.Data.Context;
using SimApi.Operation;
using SimApi.Schema;
using System.Linq;

namespace SimApi.Service;

[EnableMiddlewareLogger]
[ResponseGuid]
[Route("simapi/v1/[controller]")]
[ApiController]
public class TransactionReportController : ControllerBase
{
    private readonly ITransactionReportService transactionService;
    private readonly SimEfDbContext _db;
    public TransactionReportController(ITransactionReportService transactionService, SimEfDbContext db)
    {
        this.transactionService = transactionService;
        _db = db;
    }

    [HttpGet]
    public List<TransactionView> GetAll()
    {
         var transactionList = _db.TransactionReport.ToList();
          return transactionList;
        
    } 

    [HttpGet("{id}")]
    public TransactionView GetById([FromRoute] int id)
    {
        var transaction = _db.TransactionReport.FirstOrDefault(x=>x.Id == id);
        return transaction;
    }

    [HttpGet("ByReferenceNumber/{ReferenceNumber}")]
    public TransactionView GetByReferenceNumber([FromRoute] string ReferenceNumber)
    {
        var transactions = _db.TransactionReport.FirstOrDefault(x => x.ReferenceNumber.Equals(ReferenceNumber));
        return transactions;
    }

    [HttpGet("ByAccountId/{AccountId}")]
    public TransactionView GetByAccountId([FromRoute] int AccountId)
    {
        var transactions = _db.TransactionReport.FirstOrDefault(x => x.AccountId == AccountId);
        return transactions;
    }


    [HttpGet("ByCustomerId/{CustomerId}")]
    public TransactionView GetByCustomerId([FromRoute] int CustomerId)
    {
        var transactions = _db.TransactionReport.FirstOrDefault(x => x.CustomerId == CustomerId);
        return transactions;
    }
}
