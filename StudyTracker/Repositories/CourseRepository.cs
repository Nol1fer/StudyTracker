using StudyTracker.Models;

namespace StudyTracker.Repositories
{
    public class CourseRepository
    {
        private List<Course> _courses = new List<Course>();
        public CourseRepository()
        {
            if (_courses?.Count == 0)
            {
                SetDefaultCourses();
            }
        }

        public void SetDefaultCourses()
        {
            var course1 = new Course(id: 1, "Math", "some description", "Ivanov");
            var course2 = new Course(id: 2, "History", "world history", "Petrov");
            var course3 = new Course(id: 3, "Computer Science", description: null, "Sidorov");
            var course4 = new Course(id: 4, "Biology", description: "Baza biologii", "Sinicina");

            _courses = [course1, course2, course3, course4];
        }
        public List<Course> GetCourses()
        {
            return _courses;
        }

        public void AddCourse(Course course)
        {
            _courses.Add(course);
        }

        public void RemoveCourse(int id)
        {
            var course = _courses.Single(c => c.Id == id);
            _courses.Remove(course);
        }

    }
}
