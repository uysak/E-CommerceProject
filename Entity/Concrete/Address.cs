using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Address
    {
        public string Line1 { get; set; } // Adres satırı 1
        public string Line2 { get; set; } // Adres satırı 2
        public string City { get; set; } // Şehir
        public string Province { get; set; } // İlçe / Eyalet
        public string PostalCode { get; set; } // Posta Kodu
        public string Country { get; set; } // Ülke
    }
}
