using AutoMapper;
using System;
using System.Threading.Tasks;
using Netcore.Application.Contracts;
using Netcore.Application.Dtos;
using Netcore.Domain;

using Netcore.Infrastructure.Crosscutting.ExceptionsTypes;
using Netcore.Infrastructure.Crosscutting.Resources;
using Netcore.Domain.Agregates.EmpleadoAgg;
using System.Collections.Generic;

namespace Template.Netcore.Application.Implementations
{
    public class EmpleadoAppService : IEmpleadoAppService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IEmpleadoRepository _empleadoRepository;
        readonly IMapper _mapper;

        public EmpleadoAppService(IUnitOfWork unitOfWork, IEmpleadoRepository empleadoRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
            _empleadoRepository = empleadoRepository ?? throw new ArgumentNullException("clienteRepository");
            _mapper = mapper ?? throw new ArgumentNullException("mapper");
        }

        public async Task<EmpleadoDto> Agregar(EmpleadoDto empleado)
        {
            var empleadoEntity = _mapper.Map<EmpleadoDto, Empleado>(empleado);


            // _empleadoRepository.Agregar();
            _empleadoRepository.Add(empleadoEntity);
            await _unitOfWork.CommitAsync();

            empleado.Id = empleadoEntity.Id;
            return empleado;
        }

        public async Task<List<EmpleadoDto>> ObtenerTodos ()
        {
            /*var items = await _empleadoRepository.ObtenerTodos();
            return _mapper.Map<EmpleadoReadModel, EmpleadoDto>(items);*/

            var items = (List<EmpleadoReadModel>)await _empleadoRepository.ObtenerTodos();
            return _mapper.Map<List<EmpleadoReadModel>, List<EmpleadoDto>>(items);
        }

        public async Task<EmpleadoDto> ObtenerPorId(int id)
        {
            var items = await _empleadoRepository.ObtenerPorId(id);
            return _mapper.Map<EmpleadoReadModel, EmpleadoDto>(items);
        }

        /*public async Task<EmpleadoDto> ObtenerPorEmail(string email)
        {
            var cliente = await _clienteRepository.ObtenerPorEmail(email);
            return _mapper.Map<ClientePorEmailReadModel, EmpleadoDto>(cliente);
        }

        public async Task<EmpleadoDto> Agregar(EmpleadoDto cliente)
        {
            var clienteEntity = _mapper.Map<EmpleadoDto, Cliente>(cliente);

            var clienteExiste = await _clienteRepository.ObtenerPorEmail(cliente.Email);
            if(clienteExiste !=null)
                throw new EntityDuplicateException(
                    string.Format(Messages.EntidadDuplicada, "El email"));

            clienteEntity.Agregar();
            _clienteRepository.Add(clienteEntity);
            await _unitOfWork.CommitAsync();

            cliente.Id = clienteEntity.Id;
            return cliente;
        }*/
    }
}
