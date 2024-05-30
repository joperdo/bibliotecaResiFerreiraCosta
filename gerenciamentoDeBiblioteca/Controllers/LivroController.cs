using gerenciamentoDeBiblioteca.Models;
using gerenciamentoDeBiblioteca.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gerenciamentoDeBiblioteca.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<LivroModel>>> ListarTodosLivros()
        {
            List<LivroModel> livros = await _livroRepositorio.BuscarTodosLivros();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroModel>> BuscarPorId(int id)
        {
            LivroModel livro = await _livroRepositorio.BuscarPorId(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult<LivroModel>> Cadastrar([FromBody] LivroModel livroModel)
        {
            LivroModel livro = await _livroRepositorio.Adicionar(livroModel);
            return Ok(livro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LivroModel>> Atualizar([FromBody] LivroModel livroModel, int id)
        {
            livroModel.Id = id;
            LivroModel livro = await _livroRepositorio.Atualizar(livroModel, id);
            return Ok(livro);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _livroRepositorio.Apagar(id);
            return Ok(apagado);
        }

        [HttpGet("pesquisar/nome")]
        public async Task<ActionResult<List<LivroModel>>> PesquisarPorNome([FromQuery] string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return BadRequest("O parâmetro 'nome' não pode estar vazio.");
            }

            List<LivroModel> livros = await _livroRepositorio.PesquisarPorNome(nome);
            return Ok(livros);
        }

        [HttpGet("pesquisar/autor")]
        public async Task<ActionResult<List<LivroModel>>> PesquisarPorAutor([FromQuery] string autor)
        {
            if (string.IsNullOrWhiteSpace(autor))
            {
                return BadRequest("O parâmetro 'autor' não pode estar vazio.");
            }

            List<LivroModel> livros = await _livroRepositorio.PesquisarPorAutor(autor);
            return Ok(livros);
        }

        [HttpGet("pesquisar/categoria")]
        public async Task<ActionResult<List<LivroModel>>> PesquisarPorCategoria([FromQuery] string categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria))
            {
                return BadRequest("O parâmetro 'categoria' não pode estar vazio.");
            }

            List<LivroModel> livros = await _livroRepositorio.PesquisarPorCategoria(categoria);
            return Ok(livros);
        }

    }
}
