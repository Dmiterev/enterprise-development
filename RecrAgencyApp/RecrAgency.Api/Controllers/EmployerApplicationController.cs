using Microsoft.AspNetCore.Mvc;
using RecrAgency.Api.DTO;
using RecrAgency.Api.Services.Interfaces;

namespace RecrAgency.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployerApplicationController : ControllerBase
{
    private readonly IEmployerApplicationService _employerApplicationService;

    public EmployerApplicationController(IEmployerApplicationService employerApplicationService)
    {
        _employerApplicationService = employerApplicationService;
    }

    /// <summary>
    /// Получить все заявки работодателей.
    /// </summary>
    /// <returns>Список заявок работодателей.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<EmployerApplicationDto>> GetEmployerApplications()
    {
        var employerApplications = _employerApplicationService.GetAll();
        return Ok(employerApplications);
    }

    /// <summary>
    /// Получить заявку работодателя по ID.
    /// </summary>
    /// <param name="id">Идентификатор заявки.</param>
    /// <returns>Заявка с указанным ID или статус 404, если заявка не найдена.</returns>
    [HttpGet("{id}")]
    public ActionResult<EmployerApplicationDto> GetEmployerApplication(int id)
    {
        var employerApplication = _employerApplicationService.GetById(id);
        if (employerApplication == null) return NotFound();
        return Ok(employerApplication);
    }

    /// <summary>
    /// Создать новую заявку работодателя.
    /// </summary>
    /// <param name="employerApplicationCreateDto">Данные заявки для создания.</param>
    /// <returns>Созданная заявка с статусом 201.</returns>
    [HttpPost]
    public ActionResult<EmployerApplicationDto> CreateEmployerApplication([FromBody] EmployerApplicationCreateDto employerApplicationCreateDto)
    {
        var employerApplication = _employerApplicationService.Create(employerApplicationCreateDto);
        return CreatedAtAction(nameof(GetEmployerApplication), new { id = employerApplication.Id }, employerApplication);
    }

    /// <summary>
    /// Обновить заявку работодателя по ID.
    /// </summary>
    /// <param name="id">Идентификатор заявки, которую нужно обновить.</param>
    /// <param name="employerApplicationDto">Новые данные заявки.</param>
    /// <returns>Статус 204, если обновление прошло успешно, или статус 404, если заявка не найдена.</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateEmployerApplication(int id, [FromBody] EmployerApplicationDto employerApplicationDto)
    {
        if (!_employerApplicationService.Update(id, employerApplicationDto)) return NotFound();
        return NoContent();
    }

    /// <summary>
    /// Удалить заявку работодателя по ID.
    /// </summary>
    /// <param name="id">Идентификатор заявки, которую нужно удалить.</param>
    /// <returns>Статус 204, если удаление прошло успешно, или статус 404, если заявка не найдена.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteEmployerApplication(int id)
    {
        if (!_employerApplicationService.Delete(id)) return NotFound();
        return NoContent();
    }
}