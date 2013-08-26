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
    public class InvoiceService : IInvoiceService
    {
        int IInvoiceService.Add(Invoice Invoice)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                context.Invoices.AddObject(Invoice);
                context.SaveChanges();
                return Invoice.InvoiceID;
            }
        }

        void IInvoiceService.Update(Invoice Invoice)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                Invoice oldInvoice = context.Invoices.Where(i => i.InvoiceID == Invoice.InvoiceID).First();
                oldInvoice = Invoice;
                context.SaveChanges();
            }
        }

        void IInvoiceService.Delete(int InvoiceID)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                Invoice oldInvoice = context.Invoices.Where(i => i.InvoiceID == InvoiceID).First();
                context.DeleteObject(oldInvoice);
                context.SaveChanges();
            }
        }

        IEnumerable<Invoice> IInvoiceService.FindByCustomer(int customerId)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                return context.Customers.First(i => i.CustomerID == customerId).Invoices.ToList();
            }
        }

        Invoice IInvoiceService.Find(int InvoiceID)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                return context.Invoices.Where(i => i.InvoiceID == InvoiceID).First();
            }
        }
    }
}
