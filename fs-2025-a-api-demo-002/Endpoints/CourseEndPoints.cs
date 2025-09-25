using fs_2025_a_api_demo_002.Data;

namespace fs_2025_a_api_demo_002.Endpoints
{
    public static class CourseEndPoints
    {
        public static void AddCourseEndPoints(this WebApplication app)
        {
            app.MapGet("/courses", (CourseData courseData) =>
            {
                return Results.Ok(courseData.Courses);
            });

            app.MapGet("/courses/{id:int}", (int id, CourseData courseData) =>
            {
                var course = courseData.Courses.FirstOrDefault(c => c.id == id);
                return course is not null ? Results.Ok(course) : Results.NotFound();
            });
        }
    }
}
