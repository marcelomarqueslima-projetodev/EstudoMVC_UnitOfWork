using EstudoMVC2.Data;
using EstudoMVC2.Models;
using EstudoMVC2.Repository;
using Microsoft.EntityFrameworkCore;

namespace EstudoMVC2.UnitOfWork
{
    public class UnitOfWorkApp : DbContext
    {
        ApplicationDbContext context = new ApplicationDbContext();
        Repository.Repository<Product> productRepository;

        public Repository<Product> ProductRepository
        {
            get
            {
                if(productRepository == null)
                {
                    productRepository = new Repository.Repository<Product>(context);
                }
                return productRepository;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
