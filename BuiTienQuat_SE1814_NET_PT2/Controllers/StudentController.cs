using BuiTienQuat_SE1814_NET_PT2.Hubs;
using BuiTienQuat_SE1814_NET_PT2.Models;
using BuiTienQuat_SE1814_NET_PT2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace BuiTienQuat_SE1814_NET_PT2.Controllers
{

    public class StudentController : Controller
    {
        //private readonly Pt2prn222Context _context;
        private readonly IStudentRepository _studentRepository;
        private readonly IHubContext<SignalRServer> _hubContext;

        public StudentController(IStudentRepository studentRepository, IHubContext<SignalRServer> hubContext)
        {
            _studentRepository = studentRepository;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            var listStudent = _studentRepository.GetAll();
            return View(listStudent);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            if (student.Dob > DateTime.Today)
            {
                ModelState.AddModelError("Dob", "Date of Birth cannot be in the future.");
                return View(student);
            }

            if (!student.Dob.HasValue || (DateTime.Today.AddYears(-18) < student.Dob.Value))
            {
                ModelState.AddModelError("Dob", "Student must be at least 18 years old.");
                return View(student);
            }



            try
            {
                _studentRepository.Add(student);
                await _studentRepository.SaveChangesAsync();
                await _hubContext.Clients.All.SendAsync("RefreshStudentList");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while saving. Please try again.");
                return View(student);
            }
        }
        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var studentEdit = _studentRepository.GetById(id);
            if (studentEdit == null)
            {
                return NotFound();
            }
            return View(studentEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            if (student.Dob > DateTime.Today)
            {
                ModelState.AddModelError("Dob", "Date of Birth cannot be in the future.");
                return View(student);
            }
            try
            {
                // Lấy dữ liệu từ database
                Student oldStudent = _studentRepository.GetById(id);
                if (oldStudent == null)
                {
                    //return NotFound();
                    ModelState.AddModelError("", "Student ID does not exist.");
                    return View(student);
                }

                // Cập nhật các thuộc tính
                oldStudent.Name = student.Name;
                oldStudent.Dob = student.Dob;
                oldStudent.Major = student.Major;

                // Lưu thay đổi
                await _studentRepository.SaveChangesAsync();

                // Gửi thông báo cập nhật cho client
                await _hubContext.Clients.All.SendAsync("RefreshStudentList");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while updating. Please try again.");
                return View(student);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {


            _studentRepository.Delete(id);
            await _studentRepository.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("RefreshStudentList");

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Search(string keyword)
        {
            var students = _studentRepository.Search(keyword);
            return PartialView("_StudentTablePartial", students);
        }

        // GET: Student/Detail/5
        public ActionResult Detail(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDetail = _studentRepository.GetById(id);
            if (studentDetail == null)
            {
                return NotFound();
            }

            return View(studentDetail);
        }

    }
}
