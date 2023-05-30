using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessMobile.Model
{
    public class StoreInfo
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public int Connected { get; set; }
        public int Seller { get; set; }
        public double PaidAmount { get; set; }
        public double UnpaidAmount { get; set; }
    }
}
