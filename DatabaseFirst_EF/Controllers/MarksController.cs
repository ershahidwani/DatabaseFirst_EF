using DatabaseFirst_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly SAMPLEDBContext dbContext;

        public MarksController(SAMPLEDBContext context)
        {
            dbContext = context;
        }
        [HttpGet("Student_Marks")]
        public async Task<IActionResult> GetMarks()
        {
            List<Mark> data = await dbContext.Marks.Select(a => new Mark
            {
                Rollno = a.Rollno,
            RollnoNavigation = a.RollnoNavigation,
            Totalmarks=a.Totalmarks,
            }).OrderBy(a => a.Rollno).ToListAsync();

            return Ok(data);
        }
    }
}
