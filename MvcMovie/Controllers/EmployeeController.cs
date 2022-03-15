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
    public class EmployeeController : Controller
    {
        private readonly MvcMovieContext _context;
        AutoGenerateKey Aukey = new AutoGenerateKey();
        XuLyChuoi Xulychuoi = new XuLyChuoi();
        public EmployeeController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index(string EmployeeAdress, string SearchString)
        {
            IQueryable<string> genreQuery = from m in _context.Employee
                                                orderby m.Address
                                                select m.Address;

           var Nhanvienview = from m in _context.Employee
                 select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Nhanvienview = Nhanvienview.Where(s => s.EmployeeName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(EmployeeAdress))
            {
                Nhanvienview = Nhanvienview.Where(x => x.Address == EmployeeAdress);
            }

            var EmployeeAddressVM = new EmployeeAddressViewModel
            {
                Adress = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Employees = await Nhanvienview.ToListAsync()
            };

            return View(EmployeeAddressVM);

            //return View(await _context.Employee.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            string NewID = "";
            var emp = _context.Employee.ToList().OrderByDescending(c => c.EmployeeID); // lay danh sach person theo ID lon nhat
            var countEmployee = _context.Employee.Count(); 

            if (countEmployee == 0)
            {
                NewID = "NV001";
            }
            else
            {
                NewID = Aukey.GenerateKey(emp.FirstOrDefault().EmployeeID);
            }
            ViewBag.newID = NewID;
            return View();  
            
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,EmployeeName,Address")] Employee employee)
        {
            employee.EmployeeName = Xulychuoi.Xuly(employee.EmployeeName);
            employee.Address = Xulychuoi.Xuly(employee.Address);
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeID,EmployeeName,Address")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }
            employee.EmployeeName = Xulychuoi.Xuly(employee.EmployeeName);
            employee.Address = Xulychuoi.Xuly(employee.Address);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
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
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employee.Any(e => e.EmployeeID == id);
        }
    }
}
