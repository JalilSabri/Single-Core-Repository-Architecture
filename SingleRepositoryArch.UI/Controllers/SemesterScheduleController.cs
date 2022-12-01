using Microsoft.AspNetCore.Mvc;
using SingleRepositoryArch.Core.ApplicationServices.Management;
using SingleRepositoryArch.Core.Interfaces.Management;
using SingleRepositoryArch.Data.Models.Management;

namespace SingleRepositoryArch.UI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class SemesterScheduleController : Controller
    {
        ISemesterScheduleService semesterScheduleService;

        public SemesterScheduleController(ISemesterScheduleService _semesterScheduleService)
        {
            semesterScheduleService = _semesterScheduleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(semesterScheduleService.GetAll().ToList());
        }

        [HttpPost]
        public IActionResult Add([FromBody] SemesterSchedule semesterSchedule)
        {
            semesterScheduleService.Add(semesterSchedule);
            return Ok(semesterSchedule.Id);
        }

        [HttpPut]
        public IActionResult Edit(SemesterSchedule semesterSchedule)
        {
            SemesterSchedule objSemesterSchedule = semesterScheduleService.GetWithExpressions(q => q.Id == semesterSchedule.Id).FirstOrDefault();
            objSemesterSchedule.Id = semesterSchedule.Id;
            objSemesterSchedule.StartTime = semesterSchedule.StartTime;
            objSemesterSchedule.FinishTime = semesterSchedule.FinishTime;
            objSemesterSchedule.SemesterId = semesterSchedule.SemesterId;
            objSemesterSchedule.TeacherId = semesterSchedule.TeacherId;
            semesterScheduleService.Update(objSemesterSchedule);
            return Ok(semesterSchedule.Id + " is updated.");
        }

        [HttpDelete("{semesterScheduleId}")]
        public IActionResult Delete(string semesterScheduleId)
        {
            SemesterSchedule semesterSchedule = semesterScheduleService.GetWithExpressions(q => q.Id == semesterScheduleId).FirstOrDefault();
            semesterScheduleService.Delete(semesterSchedule);
            return Ok(semesterScheduleId + " is deleted.");
        }
    }
}
