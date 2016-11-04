using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override void Delete(Product product)
        {
            product.IsDeleted = true;
        }

        public override IQueryable<Product> All()
        {
            return base.All().Where(x=> x.IsDeleted == false);
        }

        public Product Find(int id)
	    {
	        return this.All().FirstOrDefault(p => p.ProductId == id);
	    }

	    public IQueryable<Product> 取得資料依筆數排序(int takeSize)
	    {
	        return this.All().OrderByDescending(p=>p.ProductId).Take(takeSize);
	    }

    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}