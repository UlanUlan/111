using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;
using WebApplication1.Hubs;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        TasksContext db = new TasksContext();

        //public ActionResult Index()
        //{
        //    var tests = db.Tests.Include(o => o.Subject);
        //    return View(tests.ToList());
        //}

        public ActionResult Index(string status)
        {
            IQueryable<Test> tests = db.Tests.Include(o => o.Subject);

            if (status=="Выполненные")
            {
                tests = tests.Where(o => o.Status == true);
            }
            else if (status=="Невыполненные")
            {
                tests = tests.Where(o => o.Status == false);
            }

            TestsListViewModel tlvw = new TestsListViewModel
            {
                Tests = tests.ToList(),
                Statuses = new SelectList(new List<string>()
                {
                    "Все","Выполненные", "Невыполненные"
                })
            };
            return View(tlvw);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList subjects = new SelectList(db.Subjects, "Id", "Name");
            ViewBag.Subjects = subjects;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Test test)
        {
            if (test.Name != null && test.Name != "")
            {
                db.Tests.Add(test);
                db.SaveChanges();
                SendMessage("Задание успешно добавлено!");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Test test = db.Tests.Find(id);
            if (test != null)
            {
                SelectList subjects = new SelectList(db.Subjects, "Id", "Name", test.SubjectId);
                ViewBag.Subjects = subjects;
                return View(test);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Test test)
        {
            db.Entry(test).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Test test = db.Tests.Find(id);
            if (test != null)
            {
                db.Tests.Remove(test);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private void SendMessage(string message)
        {
            // Получаем контекст хаба
            var context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            // отправляем сообщение
            context.Clients.All.displayMessage(message);
        }
    }
}