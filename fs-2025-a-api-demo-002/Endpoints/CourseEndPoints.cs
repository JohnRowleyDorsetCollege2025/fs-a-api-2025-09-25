using fs_2025_a_api_demo_002.Data;

namespace fs_2025_a_api_demo_002.Endpoints
{
    public static class CourseEndPoints
    {
        public static void AddCourseEndPoints(this WebApplication app)
        {
            app.MapGet("/courses", LoadAllCoursesAsync);

            app.MapGet("/courses/{id:int}",LoadCourseById);

         


        }

     

        private static async Task<IResult> LoadCourseById(CourseData courseData, int id)
        {
            var output = courseData.Courses.FirstOrDefault(c => c.id == id);
            if (output is null)
            {
                return Results.NotFound();
            }   
            return Results.Ok(output);

        }

        private static async Task<IResult> LoadAllCoursesAsync(
            CourseData courseData, 
            string? courseType,
            string? search
            )
        {
            var output = courseData.Courses;

            if (!string.IsNullOrWhiteSpace(courseType))
            {
                output = output.Where(c => c.courseType.Equals(courseType, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if(!string.IsNullOrWhiteSpace(search))
            {
                output = output.Where(c => c.courseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                           c.shortDescription.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return Results.Ok(output);
        }
    }
}
