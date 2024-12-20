﻿using System.ComponentModel.DataAnnotations;

namespace RecrAgency.Domain;

/// <summary>
/// Представляет соискателя.
/// </summary>
public class JobSeeker
{
    /// <summary>
    /// Уникальный идентификатор соискателя.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Полное имя соискателя.
    /// </summary>
    [Required]
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Контактный телефон соискателя.
    /// </summary>
    [Required]
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Описание опыта работы соискателя.
    /// </summary>
    [Required]
    public string WorkExperience { get; set; } = string.Empty;

    /// <summary>
    /// Образование соискателя.
    /// </summary>
    [Required]
    public string Education { get; set; } = string.Empty;

    /// <summary>
    /// Желаемый уровень зарплаты соискателя.
    /// </summary>
    public decimal DesiredSalary { get; set; } = 0;

    public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
}