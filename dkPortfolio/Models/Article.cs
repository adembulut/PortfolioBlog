using System;
using System.Collections.Generic;

namespace dkPortfolio.Models
{
    public partial class Article
    {
        public Article()
        {
            this.Tags = new List<Tag>();
        }

        public int ID { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public Nullable<int> PictureID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> AccountID { get; set; }
        public virtual Account Account { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
