using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;

using HJ.DataAccess;
using HJ.Infrastructue.Model;
using HJ.Infrastructue.Service;

namespace HJ.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class OrderService : IOrderService
    {
        int IOrderService.Add(Order Order)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                context.Orders.AddObject(Order);
                context.SaveChanges();
                return Order.OrderID;
            }
        }

        void IOrderService.Update(Order Order)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                Order oldOrder = context.Orders.Where(i => i.OrderID == Order.OrderID).First();
                oldOrder = Order;
                context.SaveChanges();
            }
        }

        void IOrderService.Delete(int OrderID)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                Order oldOrder = context.Orders.Where(i => i.OrderID == OrderID).First();
                context.DeleteObject(oldOrder);
                context.SaveChanges();
            }
        }

        IEnumerable<OrderLine> IOrderService.OrderDetails(int OrderID)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                return context.Orders.First(i => i.OrderID == OrderID).OrderLines.ToList();
            }
        }

        Order IOrderService.Find(int OrderID)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                return context.Orders.First(i => i.OrderID == OrderID);
            }
        }
    }
}
