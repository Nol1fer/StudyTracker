using StudyTracker.Models;
using StudyTracker.ViewModels;

namespace StudyTracker.ViewModelBuilders
{
    public class CoursesVmBuilder
    {
        public CoursesVmBuilder() { }

        public CoursesVm GetCoursesVm()
        {
            var course1 = new Course(id: 1, "Math", "some description", "Ivanov");
            var course2 = new Course(id: 2, "History", "world history", "Petrov");
            var course3 = new Course(id: 3, "Computer Science", description: null, "Sidorov");

            var courses = new List<Course>() { course1, course2, course3 };

            return new CoursesVm(courses);
        }
    }
}
