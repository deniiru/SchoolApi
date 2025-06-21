using School.Database.Dtos;
using School.Database.Entities;
using School.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Database.QueryExtensions
{
    public static class GradesQueryExtensions
    {
        public static IQueryable<Grade> SortBy(this IQueryable<Grade> query, GradesSortingDto sorting)
        {
            if (sorting == null)
                return query.OrderBy(s => s.Subject.Name);

            return sorting.Criterion switch
            {
                GradeSortingCriteria.Subject => sorting.Order == SortingOrder.Ascending
                    ? query.OrderBy(s => s.Subject.Name)
                    : query.OrderByDescending(s => s.Subject.Name),

                GradeSortingCriteria.Score => sorting.Order == SortingOrder.Ascending
                    ? query.OrderBy(s => s.Score)
                    : query.OrderByDescending(s => s.Score),

                _ => query.OrderBy(s => s.Subject.Name)
            };
        }
    }
}
