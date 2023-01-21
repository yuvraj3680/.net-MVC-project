using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;

 using BOL;
 using DAL;
 using BLL;

namespace App.Controllers;

public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {        

        List<Employee> list=EmployeeManager.GetAllEmployeeFromDAL();
        this.ViewData["Employee"]=list;
        return View();
    }
    [HttpGet]
    public IActionResult Insert()
    {
        Employee dobj=new Employee();
        return View(dobj);
    }
    [HttpPost]
    public IActionResult Insert(int eid,string ename,string city,string sallary)
    {
        // if(!ModelState.IsValid)
        // {
        //     return View();
        // }
        EmployeeManager hobj=new EmployeeManager();
        
        if(hobj.insert(eid,ename,city,sallary)){
        return RedirectToAction("Index");
        }
        return View();
    
    }
     public IActionResult Employee()
    {
       
        return View();
    }


   
}
