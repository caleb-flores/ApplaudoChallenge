using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ApplaudoChallenge.QueryResource
{
    interface IQueryObject
    {
        int Page { get; set; }
        int PageSize { get; set; }
        string SortBy { get; set; }
        bool IsSortAscending { get; set; }
    }
}
