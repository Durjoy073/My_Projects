using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class StudentContext
    {

        private readonly IConfiguration _config;
        private readonly string _connectionString;
        public StudentContext(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("DefaultConnection");
        }

        public IDbConnection Connection => new SqlConnection(_connectionString);
        public void AddStudent(Student student)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO Students (Name, Age, Department) VALUES (@Name, @Age, @Department)";
                dbConnection.Open();
                dbConnection.Execute(query, student);
            }
        }

        public void UpdateStudent(Student student)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "UPDATE Students SET Name = @Name, Age = @Age, Department = @Department WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(query, student);
            }
        }

        public void DeleteStudent(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "DELETE FROM Students WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(query, new { Id = id });
            }
        }

        internal string? GetStudentById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
