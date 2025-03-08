using AutoMapper;
using BackendSeguros.Models;
using BackendSeguros.Models.Dtos.ClienteDTO;
using BackendSeguros.Models.Dtos.CoberturaDTO;
using BackendSeguros.Models.Dtos.CorredorDTO;
using BackendSeguros.Models.Dtos.PolizaDTO;
using BackendSeguros.Models.Dtos.RamosDTO;
using BackendSeguros.Models.Dtos.UsuarioDTO;
using BackendSeguros.Repositorio;

namespace BackendSeguros.Mappers
{
    public class MappearClass : Profile
    {
        public MappearClass()
        {
            //DTO RAMO
            CreateMap<Ramo, CrearRamoDto>().ReverseMap();
            CreateMap<Ramo, RamoDto>().ReverseMap();

            
            //DTO RAMO
            CreateMap<Cobertura, CoberturaDto>().ReverseMap();
            CreateMap<Cobertura, CrearCoberturaDto>().ReverseMap();
            CreateMap<Cobertura, ActualizarCoberturaDto>().ReverseMap();


            //DTOCORREDOR
            CreateMap<Corredor, CorredorDTO>().ReverseMap();
            CreateMap<Corredor, CrearCorredorDTO>().ReverseMap();
            CreateMap<Corredor, ActualizarCorredorDTO>().ReverseMap();


            CreateMap<Usuario, CreaRUsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDatosDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Cliente, CrearClienteDto>().ReverseMap();

            CreateMap<Poliza, CrearPolizaDto>().ReverseMap();
            CreateMap<Poliza, PolizaDatosDto>().ReverseMap();
            CreateMap<Poliza, ActualizarPolizaDto>().ReverseMap();


        }


    }
}
