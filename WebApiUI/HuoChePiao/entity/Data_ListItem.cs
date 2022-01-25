using System.Collections.Generic;

namespace HuoChePiao.entity
{
    public class Data_ListItem
    {
        public int trainId { get; set; }
        public string trainNum { get; set; }
        public int trainType { get; set; }
        public string trainTypeName { get; set; }
        public string departStationName { get; set; }
        public string destStationName { get; set; }
        public string departDepartTime { get; set; }
        public string destArriveTime { get; set; }
        public int duration { get; set; }
        public List<PricesItem> prices { get; set; }
        public int durationDay { get; set; }
        public int departStationType { get; set; }
        public int destStationType { get; set; }
        public int saleStatus { get; set; }
        public int departStationId { get; set; }
        public int destStationId { get; set; }
        public string startSaleTime { get; set; }
        public int canChooseSeat { get; set; }
        public string memo { get; set; }
        public int departureCityCode { get; set; }
        public int arrivalCityCode { get; set; }
        public string departureCityName { get; set; }
        public string arrivalCityName { get; set; }
        public int upOrDown { get; set; }
        public string trainStartDate { get; set; }
        public string accessByIdcard { get; set; }
        public string durationStr { get; set; }
        public string departStationTypeName { get; set; }
        public string destStationTypeName { get; set; }
        public int sellOut { get; set; }
    }
}