using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Contstans
{
    public static class Messages//static yaptıgında newlemene gerek kalmaz sabit olduğu içinde öyle yaptık
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        public static string MaintenanceTime="sistem bakımda";
        public static string ProductsListed="ürünler listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="yetkiniz yok.";
    }
}
