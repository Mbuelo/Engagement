using AgapeChurchMemberApplication.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading;

namespace AgapeChurchMemberApplication.Controllers
{
    public class SMSsController : Controller
    {
        private AgapeDBContext db = new AgapeDBContext();
        SerialPort sp = new SerialPort();
        
        

        // GET: SMS
        public ActionResult Index()
        {
            
            ViewBag.Individuals = db.Individual;
           
            return View();
        }
        //public ActionResult Index(string searchBy, string search)
        //{
        //    switch (searchBy)
        //    {
        //        case "Name":
        //            return View(db.Individual.Where(x => x.IndividualName == search || search == null).ToList());
        //        case "Surname":
        //            return View(db.Individual.Where(x => x.IndividualLastName == search || search == null).ToList());
        //        //todo: .include to include group
        //        default:
        //            return View(db.Individual.ToList());

        //    }

        //}


        public ActionResult SendSMS()
        {
            ViewBag.Individuals = db.Individual;
            return View();
        }

        [HttpPost]
        public ActionResult SendSMS(string message, int[] IndividualIds)
        {
            foreach (int indID in IndividualIds)
            {
                string newLine = Environment.NewLine;
                Individual individual = db.Individual.Find(indID);
                string greeting = $"Greetings {individual.IndividualTitle} {individual.IndividualLastName}"+newLine;
                string num = individual.IndividualNumber;
                string sentmessage = greeting + message;
                try
                {
                    sendSMS(num, sentmessage);
                    sentmessage = null;
                    System.Threading.Thread.Sleep(3000);

                    //sendSMS(model.TelNo, model.Message);

                    
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return RedirectToAction("Index");

        }

        //SEND SMS CODE REMOVED. INTELLECTUAL PROPERTY
        //MBUELO RAMAFAMBA
    }
}

    