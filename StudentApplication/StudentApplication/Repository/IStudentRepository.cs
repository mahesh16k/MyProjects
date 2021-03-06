using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplication.Repository
{
    public interface IStudentRepository
    {
        bool CreateStudent(StudentDto student);
        bool UpdateStudent(StudentDto student);
        StudentDto GetStudentById(int id);
        bool DeleteStudent(int id);
        List<StudentDto> GetStudents();
    }
}
