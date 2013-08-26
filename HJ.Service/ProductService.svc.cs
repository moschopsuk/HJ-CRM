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
    public class ProductService : IProductService
    {
        int IProductService.Add(Product Product)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                context.Products.AddObject(Product);
                context.SaveChanges();
                return Product.ProductID;
            }
        }

        void IProductService.Update(Product Product)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                Product oldProduct = context.Products.Where(i => i.ProductID == Product.ProductID).First();

                oldProduct.isDiscontinued = Product.isDiscontinued;
                oldProduct.ProductCode = Product.ProductCode;
                oldProduct.ProductGroup = Product.ProductGroup;
                oldProduct.ProductName = Product.ProductName;
                oldProduct.ProductPrice = Product.ProductPrice;
                context.SaveChanges();
            }
        }

        void IProductService.Delete(int ProductID)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                Product oldProduct = context.Products.Where(i => i.ProductID == ProductID).First();
                context.DeleteObject(oldProduct);
                context.SaveChanges();
            }
        }

        IEnumerable<Product> IProductService.GetAll()
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                return context.Products.ToList();
            }
        }

        Product IProductService.Find(int ProductID)
        {
            using (var context = new DataBaseEntities(DBManager.EntityConnectionString))
            {
                return context.Products.Where(i => i.ProductID == ProductID).First();
            }
        }
    }
}
