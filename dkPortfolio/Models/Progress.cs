using System;
using System.Collections.Generic;

namespace dkPortfolio.Models
{
    public partial class Progress
    {
        public int ID { get; set; }
        public string Data { get; set; }
        public Nullable<int> Value { get; set; }
    }
}
