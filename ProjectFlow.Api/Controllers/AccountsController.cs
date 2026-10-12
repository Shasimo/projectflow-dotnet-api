
using Microsoft.AspNetCore.Mvc;
using ProjectFlow.Models;

namespace ProjectFlow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private static readonly List<Account> accounts = new();


    [HttpPost]
    public IActionResult Create(Account account) {
        if (accounts.Count == 0){ account.Id = 1;}
        else{account.Id = accounts.Max(a => a.Id) + 1;}
        accounts.Add(account);
        return CreatedAtAction(nameof(GetById), new { id = account.Id }, account);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(accounts);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        foreach (Account account in accounts)
        {
            if (account.Id == id){
                return Ok(account);
            }
        }

        return NotFound();
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] string newName)
    {
        foreach (Account account in accounts){
            if (account.Id == id){
                account.Name = newName;
                return Ok(account);}
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        foreach (Account account in accounts){
            if (account.Id == id){
                accounts.Remove(account);
                return NoContent();
            }
        }

        return NotFound();
    }
}


