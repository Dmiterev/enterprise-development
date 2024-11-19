namespace RecrAgency.Api.DTO;

public class JobApplicationCreateDto
{
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
