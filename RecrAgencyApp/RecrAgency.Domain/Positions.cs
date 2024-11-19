using System.ComponentModel.DataAnnotations;

namespace RecrAgency.Domain;

/// <summary>
/// Представляет должность.
/// </summary>
public class Position
{
    /// <summary>
    /// Уникальный идентификатор должности.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Раздел, к которому относится должность (IT, финансы, реклама и т.д.).
    /// </summary>
    [Required]
    public string Section { get; set; } = string.Empty;


    /// <summary>
    /// Наименование должности.
    /// </summary>
    [Required]
    public string PositionName { get; set; } = string.Empty;

    public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
}