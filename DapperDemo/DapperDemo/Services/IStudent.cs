using DapperDemo.Models;

namespace DapperDemo.Services
{
    public interface IStudent
    {

        public List<Student> GetStudentsList();
        public string InsertStudent(Student student);
        public string UpdateStudent(Student student);
        public string DeleteStudent(int Id);
         


    }
}
