using System.ComponentModel.DataAnnotations;

namespace RecrAgency.Domain;

/// <summary>
/// Представляет работодателя.
/// </summary>
public class Employer
{
    /// <summary>
    /// Уникальный идентификатор работодателя.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Название компании.
    /// </summary>
    [Required]
    public string CompanyName { get; set; } = string.Empty;

    /// <summary>
    /// ФИО контактного лица.
    /// </summary>
    [Required]
    public string ContactPerson { get; set; } = string.Empty;

    /// <summary>
    /// Контактный телефон работодателя.
    /// </summary>
    [Required]
    public string Phone { get; set; } = string.Empty;

    public ICollection<EmployerApplication> EmployerApplications { get; set; } = new List<EmployerApplication>();
}