using Microsoft.AspNetCore.Mvc;
using SingleRepositoryArch.Core.Interfaces.Management;
using SingleRepositoryArch.Core.ViewModels.Management;
using SingleRepositoryArch.Data.Models.Management;

[Route("[controller]")]
[ApiController]
public class TeacherController : Controller
{
    ITeacherService teacherService;
    ITeacherDetailsService teacherDetailsService;

    public TeacherController(ITeacherService _teacherService, ITeacherDetailsService _teacherDetailsService)
    {
        teacherService = _teacherService;
        teacherDetailsService = _teacherDetailsService;
    }

    public IActionResult Get()
    {
        return Ok(teacherService.GetAll().ToList());
    }

    [HttpPost]
    public IActionResult Add(TeacherViewModel teacherViewModel)
    {
        Teacher teacher = new Teacher()
        {
            FirstName = teacherViewModel.FirstName,
            LastName = teacherViewModel.LastName
        };

        if (teacherViewModel.Gender != null || teacherViewModel.Age > 0 || teacherViewModel.ChildernNumber > 0 || teacherViewModel.MaritalStatusSelected != MaritalStatusList.NoSelected)
        {
            TeacherDetails teacherDetails = new TeacherDetails()
            {
                Gender = teacherViewModel.Gender,
                MaritalStatus = (byte)teacherViewModel.MaritalStatusSelected == 0 ? false : true,
                ChildernNumber = teacherViewModel.ChildernNumber,
                Age = teacherViewModel.Age
            };
            teacher.TeacherDetails = teacherDetails;
        }
        teacherService.Add(teacher);

        return Ok(teacher.Id);
    }

    [HttpPut]
    public IActionResult Edit(TeacherViewModel teacherViewModel)
    {
        Teacher teacher = teacherService.GetWithExpressions(q => q.Id == teacherViewModel.Id, null, c => c.TeacherDetails).FirstOrDefault();
        teacher.Id = teacherViewModel.Id;
        teacher.FirstName = teacherViewModel.FirstName;
        teacher.LastName = teacherViewModel.LastName;

        if (teacherViewModel.Gender != null || teacherViewModel.Age > 0 || teacherViewModel.ChildernNumber > 0 || teacherViewModel.MaritalStatusSelected != MaritalStatusList.NoSelected)
        {
            TeacherDetails teacherDetails = new TeacherDetails()
            {
                Gender = teacherViewModel.Gender,
                MaritalStatus = (byte)teacherViewModel.MaritalStatusSelected == 0 ? false : true,
                ChildernNumber = teacherViewModel.ChildernNumber,
                Age = teacherViewModel.Age
            };
            teacher.TeacherDetails = teacherDetails;
        }
        teacherService.Update(teacher);

        return Ok(teacher.Id + " is updated.");
    }

    [HttpDelete("{teacherId}")]
    public IActionResult Delete(string teacherId)
    {
        Teacher teacher = teacherService.GetWithExpressions(q => q.Id == teacherId, null, c => c.TeacherDetails).FirstOrDefault();
        teacherService.Delete(teacher);
        return Ok(teacherId + " is deleted.");
    }

}