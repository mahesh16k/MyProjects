using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentApplication.Models;
using StudentApplication.Repository;
using System;

namespace StudentApplication.Controllers
{
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger _logger;
        public StudentController(IStudentRepository studentRepository,ILogger<StudentController> logger)
        {
            this._studentRepository = studentRepository;
            this._logger = logger;
        }

        /// <summary>
        /// Method to create Student
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent([FormBody] StudentDto studentDto)
        {
            _logger.LogDebug("API Started : CreateStudent");
            try
            {
                var result = _studentRepository.CreateStudent(studentDto);
                _logger.LogDebug("API Response : True");
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError("Log Error Message for Create Student" + ex.Message);
                return StatusCode(400,ex);
            }
        }


        /// <summary>
        /// UpdateStudent Method
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns>true</returns>
        [HttpPost("UpdateStudent")]
        public IActionResult UpdateStudent(StudentDto studentDto)
        {
            _logger.LogDebug("API Started : UpdateStudent");
            try
            {
                var result = _studentRepository.CreateStudent(studentDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Log Error Message for Update Student" + ex.Message);
                _logger.LogError(ex.Message);
                return StatusCode(400, ex);
            }
        }

        /// <summary>
        /// Get Student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetStudent/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var data = _studentRepository.GetStudentById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Log Error Message for Get Student By Id" + ex.Message);
                _logger.LogError(ex.Message);
                return StatusCode(400, ex);
            }
        }

        /// <summary>
        /// Delete Student By id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var data = _studentRepository.DeleteStudent(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError("Log Error Message for Delete Student" + ex.Message);
                return StatusCode(400, ex);
            }
        }

        /// <summary>
        /// Get the List of Students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStudents")]
        public IActionResult GetStudents()
        {
            try
            {
                var result = _studentRepository.GetStudents();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError("Log Error Message for Get All Student" + ex.Message);
                return StatusCode(400, ex);
            }
        }
    }
}

