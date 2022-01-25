using System.Collections.Generic;

namespace HuoChePiao.entity
{
    public class PricesItem
    {
        public int leftNumber { get; set; }
        public string seatStatus { get; set; }
        public int seat { get; set; }
        public double price { get; set; }
        public string stuPrice { get; set; }
        public double promotionPrice { get; set; }
        public int resId { get; set; }
        public List<DetailItem> detail { get; set; }
        public string priceMemo { get; set; }
        public string seatName { get; set; }
    }
}