using APICrud.Context;
using APICrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;

namespace APICrud.Controller;

[Route("api/[controller]")]
[ApiController]
public class PessoasController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public PessoasController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
    {
        return await _appDbContext.Pessoas.ToListAsync();   
    }

    [HttpGet("{pessoaId}")]
    public async Task<ActionResult<Pessoa>> GetPessoaById(int pessoaId)
    {
        Pessoa pessoa = await _appDbContext.Pessoas.FindAsync(pessoaId);
        if (pessoa == null)
        {
            NotFound();
        }
        return pessoa;
    }

    [HttpPost]
    public async Task<ActionResult<Pessoa>> CreatePessoa(Pessoa pessoa)
    {
        await _appDbContext.Pessoas.AddAsync(pessoa);
        await _appDbContext.SaveChangesAsync();
        return Ok(pessoa);
    }

    [HttpPut]
    public async Task<ActionResult> UpdatePessoa(Pessoa pessoa)
    {      
        _appDbContext.Pessoas.Update(pessoa);
        await _appDbContext.SaveChangesAsync();
        return Ok(pessoa);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePessoa(int id)
    {
        Pessoa pessoa = await _appDbContext.Pessoas.FindAsync(id);

        if (pessoa == null || pessoa.Id == 0)
        {
            return NotFound();
        }

        _appDbContext.Remove(pessoa);
        await _appDbContext.SaveChangesAsync();
        return Ok();

    }
}




