using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using HJ.Infrastructue.Model;

namespace HJ.Infrastructue.Service
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        int Add(Customer customer);

        [OperationContract]
        void Update(Customer customer);

        [OperationContract]
        void Delete(int CustomerID);

        [OperationContract]
        IEnumerable<Customer> GetAll();

        [OperationContract]
        Customer Find(int CustomerID);
    }
}
