using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiUI.BaiDu
{
    public class baiduRoot
    {
        public string city { get; set; }
        public string update_time { get; set; }
        public string date { get; set; }
        public List<WeatherItem> weather { get; set; }
    }
}
