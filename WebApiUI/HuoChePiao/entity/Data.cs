using System.Collections.Generic;

namespace HuoChePiao.entity
{
    public class Data
    {
        public int count { get; set; }
        public string stores { get; set; }
        public string unsureStores { get; set; }
        public List<TrainTypeDetailsItem> trainTypeDetails { get; set; }
        public string streamId { get; set; }
        public string remark { get; set; }
        public string isFinish { get; set; }

        //int超出报错
        //public int lastTime { get; set; }
        public string lastTime { get; set; }

        public string expire { get; set; }
        public string freshUrl { get; set; }
        public string reserveUrls { get; set; }
        public string crossURL { get; set; }
        public string origin { get; set; }
        public List<Data_ListItem> list { get; set; }
        public AllTrainType allTrainType { get; set; }
        public Filter filter { get; set; }
    }
}
