using Dapper;
using DapperDemo.Models;
using Microsoft.Data.SqlClient;
using System.Data;


namespace DapperDemo.Services
{
    public class StudentService : IStudent
    {

        private readonly IConfiguration _configuration;
        public string ConnectionString { get; set; }
        public string Provider { get; set; }
        public StudentService(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            Provider = "Microsoft.Data.SqlClient";
        }

        public IDbConnection Connection { get { return new SqlConnection(ConnectionString); } }

        public string DeleteStudent(int Id)
        {
            {
                try
                {
                    using (IDbConnection dbConnection = Connection)
                    {
                        dbConnection.Open();
                        var result = dbConnection.Execute("DELETE FROM Students WHERE Id = @Id", new { Id });
                        dbConnection.Close();
                        return result > 0 ? "Delete successful" : "Delete failed";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return "Error occurred while deleting the student";
                }
            }
        }

        public List<Student> GetStudentsList()
        {
            List<Student> students = new List<Student>();
            try
            {
              
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlQuery = "SELECT * FROM Students";
                    students = dbConnection.Query<Student>(sqlQuery).ToList();
                    dbConnection.Close();
                    return students;
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return students;
            }
        }

        public string InsertStudent(Student student)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Name", student.Name);
                    param.Add("@Age", student.Age);
                    param.Add("@Department", student.Department);

                    string sqlQuery = "INSERT INTO Students (Name, Age, Department) VALUES (@Name, @Age, @Department)";
                    var result = dbConnection.Execute(sqlQuery, param);
                    dbConnection.Close();
                    return result > 0 ? "Insert successful" : "Insert failed";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error occurred while inserting the student";
            }
        }

        public string UpdateStudent(Student student)
        {
             try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", student.Id);
                    param.Add("@Name", student.Name);
                    param.Add("@Age", student.Age);
                    param.Add("@Department", student.Department);

                    string sqlQuery = "UPDATE Students SET Name = @Name, Age = @Age, Department = @Department WHERE Id = @Id";
                    var result = dbConnection.Execute(sqlQuery, param);
                    dbConnection.Close();
                    return result > 0 ? "Update successful" : "Update failed";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error occurred while updating the student";
            }
        }
    }
}
