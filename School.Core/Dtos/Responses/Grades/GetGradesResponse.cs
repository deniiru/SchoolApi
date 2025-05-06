using School.Core.Dtos.Common.Grades;

namespace School.Core.Dtos.Responses.Grades
{
    public class GetGradesResponse
    {
        public List<GradeDto> Grades { get; set; } = new List<GradeDto>();
    }
}
