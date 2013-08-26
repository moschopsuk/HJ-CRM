using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using HJ.Infrastructue.Model;

namespace HJ.Infrastructue.Service
{
    [ServiceContract]
    public interface IInvoiceService
    {
        [OperationContract]
        int Add(Invoice Invoice);

        [OperationContract]
        void Update(Invoice Invoice);

        [OperationContract]
        void Delete(int InvoiceID);

        [OperationContract]
        IEnumerable<Invoice> FindByCustomer(int customerId);

        [OperationContract]
        Invoice Find(int InvoiceID);
    }
}
