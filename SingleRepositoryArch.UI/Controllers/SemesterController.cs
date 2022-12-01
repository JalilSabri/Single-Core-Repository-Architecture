using Microsoft.AspNetCore.Mvc;
using SingleRepositoryArch.Core.Interfaces.Management;
using SingleRepositoryArch.Data.Models.Management;

[Route("[controller]")]
[ApiController]
public class SemesterController : Controller
{
    ISemesterService semesterService;

    public SemesterController(ISemesterService _semesterService)
    {
        semesterService = _semesterService;

    }
    public IActionResult Get()
    {
        return Ok(semesterService.GetAll().ToList());
    }

    [HttpPost]
    public IActionResult Add(Semester semester)
    {
        semesterService.Add(semester);
        return Ok(semester.Id);
    }

    [HttpPut]
    public IActionResult Edit(Semester semester)
    {
        Semester objSemster = semesterService.GetWithExpressions(q => q.Id == semester.Id).FirstOrDefault();
        objSemster.Id = semester.Id;
        objSemster.StartDate= semester.StartDate;
        objSemster.FinishDate = semester.FinishDate;
        objSemster.Capacity = semester.Capacity;
        semesterService.Update(objSemster);
        return Ok(semester.Id + " is updated.");
    }

    [HttpDelete("{semesterId}")]
    public IActionResult Delete(string semesterId)
    {
        Semester semster = semesterService.GetWithExpressions(q => q.Id == semesterId).FirstOrDefault();
        semesterService.Delete(semster);
        return Ok(semesterId + " is deleted.");
    }

}