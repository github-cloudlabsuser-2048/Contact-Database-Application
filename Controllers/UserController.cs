using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
// things added
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            return View(userlist);
        }
 
      // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return HttpNotFound();
            }
        }
 
      // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }
 
      // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userlist.Add(user);
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }
 
      // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return HttpNotFound();
            }
        }
 
      // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                // Update the user's information
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                //existingUser.Age = user.Age;

                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
 
      // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return HttpNotFound();
            }
        }
 
      // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                userlist.Remove(user);
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // ========================added from here=========================
        private List<Contact> contacts = new List<Contact>();
        // Adds a new contact
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            Console.WriteLine("Contact added successfully.");
        }

        // Edits an existing contact
        public void EditContact(int id, Contact updatedContact)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                contact.Name = updatedContact.Name;
                contact.Email = updatedContact.Email;
                contact.PhoneNumber = updatedContact.PhoneNumber;
                Console.WriteLine("Contact updated successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        // Deletes a contact
        public void DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                contacts.Remove(contact);
                Console.WriteLine("Contact deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        // Lists all contacts
        public void ListContacts()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"ID: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, Phone: {contact.PhoneNumber}");
            }
        }

        // Searches contacts by name or email
        public void SearchContacts(string searchTerm)
        {
            var filteredContacts = contacts.Where(c => c.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0
                                                    || c.Email.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (filteredContacts.Any())
            {
                foreach (var contact in filteredContacts)
                {
                    Console.WriteLine($"ID: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, Phone: {contact.PhoneNumber}");
                }
            }
            else
            {
                Console.WriteLine("No contacts found matching the search criteria.");
            }
        }
    }

    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

}
