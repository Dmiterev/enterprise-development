using Microsoft.AspNetCore.Mvc;
using RecrAgency.Api.DTO;
using RecrAgency.Api.Services.Interfaces;

namespace RecrAgency.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobApplicationController : ControllerBase
{
    private readonly IJobApplicationService _jobApplicationService;

    public JobApplicationController(IJobApplicationService jobApplicationService)
    {
        _jobApplicationService = jobApplicationService;
    }

    /// <summary>
    /// Получить все заявки на работу.
    /// </summary>
    /// <returns>Список заявок на работу.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<JobApplicationDto>> GetJobApplications()
    {
        var jobApplications = _jobApplicationService.GetAll();
        return Ok(jobApplications);
    }

    /// <summary>
    /// Получить заявку на работу по ID.
    /// </summary>
    /// <param name="id">Идентификатор заявки.</param>
    /// <returns>Заявка с указанным ID или статус 404, если заявка не найдена.</returns>
    [HttpGet("{id}")]
    public ActionResult<JobApplicationDto> GetJobApplication(int id)
    {
        var jobApplication = _jobApplicationService.GetById(id);
        if (jobApplication == null) return NotFound();
        return Ok(jobApplication);
    }

    /// <summary>
    /// Создать новую заявку на работу.
    /// </summary>
    /// <param name="jobApplicationCreateDto">Данные для создания заявки.</param>
    /// <returns>Созданная заявка с статусом 201.</returns>
    [HttpPost]
    public ActionResult<JobApplicationDto> CreateJobApplication([FromBody] JobApplicationCreateDto jobApplicationCreateDto)
    {
        var jobApplication = _jobApplicationService.Create(jobApplicationCreateDto);
        return CreatedAtAction(nameof(GetJobApplication), new { id = jobApplication.Id }, jobApplication);
    }

    /// <summary>
    /// Обновить заявку на работу по ID.
    /// </summary>
    /// <param name="id">Идентификатор заявки, которую нужно обновить.</param>
    /// <param name="jobApplicationDto">Новые данные заявки.</param>
    /// <returns>Статус 204, если обновление прошло успешно, или статус 404, если заявка не найдена.</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateJobApplication(int id, [FromBody] JobApplicationDto jobApplicationDto)
    {
        if (!_jobApplicationService.Update(id, jobApplicationDto)) return NotFound();
        return NoContent();
    }

    /// <summary>
    /// Удалить заявку на работу по ID.
    /// </summary>
    /// <param name="id">Идентификатор заявки, которую нужно удалить.</param>
    /// <returns>Статус 204, если удаление прошло успешно, или статус 404, если заявка не найдена.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteJobApplication(int id)
    {
        if (!_jobApplicationService.Delete(id)) return NotFound();
        return NoContent();
    }
}