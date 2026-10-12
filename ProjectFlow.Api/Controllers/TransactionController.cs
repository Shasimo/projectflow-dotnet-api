
using Microsoft.AspNetCore.Mvc;
using ProjectFlow.Models;
using ProjectFlow.Dtos;

namespace ProjectFlow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private static readonly List<Transaction> transactions = new();
    private static int nextId = 1;

    // CREATE
    [HttpPost]
    public IActionResult Create(CreateTransactionDto dto)
    {
        Transaction transaction = new Transaction
        {
            Id = nextId++,
            Amount = dto.Amount,
            Date = dto.Date,
            Description = dto.Description,
            Type = dto.Type,
            AccountId = dto.AccountId,
            CategoryId = dto.CategoryId
        };

        transactions.Add(transaction);
        return Ok(transaction);
    }

    // GET ALL
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(transactions);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        foreach (Transaction transaction in transactions)
        {
            if (transaction.Id == id)
            {
                return Ok(transaction);
            }
        }

        return NotFound();
    }

    // UPDATE
    [HttpPut("{id}")]
    public IActionResult Update(int id, CreateTransactionDto dto)
    {
        foreach (Transaction transaction in transactions)
        {
            if (transaction.Id == id)
            {
                transaction.Amount = dto.Amount;
                transaction.Date = dto.Date;
                transaction.Description = dto.Description;
                transaction.Type = dto.Type;
                transaction.AccountId = dto.AccountId;
                transaction.CategoryId = dto.CategoryId;

                return Ok(transaction);
            }
        }

        return NotFound();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        foreach (Transaction transaction in transactions)
        {
            if (transaction.Id == id)
            {
                transactions.Remove(transaction);
                return NoContent();
            }
        }

        return NotFound();
    }
}

