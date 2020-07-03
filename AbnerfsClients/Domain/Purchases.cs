using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbnerfsClients.Domain
{
    public enum PaymentMethodEnum
    {
        Other = 0,
        Transfer = 1,
        Boleto = 2,
        PicPay = 3,
        Paypal = 4,
    }


    public class Purchases
    {
        public int Id { get; set; }
        public int ClientID { get; set; }
        public int PluginID { get; set; }
        public virtual Client Client { get; set; }
        public virtual Plugins Plugin { get; set; }
        public DateTime PurchasedAt { get; set; }
        public string PricePayed { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
    }
}
