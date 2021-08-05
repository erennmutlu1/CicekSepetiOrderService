using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CicekSepetiOrderService.Models.CicekSepetiModel;

namespace CicekSepetiOrderService.DBContext
{
    public class CicekSepetiDBContext : DbContext
    {

        public DbSet<CicekSepetiOrders>CicekSepetiOrders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CicekSepetiOrderDatabase;Integrated Security=True");
        }

    }
}
