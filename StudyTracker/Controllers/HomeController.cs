using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudyTracker.Models;
using StudyTracker.ViewModels;
using StudyTracker.ViewModelBuilders;


namespace StudyTracker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //private readonly CoursesVmBuilder _coursesVmBuilder;

    public HomeController(ILogger<HomeController> logger, CoursesVmBuilder coursesVmBuilder)
    {
        _logger = logger;
        //_coursesVmBuilder = coursesVmBuilder;
    }

    public IActionResult Index()
    {
        //var coursesVm = _coursesVmBuilder.GetCoursesVm();
        //return View(coursesVm);
        return RedirectToAction(nameof(CourseController.Index), "Course");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
