using System;
using System.Collections.Generic;

namespace dkPortfolio.Models
{
    public partial class Mail
    {
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
