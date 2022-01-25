using System.Collections.Generic;

namespace HuoChePiao.entity
{
    public class Filter
    {
        public List<FilterItem> filter { get; set; }
        public List<SortItem> sort { get; set; }
    }
}