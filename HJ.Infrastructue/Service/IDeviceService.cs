using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using HJ.Infrastructue.Model;

namespace HJ.Infrastructue.Service
{
    [ServiceContract]
    public interface IDeviceService
    {
        [OperationContract]
        int Add(Device Device);

        [OperationContract]
        void Update(Device Device);

        [OperationContract]
        void Delete(int DeviceID);

        [OperationContract]
        IEnumerable<Device> FindByCustomer(int customerId);

        [OperationContract]
        Device Find(int DeviceID);
    }
}
