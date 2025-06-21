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
    public static  class StudentsQueryExtensions
    {
        public static IQueryable<Grade> FilterByGradeRange(this IQueryable<Grade> query, DateRangeDto range)
        {
            if (range == null)
                return query;

            if (range.LowerGrade.HasValue)
                query = query.Where(g => g.Score >= range.LowerGrade.Value);

            if (range.UpperGrade.HasValue)
                query = query.Where(g => g.Score <= range.UpperGrade.Value);

            return query;
        }

        public static IQueryable<Student> SearchBy(this IQueryable<Student> query, string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
                return query;

            searchValue = searchValue.ToLower();

            return query.Where(s =>
                s.FirstName.ToLower().Contains(searchValue) ||
                s.LastName.ToLower().Contains(searchValue));
        }

        public static IQueryable<Student> SortBy(this IQueryable<Student> query, StudentsSortingDto sorting)
        {
            if (sorting == null)
                return query.OrderBy(s => s.LastName);

            return sorting.Criterion switch
            {
                StudentsSortingCriteria.FirstName => sorting.Order == SortingOrder.Ascending
                    ? query.OrderBy(s => s.FirstName)
                    : query.OrderByDescending(s => s.FirstName),

                StudentsSortingCriteria.LastName => sorting.Order == SortingOrder.Ascending
                    ? query.OrderBy(s => s.LastName)
                    : query.OrderByDescending(s => s.LastName),

                _ => query.OrderBy(s => s.LastName)
            };
        }
    }
}
