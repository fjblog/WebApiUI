using System.Collections.Generic;

namespace HuoChePiao.entity
{
    public class FilterItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<ProsItem> pros { get; set; }
    }
}