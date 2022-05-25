using DatabaseFirst_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DatabaseFirst_EF.Controllers
{
    [Route("api/[[Teacher]]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly SAMPLEDBContext dbContext;

        public TeacherController(SAMPLEDBContext context)
        {
            dbContext = context;
        }
        [HttpPost("Add_Teacher")]
        public async Task<IActionResult> AddTeacher(Teacher model)
        {
            var data = new Teacher
            {
                TeacherName = model.TeacherName,
                Parentage = model.Parentage,
                Qualification = model.Qualification,
                TeacherAddress = model.TeacherAddress
            };
            await dbContext.AddAsync(data);
            bool result = await dbContext.SaveChangesAsync() > 0;

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            List<Teacher> data = await dbContext.Teachers.Select(a => new Teacher
            {
                TeacherId = a.TeacherId,
                TeacherName = a.TeacherName,
                Parentage = a.Parentage,
                Qualification = a.Qualification,
                TeacherAddress = a.TeacherAddress

            }).OrderBy(a => a.TeacherName).ToListAsync();

            return Ok(data);
        }

        [HttpGet("GetSingleTeachor")]
        public async Task<IActionResult> GetTeacher(int TeachorID)
        {
            var Teacher = dbContext.Teachers.FirstOrDefault(a => a.TeacherId == TeachorID);

            Teacher std = new Teacher
            {
                TeacherId = Teacher.TeacherId,
                Qualification = Teacher.Qualification,
                Parentage = Teacher.Parentage,
                TeacherAddress = Teacher.TeacherAddress,
                TeacherName = Teacher.TeacherName
            };
            return Ok(std);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacher(Teacher model)
        {
            var Teacher = dbContext.Teachers.FirstOrDefault(a => a.TeacherId == model.TeacherId);

            if (Teacher != null)
            {
                Teacher.TeacherAddress = model.TeacherAddress;
                Teacher.TeacherName = model.TeacherName;
                Teacher.Parentage = model.Parentage;
                Teacher.Qualification = model.Qualification;
            }

            bool result = await dbContext.SaveChangesAsync() > 0;

            return Ok(result);
        }
        [HttpDelete]
      public async Task<IActionResult> DeleteTeacher(int TeacherID)
        {
            var data = dbContext.Teachers.FirstOrDefault(a => a.TeacherId == TeacherID);
            if (data != null)
            {
                dbContext.Remove(data);
            }
            bool result = await dbContext.SaveChangesAsync() > 0;

            return Ok(result);

        }

    }
}