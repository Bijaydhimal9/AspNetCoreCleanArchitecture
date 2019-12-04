using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericAsyncRepository<Employee> EmployeeRepository { get;  }
        void Commit();

        void Dispose();
    }
}
