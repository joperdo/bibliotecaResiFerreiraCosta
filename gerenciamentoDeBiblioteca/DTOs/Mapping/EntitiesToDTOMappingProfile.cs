using AutoMapper;
using gerenciamentoDeBiblioteca.Dtos;
using gerenciamentoDeBiblioteca.Models;
using gerenciamentoDeBiblioteca.Service;

namespace gerenciamentoDeBiblioteca.DTOs.Mapping
{
    public class EntitiesToDTOMappingProfile :Profile
    {
        public EntitiesToDTOMappingProfile() 
        {
            CreateMap<EmprestimoModel, EmprestimoDTO>().ReverseMap();
            CreateMap<EmprestimoModel, PostEmprestimoDTO>().ReverseMap();
        }
    }
}
