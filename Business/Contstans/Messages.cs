using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contstans
{
    public static class Messages//static yaptıgında newlemene gerek kalmaz sabit olduğu içinde öyle yaptık
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        internal static string MaintenanceTime="sistem bakımda";
        internal static string ProductsListed="ürünler listelendi";
    }
}
