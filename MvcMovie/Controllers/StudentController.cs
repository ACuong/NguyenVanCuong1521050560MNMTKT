using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie;
using MvcMovie.Models;
using MvcMovie.Models.Process;
namespace MvcMovie.Controllers
{
    public class StudentController : Controller
    {
        private readonly MvcMovieContext _context;
        XuLyChuoi Xulychuoi = new XuLyChuoi();
        AutoGenerateKey Aukey = new AutoGenerateKey();

        ExcelProcess ExcelProcess =  new ExcelProcess();

        // Private int WriteDatatableToDatabase(DataTable dt)
        //     {
        //     Try{
        //         Var con = Configuration.GetconnectionString(“MvcMovieContext”);
        //         //using bulkcopy to copy data from datatable to databse
        //         SqlBulkCopy builkcopy = new SqlBulkCopy(con);
        //         bulkcopy.DestinationTableName = "Movies";
        //         bulkcopy.ColumnMappings.Add(0,"MoviesID");
        //         bulkcopy.ColumnMappings.Add(1,"MoviesName");
        //         bulkcopy.ColumnMappings.Add(2,"Price");
        //         bulkcopy.ColumnMappings.Add(2,"Genre");
        //         bulkcopy.ColumnMappings.Add(2,"Price");
        //         bulkcopy.WriteToServer(dt);
        //         }
        //     Catch{
        //         Return 0; 
        //         }
        //     Return dt.Rows.Count;
        //     }


        public StudentController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index(string searchString)
        {

            var movies = from m in _context.Student select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.StudentName.Contains(searchString));
            }

            return View(await movies.ToListAsync());

            //return View(await _context.Student.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,StudentName, Address")] Student student, IFormFile file)
        {

            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
            
                else
                {
                    //rename file when upload to server
                    //tao duong dan /Uploads/Excels de luu file upload len server
                    var fileName = "DanhSach";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName + fileExtension);
                    var fileLocation = new FileInfo(filePath).ToString();

                    if (ModelState.IsValid)
                    {
                        //upload file to server
                        if (file.Length > 0)
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                //save file to server
                                await file.CopyToAsync(stream);
                                //read data from file and write to database
                                //_excelPro la doi tuong xu ly file excel ExcelProcess
                                var dt = ExcelProcess.ExcelToDataTable(fileLocation);
                                //ghi du lieu datatable vao database
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                   var st = new Student();
                                   st.StudentID = dt.Rows[i][0].ToString();
                                   st.StudentName = dt.Rows[i][1].ToString();
                                   st.Address = dt.Rows[i][2].ToString();
                                   _context.Student.Add(st);
                                }
                                _context.SaveChanges();

                                //WriteDatatableToDatabase(dt);
                                
                            }
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
            }
          


            student.StudentName = Xulychuoi.Xuly(student.StudentName);
            student.Address = Xulychuoi.Xuly(student.Address);
            if (ModelState.IsValid)
            {
                
                var emp = _context.Student.ToList().OrderByDescending(c => c.StudentID); // lay danh sach theo ID lon nhat
                var count = _context.Student.Count(); 

                if (count == 0)
                {
                    student.StudentID = "SV001";
                }
                else
                {
                    student.StudentID = Aukey.GenerateKey(emp.FirstOrDefault().StudentID);
                }

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentID,StudentName,Address")] Student student)
        {
            student.StudentName = Xulychuoi.Xuly(student.StudentName);
            student.Address = Xulychuoi.Xuly(student.Address);
            if (id != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentID))
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
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return _context.Student.Any(e => e.StudentID == id);
        }
    }
}
