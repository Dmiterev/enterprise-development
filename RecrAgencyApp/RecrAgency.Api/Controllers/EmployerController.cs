using Microsoft.AspNetCore.Mvc;
using RecrAgency.Api.DTO;
using RecrAgency.Api.Services.Interfaces;

namespace RecrAgency.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;

        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        /// <summary>
        /// Получить всех работодателей.
        /// </summary>
        /// <returns>Список работодателей.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<EmployerDto>> GetEmployers()
        {
            var employers = _employerService.GetAll();
            return Ok(employers);
        }

        /// <summary>
        /// Получить работодателя по ID.
        /// </summary>
        /// <param name="id">Идентификатор работодателя.</param>
        /// <returns>Работодатель с указанным ID или статус 404, если работодатель не найден.</returns>
        [HttpGet("{id}")]
        public ActionResult<EmployerDto> GetEmployer(int id)
        {
            var employer = _employerService.GetById(id);
            if (employer == null) return NotFound();
            return Ok(employer);
        }

        /// <summary>
        /// Создать нового работодателя.
        /// </summary>
        /// <param name="employerCreateDto">Данные для создания работодателя.</param>
        /// <returns>Созданный работодатель с статусом 201.</returns>
        [HttpPost]
        public ActionResult<EmployerDto> CreateEmployer([FromBody] EmployerCreateDto employerCreateDto)
        {
            var employer = _employerService.Create(employerCreateDto);
            return CreatedAtAction(nameof(GetEmployer), new { id = employer.Id }, employer);
        }

        /// <summary>
        /// Обновить информацию о работодателе по ID.
        /// </summary>
        /// <param name="id">Идентификатор работодателя, которого нужно обновить.</param>
        /// <param name="employerDto">Новые данные о работодателе.</param>
        /// <returns>Статус 204, если обновление прошло успешно, или статус 404, если работодатель не найден.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateEmployer(int id, [FromBody] EmployerDto employerDto)
        {
            if (!_employerService.Update(id, employerDto)) return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Удалить работодателя по ID.
        /// </summary>
        /// <param name="id">Идентификатор работодателя, которого нужно удалить.</param>
        /// <returns>Статус 204, если удаление прошло успешно, или статус 404, если работодатель не найден.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployer(int id)
        {
            if (!_employerService.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}