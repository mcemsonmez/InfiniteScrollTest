using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfiniteScrollTest.Models
{
    public class PagingModel<T>
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 20;
        public int total { get; set; }
        public IEnumerable<T> List { get; set; }
    }
}