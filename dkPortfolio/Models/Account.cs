using System;
using System.Collections.Generic;

namespace dkPortfolio.Models
{
    public partial class Account
    {
        public Account()
        {
            this.Articles = new List<Article>();
            this.Works = new List<Work>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string About { get; set; }
        public string ShortAbout { get; set; }
        public Nullable<int> PictureID { get; set; }
        public bool isAdmin { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
