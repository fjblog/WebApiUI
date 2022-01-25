using System.Collections.Generic;

namespace HuoChePiao.entity
{
    public class AllTrainType
    {
        public List<AllTrainType_ListItem> list { get; set; }
        public string departureCityName { get; set; }
        public string arrivalCityName { get; set; }
    }
}