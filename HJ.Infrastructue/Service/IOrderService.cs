using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using HJ.Infrastructue.Model;

namespace HJ.Infrastructue.Service
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        int Add(Order Order);

        [OperationContract]
        void Update(Order Order);

        [OperationContract]
        void Delete(int OrderID);

        [OperationContract]
        IEnumerable<OrderLine> OrderDetails(int OrderID);

        [OperationContract]
        Order Find(int OrderID);
    }
}
