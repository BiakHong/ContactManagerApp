using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private ContactList context { get; set; }

        public HomeController(ContactList ctx)
        {
            context = ctx;
        }

        /*public IActionResult Index()
        {
            var contacts = context.Contacts
                .OrderBy(contact => contact.First)
                .ToList();
            return View(contacts);
        }*/
        public IActionResult Index()
        {
            var contacts = context.Contacts.Include(m => m.Category)
                .OrderBy(m => m.ContactId).ToList();
            return View(contacts);
        }
    }
}