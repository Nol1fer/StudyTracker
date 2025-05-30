using Microsoft.AspNetCore.Mvc;
using StudyTracker.Models;
using StudyTracker.Services;

namespace StudyTracker.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: Task/Index/5 (courseId)
        public IActionResult Index(int courseId)
        {
            var tasks = _taskService.GetTasksByCourseId(courseId);
            ViewBag.CourseId = courseId;
            return View(tasks);
        }

        // GET: Task/Create/5 (courseId)
        public IActionResult Create(int courseId)
        {
            ViewBag.CourseId = courseId;
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public IActionResult Create(Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _taskService.AddTask(task);
                return RedirectToAction("Index", new { courseId = task.CourseId });
            }
            ViewBag.CourseId = task.CourseId;
            return View(task);
        }

        // GET: Task/Edit/5 (id)
        public IActionResult Edit(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                ViewBag.Error = "Курс не найден";
                return View("Error");
            }
            return View(task);
        }

        // POST: Task/Edit/5
        [HttpPost]
        public IActionResult Edit(Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _taskService.UpdateTask(task);
                return RedirectToAction("Index", new { courseId = task.CourseId });
            }
            return View(task);
        }

        // GET: Task/Delete/5 (id)
        public IActionResult Delete(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                ViewBag.Error = "Курс не найден";
                return View("Error");
            }
            return View(task);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task != null)
            {
                _taskService.DeleteTask(id);
                return RedirectToAction("Index", new { courseId = task.CourseId });
            }
            return NotFound();
        }
    }
}