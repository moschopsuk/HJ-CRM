using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.Data;

using HJ.DataAccess;
using HJ.Infrastructue.Service;
using HJ.Infrastructue.Model;

namespace HJ.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CustomerService : ICustomerService
    {
        int ICustomerService.Add(Customer Customer)
        {
            using (var context = new DataBaseEntities())
            {
                try
                {
                    context.Customers.AddObject(Customer);
                    context.ObjectStateManager.ChangeObjectState(Customer, EntityState.Added);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new FaultException("Could not create Customer");
                }

                return Customer.CustomerID;
            }
        }

        void ICustomerService.Update(Customer Customer)
        {
            using (var context = new DataBaseEntities())
            {
                try 
                {
                    context.Customers.Attach(Customer);
                    context.ObjectStateManager.ChangeObjectState(Customer, EntityState.Modified);
                    context.SaveChanges();                  
                }
                catch (Exception)
                {
                    throw new FaultException("Error updating customer id#" + Customer.CustomerID);
                }
            }
        }

        void ICustomerService.Delete(int CustomerID)
        {
            using (var context = new DataBaseEntities())
            {
                try
                {
                    Customer cust = context.Customers
                                    .Where(c => c.CustomerID == CustomerID)
                                    .FirstOrDefault();

                    context.DeleteObject(cust);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new FaultException("Error deleting customer id#" + CustomerID);
                }
            }
        }

        IEnumerable<Customer> ICustomerService.GetAll()
        {
            using (var context = new DataBaseEntities())
            {
                try
                {
                    return context.Customers.ToList();
                }
                catch (Exception)
                {
                    throw new FaultException("Failed to get Customers");
                }
            }
        }

        Customer ICustomerService.Find(int CustomerID)
        {
            using (var context = new DataBaseEntities())
            {
                try
                {
                    Customer cust = context.Customers
                                    .Where(c => c.CustomerID == CustomerID)
                                    .FirstOrDefault();

                    if (cust == null) throw new FaultException("Customer Not Found");

                    return cust;
                }
                catch (Exception)
                {
                    throw new FaultException("Error finding user");
                }
            }
        }
    }
}
