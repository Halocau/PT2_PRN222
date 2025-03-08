using BuiTienQuat_SE1814_NET_PT2.Models;

namespace BuiTienQuat_SE1814_NET_PT2.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetById(string id);
        void Add(Student student);
        void Update(Student student);
        void Delete(string id);
        List<Student> Search(string keyword);
        Task SaveChangesAsync();
    }
}
