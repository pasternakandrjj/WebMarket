using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyMagazine.Models
{
    public class DBInitializer : DropCreateDatabaseAlways<PhoneContext>
    {
        protected override void Seed(PhoneContext context)
        {
            context.Phones.Add(new Phone { Name = "Huawei p20", Price = 40000, Producer = "Huawei" });
            context.Phones.Add(new Phone { Name = "Galaxy a50", Price = 80000, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "Limia 510", Price = 25000, Producer = "WindowsPhone" });

            context.Phones.Add(new Phone { Name = "Huawei p0", Price = 40000, Producer = "Huawei" });
            context.Phones.Add(new Phone { Name = "Galaxy a0", Price = 8000, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "Limia 50", Price = 25000, Producer = "WindowsPhone" });

            context.Phones.Add(new Phone { Name = "Galaxy a0", Price = 80000, Producer = "Xiaomi" });
            context.Phones.Add(new Phone { Name = "Iphone XS Max Pro", Price = 25000, Producer = "Apple" }); 
            context.Phones.Add(new Phone { Name = "Iphone 50", Price = 25000, Producer = "Apple" });

            context.Phones.Add(new Phone { Name = "Huawei", Price = 40000, Producer = "Huawei" });
            context.Phones.Add(new Phone { Name = "Galaxy", Price = 80000, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "Limia", Price = 50000, Producer = "WindowsPhone" });

            context.Phones.Add(new Phone { Name = "p20", Price = 4000, Producer = "Huawei" });
            context.Phones.Add(new Phone { Name = "a50", Price = 75000, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "iphone 7", Price = 55000, Producer = "Apple" });

            base.Seed(context);
        }
    }
}