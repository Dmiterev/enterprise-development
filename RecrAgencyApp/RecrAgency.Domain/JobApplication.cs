using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecrAgency.Domain;

/// <summary>
/// Представляет заявку соискателя.
/// </summary>
public class JobApplication
{
    /// <summary>
    /// Уникальный идентификатор заявки.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор соискателя.
    /// </summary>
    [ForeignKey("SeekerId")]
    public int SeekerId { get; set; }

    /// <summary>
    /// Идентификатор должности.
    /// </summary>
    [ForeignKey("PositionId")]
    public int PositionId { get; set; }

    /// <summary>
    /// Дата подачи заявки.
    /// </summary>
    public DateTime ApplicationDate { get; set; }

    public JobSeeker? JobSeeker { get; set; }

    public Position? Position { get; set; }
}