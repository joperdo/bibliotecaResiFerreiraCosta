﻿using gerenciamentoDeBiblioteca.Models;

namespace gerenciamentoDeBiblioteca.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
        Task<UsuarioModel> Adicionar(object usuarioModel);
    }
}
