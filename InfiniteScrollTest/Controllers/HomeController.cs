using InfiniteScrollTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml.XPath;

namespace InfiniteScrollTest.Controllers
{
    public class HomeController : Controller
    {
        private List<TestModel> testModels;
        public HomeController()
        {
            testModels = new List<TestModel>();
            for (int i = 0; i < 100; i++)
            {
                testModels.Add(new TestModel { 
                    MyProperty1 = $"a{i}", 
                    MyProperty2 = $"b{i}",
                    MyProperty3 = $"c{i}",
                    MyProperty4 = $"d{i}",
                    MyProperty5 = $"d{i}"
                });
            }
            
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var result = GetPagedResult();
            //var paging = new PagingModel<TestModel> { List = result, pageIndex = 1, pageSize = 20, total = result.Count() };
            var types = Type.GetType("InfiniteScrollTest.Models.TestModel").GetProperties();
            TempData["types"] = types.Select(x => x.Name).ToList();
            return View(result);
        }

        public IEnumerable<TestModel> GetPagedResult(int pageIndex = 1)
        {
           return testModels.Skip((pageIndex - 1) * 20).Take(20);
        }
        [System.Web.Mvc.HttpPost]
        public JsonResult GetPagedJson([FromBody]int pageIndex = 1)
        {
            return Json(testModels.Skip((pageIndex - 1) * 20).Take(20));
        }
    }
}
