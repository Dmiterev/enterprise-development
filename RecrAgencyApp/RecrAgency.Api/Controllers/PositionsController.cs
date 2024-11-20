using Microsoft.AspNetCore.Mvc;
using RecrAgency.Api.DTO;
using RecrAgency.Api.Services.Interfaces;

namespace RecrAgency.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionController : ControllerBase
{
    private readonly IPositionsService _positionService;

    public PositionController(IPositionsService positionService)
    {
        _positionService = positionService;
    }

    /// <summary>
    /// Получить все должности.
    /// </summary>
    /// <returns>Список должностей.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PositionsDto>> GetPositions()
    {
        var positions = _positionService.GetAll();
        return Ok(positions);
    }

    /// <summary>
    /// Получить должность по ID.
    /// </summary>
    /// <param name="id">Идентификатор должности.</param>
    /// <returns>Должность с указанным ID или статус 404, если должность не найдена.</returns>
    [HttpGet("{id}")]
    public ActionResult<PositionsDto> GetPosition(int id)
    {
        var position = _positionService.GetById(id);
        if (position == null) return NotFound();
        return Ok(position);
    }

    /// <summary>
    /// Создать новую должность.
    /// </summary>
    /// <param name="positionCreateDto">Данные должности для создания.</param>
    /// <returns>Созданная должность с статусом 201.</returns>
    [HttpPost]
    public ActionResult<PositionsDto> CreatePosition([FromBody] PositionsCreateDto positionCreateDto)
    {
        var position = _positionService.Create(positionCreateDto);
        return CreatedAtAction(nameof(GetPosition), new { id = position.Id }, position);
    }

    /// <summary>
    /// Обновить должность по ID.
    /// </summary>
    /// <param name="id">Идентификатор должности, которую нужно обновить.</param>
    /// <param name="positionDto">Новые данные должности.</param>
    /// <returns>Статус 204, если обновление прошло успешно, или статус 404, если должность не найдена.</returns>
    [HttpPut("{id}")]
    public IActionResult UpdatePosition(int id, [FromBody] PositionsDto positionDto)
    {
        if (!_positionService.Update(id, positionDto)) return NotFound();
        return NoContent();
    }

    /// <summary>
    /// Удалить должность по ID.
    /// </summary>
    /// <param name="id">Идентификатор должности, которую нужно удалить.</param>
    /// <returns>Статус 204, если удаление прошло успешно, или статус 404, если должность не найдена.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeletePosition(int id)
    {
        if (!_positionService.Delete(id)) return NotFound();
        return NoContent();
    }
}