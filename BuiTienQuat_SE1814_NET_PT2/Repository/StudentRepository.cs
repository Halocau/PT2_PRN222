using BuiTienQuat_SE1814_NET_PT2.Models;

namespace BuiTienQuat_SE1814_NET_PT2.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Pt2prn222Context _context;

        public StudentRepository(Pt2prn222Context context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id.Equals(id));
            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(string id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public List<Student> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            keyword = keyword.ToLower();
            return _context.Students
                .Where(s => s.Name.ToLower().Contains(keyword) ||
                            s.Major.ToLower().Contains(keyword))
                .ToList();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
        }
    }
}
