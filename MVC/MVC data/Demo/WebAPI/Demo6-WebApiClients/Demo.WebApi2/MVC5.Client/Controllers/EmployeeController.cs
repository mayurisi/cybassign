using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Adding namespaces
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Demo.WebApi2.Models;

namespace MVC5.Client.Controllers
{
    public class EmployeeController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:54450/api/employee";
         
        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public EmployeeController()
        {
            client = new HttpClient();  
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Employees = JsonConvert.DeserializeObject<List<Employee>>(responseData);

                return View(Employees);
            }
            return View("Error");
        }

        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Employee = JsonConvert.DeserializeObject<Employee>(responseData);

                return View(Employee);
            }
            return View("Error");
        }

        public ActionResult Create()
        {
            return View(new Employee());
        }

        //This method is calling Web API Post method
        [HttpPost]
        public async Task<ActionResult> Create(Employee Emp)
        {

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, Emp);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Employee = JsonConvert.DeserializeObject<Employee>(responseData);

                return View(Employee);
            }
            return View("Error");
        }

        //This method is calling Web API PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Employee Emp)
        {

            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, Emp);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Employee = JsonConvert.DeserializeObject<Employee>(responseData);

                return View(Employee);
            }
            return View("Error");
        }

        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Employee Emp)
        {

            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
	}
}