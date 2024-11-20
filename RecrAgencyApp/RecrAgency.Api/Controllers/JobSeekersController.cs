using Microsoft.AspNetCore.Mvc;
using RecrAgency.Api.DTO;
using RecrAgency.Api.Services.Interfaces;

namespace RecrAgency.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobSeekerController : ControllerBase
{
    private readonly IJobSeekersService _jobSeekerService;

    public JobSeekerController(IJobSeekersService jobSeekerService)
    {
        _jobSeekerService = jobSeekerService;
    }

    /// <summary>
    /// Получить всех соискателей.
    /// </summary>
    /// <returns>Список соискателей.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<JobSeekersDto>> GetJobSeekers()
    {
        var jobSeekers = _jobSeekerService.GetAll();
        return Ok(jobSeekers);
    }

    /// <summary>
    /// Получить соискателя по ID.
    /// </summary>
    /// <param name="id">Идентификатор соискателя.</param>
    /// <returns>Соискатель с указанным ID или статус 404, если соискатель не найден.</returns>
    [HttpGet("{id}")]
    public ActionResult<JobSeekersDto> GetJobSeeker(int id)
    {
        var jobSeeker = _jobSeekerService.GetById(id);
        if (jobSeeker == null) return NotFound();
        return Ok(jobSeeker);
    }

    /// <summary>
    /// Создать нового соискателя.
    /// </summary>
    /// <param name="jobSeekerCreateDto">Данные для создания соискателя.</param>
    /// <returns>Созданный соискатель с статусом 201.</returns>
    [HttpPost]
    public ActionResult<JobSeekersDto> CreateJobSeeker([FromBody] JobSeekersCreateDto jobSeekerCreateDto)
    {
        var jobSeeker = _jobSeekerService.Create(jobSeekerCreateDto);
        return CreatedAtAction(nameof(GetJobSeeker), new { id = jobSeeker.Id }, jobSeeker);
    }

    /// <summary>
    /// Обновить информацию о соискателе по ID.
    /// </summary>
    /// <param name="id">Идентификатор соискателя, которого нужно обновить.</param>
    /// <param name="jobSeekerDto">Новые данные о соискателе.</param>
    /// <returns>Статус 204, если обновление прошло успешно, или статус 404, если соискатель не найден.</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateJobSeeker(int id, [FromBody] JobSeekersDto jobSeekerDto)
    {
        if (!_jobSeekerService.Update(id, jobSeekerDto)) return NotFound();
        return NoContent();
    }

    /// <summary>
    /// Удалить соискателя по ID.
    /// </summary>
    /// <param name="id">Идентификатор соискателя, которого нужно удалить.</param>
    /// <returns>Статус 204, если удаление прошло успешно, или статус 404, если соискатель не найден.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteJobSeeker(int id)
    {
        if (!_jobSeekerService.Delete(id)) return NotFound();
        return NoContent();
    }
}