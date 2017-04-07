using System;
using System.Collections.Generic;

namespace dkPortfolio.Models
{
    public partial class Tag
    {
        public Tag()
        {
            this.Articles = new List<Article>();
        }

        public int ID { get; set; }
        public string Textt { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
