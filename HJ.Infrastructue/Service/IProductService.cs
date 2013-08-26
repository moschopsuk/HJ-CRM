using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using HJ.Infrastructue.Model;

namespace HJ.Infrastructue.Service
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        int Add(Product product);

        [OperationContract]
        void Update(Product product);

        [OperationContract]
        void Delete(int ProductID);

        [OperationContract]
        IEnumerable<Product> GetAll();

        [OperationContract]
        Product Find(int ProductID);
    }
}
