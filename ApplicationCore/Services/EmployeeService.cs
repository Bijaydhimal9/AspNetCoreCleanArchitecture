using ApplicationCore.DomainModel;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Services.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        public EmployeeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitofwork = unitOfWork;
        }
        public async Task CreateAsync(EmployeeDM model)
        {
            try
            {
                Validate.ValidateArgumentNotNull(model, nameof(model));
                Validate.ValidateArgumentNotNullOrEmpty(model.FirstName, nameof(model.FirstName));
                Validate.ValidateArgumentNotNullOrEmpty(model.LastName, nameof(model.LastName));
                Validate.ValidateArgumentNotNullOrEmpty(model.Email, nameof(model.Email));
                Validate.ValidateArgumentNotNullOrEmpty(model.Address, nameof(model.Address));
                var data = _mapper.Map<Employee>(model);
              await  _unitofwork.EmployeeRepository.CreateAsync(data);
                _unitofwork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                Validate.ValidateArgumentNotNullOrEmpty(id, nameof(id));
                var emp = await _unitofwork.EmployeeRepository.GetByAsync(x=> x.Id == id);
                Validate.ValidateArgumentNotNull(emp, nameof(emp));
                await _unitofwork.EmployeeRepository.DeleteAsync(emp);
                _unitofwork.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmployeeDM> GetBy(int id)
        {
            var emp = await _unitofwork.EmployeeRepository.GetByAsync(x => x.Id == id);
            var data = _mapper.Map<EmployeeDM>(emp);
            return data;
        }

        public async Task<IReadOnlyList<EmployeeDM>> ListAllAsync()
        {
            var emp = await _unitofwork.EmployeeRepository.ListAllAsync();
            var data = _mapper.Map<List<EmployeeDM>>(emp);
            return data;
        }

        public async Task UpdateAsync(EmployeeDM model)
        {
            try
            {
                Validate.ValidateArgumentNotNull(model, nameof(model));
                var emp = _mapper.Map<Employee>(model);
                await _unitofwork.EmployeeRepository.UpdateAsync(emp);
                _unitofwork.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
