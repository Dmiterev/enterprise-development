namespace RecrAgency.Api.DTO;

public class JobSeekersCreateDto
{
    /// <summary>
    /// Полное имя соискателя.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Контактный телефон соискателя.
    /// </summary>
    public required string Phone { get; set; }

    /// <summary>
    /// Описание опыта работы соискателя.
    /// </summary>
    public required string WorkExperience { get; set; }

    /// <summary>
    /// Образование соискателя.
    /// </summary>
    public required string Education { get; set; }

    /// <summary>
    /// Желаемый уровень зарплаты соискателя.
    /// </summary>
    public decimal DesiredSalary { get; set; }
}

