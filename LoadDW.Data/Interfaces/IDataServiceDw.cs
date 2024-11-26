using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadDW.Data.Entities.DW;
using LoadDW.Data.Result;

namespace LoadDW.Data.Interfaces
{
    public interface IDataServiceDw
    {
        Task<OperationResult> LoadDimEmployee();
        Task<OperationResult> LoadDimCustomer();
        Task<OperationResult> LoadDimProduct();
        Task<OperationResult> LoadDimShipper();
        Task<OperationResult> LoadDimSupplier();
        Task<OperationResult> LoadDHW();
    }
}
