using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyMagazine.Models
{
    public class PhoneContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

    }
    public class DBInitializer : DropCreateDatabaseAlways<PhoneContext>
    {
        protected override void Seed(PhoneContext context)
        {
            context.Phones.Add(new Phone { Name = "Huawei P20", Price = 10000, Producer = "Huawei" });
            context.Phones.Add(new Phone { Name = "Galaxy A50", Price = 13500, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "Lumia 510", Price = 7600, Producer = "WindowsPhone" });

            context.Phones.Add(new Phone { Name = "Huawei p Smart", Price = 8000, Producer = "Huawei" });
            context.Phones.Add(new Phone { Name = "Galaxy S8", Price = 28000, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "Lumia 640", Price = 8600, Producer = "WindowsPhone" });

            context.Phones.Add(new Phone { Name = "Galaxy Node 5", Price = 28000, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "Iphone XS Max Pro", Price = 46000, Producer = "Apple" });
            context.Phones.Add(new Phone { Name = "Iphone 8", Price = 18000, Producer = "Apple" });

            context.Phones.Add(new Phone { Name = "Xiaomi Redmi note 5", Price = 4000, Producer = "Xiaomi" });
            context.Phones.Add(new Phone { Name = "Galaxy SE", Price = 15600, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "Lumia 1520", Price = 9500, Producer = "WindowsPhone" });

            context.Phones.Add(new Phone { Name = "Huawey Y5", Price = 9000, Producer = "Huawei" });
            context.Phones.Add(new Phone { Name = "Galaxy A30", Price = 11500, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "iphone 7", Price = 15500, Producer = "Apple" });

            context.Phones.Add(new Phone { Name = "Huawei p20", Price = 40000, Producer = "Huawei" });
            context.Phones.Add(new Phone { Name = "Galaxy a50", Price = 80000, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "Limia 510", Price = 25000, Producer = "WindowsPhone" });

            context.Phones.Add(new Phone { Name = "Huawei p0", Price = 40000, Producer = "Huawei" });
            context.Phones.Add(new Phone { Name = "Galaxy a0", Price = 8000, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "Limia 50", Price = 25000, Producer = "WindowsPhone" });

            context.Phones.Add(new Phone { Name = "Xiaomi Lite 0", Price = 8000, Producer = "Xiaomi" });
            context.Phones.Add(new Phone { Name = "Iphone XS Max", Price = 52000, Producer = "Apple" });
            context.Phones.Add(new Phone { Name = "Iphone X", Price = 25000, Producer = "Apple" });

            context.Phones.Add(new Phone { Name = "Huawei", Price = 8600, Producer = "Huawei" });
            context.Phones.Add(new Phone { Name = "Galaxy", Price = 10000, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "Lumia", Price = 5600, Producer = "WindowsPhone" });

            context.Phones.Add(new Phone { Name = "Xiaomi", Price = 6500, Producer = "Xiaomi" });
            context.Phones.Add(new Phone { Name = "Galaxy Samsung", Price = 9500, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "iphone 7 S", Price = 13500, Producer = "Apple" });

            base.Seed(context);
        }
    }
}