using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplaudoChallenge.QueryResource;

namespace ApplaudoChallenge.Extensions
{
    public static class PaginateExtension
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query,IQueryObject queryObject)
        {
            if (queryObject.Page <= 0)
            {
                queryObject.Page = 1;
            }
            if (queryObject.PageSize <= 0)
            {
                queryObject.PageSize = 10;
            }
            return query.Skip((queryObject.Page-1)*queryObject.PageSize).Take(queryObject.PageSize);
        }
    }
}
