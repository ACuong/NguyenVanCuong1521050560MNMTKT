using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MvcMovieContext _context;
        AutoGenerateKey Aukey = new AutoGenerateKey();

        XuLyChuoi XuLyChuoi = new XuLyChuoi();

        public CustomerController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            string NewID = "";
            var emp = _context.Person.ToList().OrderByDescending(c => c.PersonID); // lay danh sach person theo ID lon nhat
            var countEmployee = _context.Person.Count(); 

            if (countEmployee == 0)
            {
                NewID = "CS001";
            }
            else
            {
                NewID = Aukey.GenerateKey(emp.FirstOrDefault().PersonID);
            }
            ViewBag.newPerID = NewID;
            return View();     
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Gender,Birthday,PersonID,PersonName,Address")] Customer customer)
        {
            customer.Address = XuLyChuoi.Xuly(customer.Address);
            customer.Email = XuLyChuoi.Xuly(customer.Email);
            customer.Birthday = XuLyChuoi.Xuly(customer.Birthday);
            customer.PersonName = XuLyChuoi.Xuly(customer.PersonName);
            customer.Address = XuLyChuoi.Xuly(customer.Address);
            if (ModelState.IsValid)
            {
                
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Gender,Birthday,PersonID,PersonName,Address")] Customer customer)
        {
            customer.Address = XuLyChuoi.Xuly(customer.Address);
            customer.Email = XuLyChuoi.Xuly(customer.Email);
            customer.Birthday = XuLyChuoi.Xuly(customer.Birthday);
            customer.PersonName = XuLyChuoi.Xuly(customer.PersonName);
            customer.Address = XuLyChuoi.Xuly(customer.Address);
            if (id != customer.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(string id)
        {
            return _context.Customer.Any(e => e.PersonID == id);
        }
    }
}
