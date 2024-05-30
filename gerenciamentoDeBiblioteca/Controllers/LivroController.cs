﻿using gerenciamentoDeBiblioteca.Models;
using gerenciamentoDeBiblioteca.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
    }
}
