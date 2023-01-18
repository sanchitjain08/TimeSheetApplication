using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TimeSheetApplication.Models;


namespace TimeSheetApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {

            if (HttpContext.Session.GetString("EmployeeEmail") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public const string SessionKeyName = "_Name";
        public const string SessionKeyId = "_Id";
        
        //Post Action
        [HttpPost]
        public ActionResult Login(Employee u)
        {
            if (HttpContext.Session.GetString("EmployeeEmail") == null)
            {
                    using (TimeSheetApplicationContext db = new TimeSheetApplicationContext())
                    {
                        var obj = db.Employees.Where(a => a.EmployeeEmail.Equals(u.EmployeeEmail) && a.EmployeePassword.Equals(u.EmployeePassword)).FirstOrDefault();
                        if (obj != null)
                        {
                            HttpContext.Session.SetString(SessionKeyName, obj.EmployeeEmail.ToString());
                            HttpContext.Session.SetInt32(SessionKeyId, obj.EmployeeId); 
                            return RedirectToAction("Index");
                        }

                    }
                
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Logout()
        {

            HttpContext.Session.Clear();
            HttpContext.Session.Remove("EmployeeEmail");

            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
           
            return View();
        }
        
        public IActionResult MyProfile()
        {
           
            using (TimeSheetApplicationContext db = new TimeSheetApplicationContext())
            {
                var SessionEmail = HttpContext.Session.GetString(SessionKeyName);
                var obj = db.Employees.Where(a => a.EmployeeEmail.Equals(SessionEmail)).FirstOrDefault();
                Employee Emp_Details = new Employee
                {
                    EmployeeEmail = obj.EmployeeEmail,
                    EmployeeFirstName = obj.EmployeeFirstName,
                    EmployeeLastName = obj.EmployeeLastName,
                    EmployeeDesignation = obj.EmployeeDesignation,
                    EmployeeId = obj.EmployeeId,
                    EmployeeJoiningDate = obj.EmployeeJoiningDate,
                    EmployeeLeavingDate = obj.EmployeeLeavingDate
                };
                ViewBag.Message = Emp_Details;
                return View();
            }
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
}