using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;


namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {

        private ContactList context { get; set; }

        public ContactController(ContactList ctx)
        {
            context = ctx;
        }

        public IActionResult Details(int id)
        {
            var contact = context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }



        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(g => g.CategoryId).ToList();
            return View("AddEdit", new Contact());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
            return View("AddEdit", contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                context.Entry(contact).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
            return View("AddEdit", contact);
        }

        public IActionResult Delete(int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            context.Contacts.Remove(contact);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Save(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Contacts.Find(id);
            return View("AddEdit", product);
        }

        [HttpPost]
        public IActionResult Save(Contact product)
        {
            if (ModelState.IsValid)
            {
                if (product.ContactId == 0)
                    context.Contacts.Add(product);
                else
                    context.Contacts.Update(product);

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = (product.ContactId == 0) ? "Add" : "Edit";
                ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
                return View("AddEdit", product);
            }
        }

    }

}