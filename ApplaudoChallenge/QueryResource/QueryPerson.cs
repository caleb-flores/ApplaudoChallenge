using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplaudoChallenge.QueryResource
{
    public class QueryPerson : IQueryObject
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
    }
}
