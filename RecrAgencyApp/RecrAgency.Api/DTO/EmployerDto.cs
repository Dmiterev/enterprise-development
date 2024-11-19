namespace RecrAgency.Api.DTO;

public class EmployerDto
{
    /// <summary>
    /// Уникальный идентификатор работодателя.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название компании.
    /// </summary>
    public required string CompanyName { get; set; }

    /// <summary>
    /// ФИО контактного лица.
    /// </summary>
    public required string ContactPerson { get; set; }

    /// <summary>
    /// Контактный телефон работодателя.
    /// </summary>
    public required string Phone { get; set; }
}
