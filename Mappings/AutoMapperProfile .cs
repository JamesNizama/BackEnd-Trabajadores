using AutoMapper;
using BackEnd_Trabajadores.DTO;
using BackEnd_Trabajadores.Models.Entities;


namespace BackEnd_Trabajadores.Mappings
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Departamento, DepartamentoDTO>();
        }
    }
}
