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
            context.Phones.Add(new Phone { Name = "Galaxy a0", Price = 80000, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "Limia 50", Price = 25000, Producer = "WindowsPhone" });

            context.Phones.Add(new Phone { Name = "Huawei", Price = 40000, Producer = "Huawei" });
            context.Phones.Add(new Phone { Name = "Galaxy", Price = 80000, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "Limia", Price = 25000, Producer = "WindowsPhone" });

            context.Phones.Add(new Phone { Name = "p20", Price = 40000, Producer = "Huawei" });
            context.Phones.Add(new Phone { Name = "a50", Price = 80000, Producer = "Samsung" });
            context.Phones.Add(new Phone { Name = "510", Price = 25000, Producer = "WindowsPhone" });
            base.Seed(context);
        }
    }
}