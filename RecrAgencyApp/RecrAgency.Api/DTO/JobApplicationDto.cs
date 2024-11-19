namespace RecrAgency.Api.DTO;

public class JobApplicationDto
{
    /// <summary>
    /// Уникальный идентификатор заявки.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор соискателя.
    /// </summary>
    public int SeekerId { get; set; }

    /// <summary>
    /// Идентификатор должности.
    /// </summary>
    public int PositionId { get; set; }

    /// <summary>
    /// Дата подачи заявки.
    /// </summary>
    public DateTime ApplicationDate { get; set; }
}

