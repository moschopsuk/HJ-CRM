using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;

using HJ.DataAccess;
using HJ.Infrastructue.Service;
using HJ.Infrastructue.Model;

namespace HJ.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DeviceService : IDeviceService
    {
        int IDeviceService.Add(Device Device)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                context.Devices.AddObject(Device);
                context.SaveChanges();
                return Device.DeviceID;
            }
        }

        void IDeviceService.Update(Device Device)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                Device oldDevice = context.Devices.Where(i => i.DeviceID == Device.DeviceID).First();
                oldDevice = Device;
                context.SaveChanges();
            }
        }

        void IDeviceService.Delete(int DeviceId)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                Device oldDevice = context.Devices.Where(i => i.DeviceID == DeviceId).First();
                context.DeleteObject(oldDevice);
                context.SaveChanges();
            }
        }

        IEnumerable<Device> IDeviceService.FindByCustomer(int customerId)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                return context.Devices.Where(i => i.CustomerID == customerId).ToList();
            }
        }

        Device IDeviceService.Find(int DeviceId)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                return context.Devices.First(i => i.DeviceID == DeviceId);
            }
        }
    }
}
