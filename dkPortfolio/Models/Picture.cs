using System;
using System.Collections.Generic;

namespace dkPortfolio.Models
{
    public partial class Picture
    {
        public Picture()
        {
            this.Accounts = new List<Account>();
            this.Articles = new List<Article>();
            this.Works = new List<Work>();
        }

        public int ID { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
