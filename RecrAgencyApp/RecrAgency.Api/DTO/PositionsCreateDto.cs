namespace RecrAgency.Api.DTO;

public class PositionsCreateDto
{
    /// <summary>
    /// Раздел, к которому относится должность (IT, финансы, реклама и т.д.).
    /// </summary>
    public required string Section { get; set; }

    /// <summary>
    /// Наименование должности.
    /// </summary>
    public required string PositionName { get; set; }
}
