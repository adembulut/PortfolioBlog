using System;
using System.Collections.Generic;

namespace dkPortfolio.Models
{
    public partial class Work
    {
        public int ID { get; set; }
        public Nullable<int> AccountID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public Nullable<int> PictureID { get; set; }
        public string LongText { get; set; }
        public virtual Account Account { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
