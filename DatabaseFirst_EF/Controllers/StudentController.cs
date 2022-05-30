using DatabaseFirst_EF.CustomModels;
using DatabaseFirst_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst_EF.Controllers
{
    [Route("api/[[Student]]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SAMPLEDBContext dbContext;

        public StudentController(SAMPLEDBContext context)
        {
            dbContext = context;
        }
        [HttpPost("Add_Student")]
        public async Task<IActionResult> AddStudent(Student model)
        {
            var data = new Student
            {
                Name = model.Name,
                FathersName = model.FathersName,
                Course = model.Course,
                Address = model.Address,
                RollNo = model.RollNo,
            };
            await dbContext.AddAsync(data);
            bool result = await dbContext.SaveChangesAsync() > 0;
             return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            List<Student> data = await dbContext.Students.Select(a => new Student
            {
                RollNo = a.RollNo,
                Name = a.Name,
                FathersName = a.FathersName,
                Address = a.Address,
                Course = a.Course

            }).OrderBy(a => a.Name).ToListAsync();

            return Ok(data);
        }
       
        [HttpGet("GetStudent")]
        public async Task<IActionResult> GetStudent(int RollNo)
        {
            //var Students = dbContext.Students.FirstOrDefault(a => a.RollNo == RollNo);
            Student student = await dbContext.Students.Where(a => a.RollNo == RollNo).Select(a => new Student
            {
                RollNo = a.RollNo,
                FathersName = a.FathersName,
                Address = a.Address,
                Course = a.Course,
                Name = a.Name
            }).FirstOrDefaultAsync();
                
            return Ok(student);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student model)
        {
            var student = dbContext.Students.FirstOrDefault(a => a.RollNo == model.RollNo);

            if (student != null)
            {
                student.Name = model.Name;
                student.Course = model.Course;
                student.Address = model.Address;
                student.FathersName = model.FathersName;
            }
            bool result = await dbContext.SaveChangesAsync() > 0;
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int RollNo)
        {
            var data = dbContext.Students.FirstOrDefault(a => a.RollNo == RollNo);
            if (data != null)
            {
                dbContext.Remove(data);
            }
            bool result = await dbContext.SaveChangesAsync() > 0;
            return Ok(result);

        }
    }
}
