// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyTracker.Models;
using StudyTracker.Services;
using StudyTracker.ViewModelBuilders;

namespace StudyTracker.Controllers
{
    public class CourseController : Controller
    {
        private readonly CoursesVmBuilder _coursesVmBuilder;
        private readonly CourseService _courseService;
        public CourseController(CourseService courseService, CoursesVmBuilder coursesVmBuilder)
        {
            _coursesVmBuilder = coursesVmBuilder;
            _courseService = courseService;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            var coursesVm = _coursesVmBuilder.GetCoursesVm();
            return View(coursesVm);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)  // Измените параметр!
        {
            try
            {
                if (ModelState.IsValid)  // Проверка валидации
                {
                    // Генерируем новый Id (временное решение до подключения БД)
                    course.Id = _courseService.GetCourses().Max(c => c.Id) + 1;
                    _courseService.AddCourse(course);
                    return RedirectToAction(nameof(Index));
                }
                return View(course);  // Если есть ошибки валидации
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ошибка: " + ex.Message;
                return View("Error");
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var course = _courseService.GetCourses().FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                ViewBag.Error = "Курс не найден";
                return View("Error");
            }
            return View(course);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course updatedCourse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingCourse = _courseService.GetCourses().FirstOrDefault(c => c.Id == id);
                    if (existingCourse == null)
                    {
                        ViewBag.Error = "Курс не найден";
                        return View("Error");
                    }

                    // Обновляем данные
                    existingCourse.Name = updatedCourse.Name;
                    existingCourse.Description = updatedCourse.Description;
                    existingCourse.ProfessorName = updatedCourse.ProfessorName;

                    return RedirectToAction(nameof(Index));
                }
                return View(updatedCourse); // Если есть ошибки валидации
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Ошибка при редактировании: {ex.Message}";
                return View("Error");
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            var course = _courseService.GetCourses().FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                ViewBag.Error = "Курс не найден";
                return View("Error");
            }
            return View(course); // Подтверждение удаления
        }

        // POST: CourseController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _courseService.RemoveCourse(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Ошибка при удалении: {ex.Message}";
                return View("Error");
            }
        }
    }
}
