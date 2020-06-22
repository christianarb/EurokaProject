using AutoMapper;
using Netcore.Application.Dtos;
using Netcore.Domain.Agregates.EmpleadoAgg;

namespace Netcore.Application.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Entity to Dto

            //CreateMap<ClientePorEmailReadModel, EmpleadoDto>();
            CreateMap<Empleado, EmpleadoDto>();
            CreateMap<EmpleadoReadModel, EmpleadoDto>();

            #endregion

            #region Dto to Entity

            CreateMap<EmpleadoDto, Empleado>();
            CreateMap<EmpleadoDto, EmpleadoReadModel>();
            #endregion

        }
    }
}
