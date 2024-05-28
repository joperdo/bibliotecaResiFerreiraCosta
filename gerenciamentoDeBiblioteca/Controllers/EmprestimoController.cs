using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gerenciamentoDeBiblioteca.Models;
using gerenciamentoDeBiblioteca.Repositorios;
using gerenciamentoDeBiblioteca.Repositorios.Interfaces;
using gerenciamentoDeBiblioteca.Service.InterfacesService;
using gerenciamentoDeBiblioteca.Dtos;

namespace gerenciamentoDeBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {

        private readonly IEmprestimoService _emprestimoService;

        public EmprestimoController(IEmprestimoService emprestimoService) 
        {
            _emprestimoService =emprestimoService;
        }
    

        [HttpGet("{id}")]
        public async Task<ActionResult> BuscarPorId(int id)
        {
            var emprestimoDTO = await _emprestimoService.BuscarPorId(id);
            if (emprestimoDTO == null)
            {
                return NotFound("Emprestimo não encontrado.");
            }

            return Ok(emprestimoDTO);
        }
        [HttpPost]
        public async Task<ActionResult> Adicionar(PostEmprestimoDTO postEmprestimoDTO)
        {
            var disponivel = await _emprestimoService.VerificaDisponibilidadeAsync(postEmprestimoDTO.LivroId);
            if (!disponivel)
            {
                return BadRequest("O livro no momento não está disponível para emprestimo.");
            }

            postEmprestimoDTO.DataEmprestimo = DateTime.Now;
            postEmprestimoDTO.Entregue = false;
            var emprestimoDTOAdicionado = await _emprestimoService.Adicionar(postEmprestimoDTO);
            if (emprestimoDTOAdicionado == null)
            {
                return BadRequest("Ocorreu um erro ao adicionar o emprestimo. ");
            }
            return Ok("Emprestimo adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] EmprestimoDTO emprestimoDTO)
        {
            emprestimoDTO.Id = id;
            EmprestimoDTO emprestimo = await _emprestimoService.Atualizar(emprestimoDTO, id);
            return Ok(emprestimo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            var emprestimoDTOExcluido = await _emprestimoService.Apagar(id);
            if (emprestimoDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o emprestimo.");
            }

            return Ok(new { message = "Emprestimo excluído com sucesso!" });
        }
    }
}
    

