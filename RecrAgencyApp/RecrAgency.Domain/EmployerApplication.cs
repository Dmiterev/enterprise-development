﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecrAgency.Domain;

/// <summary>
/// Представляет заявку работодателя.
/// </summary>
public class EmployerApplication
{
    /// <summary>
    /// Уникальный идентификатор заявки.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор работодателя.
    /// </summary>
    [ForeignKey("EmployerId")]
    public int EmployerId { get; set; }

    /// <summary>
    /// Идентификатор должности.
    /// </summary>
    [ForeignKey("PositionId")]
    public int PositionId { get; set; }

    /// <summary>
    /// Набор требований к соискателю.
    /// </summary>
    [Required]
    public string Requirements { get; set; } = string.Empty;

    /// <summary>
    /// Предлагаемый уровень зарплаты.
    /// </summary>
    public decimal OfferedSalary { get; set; }

    /// <summary>
    /// Дата подачи заявки.
    /// </summary>
    public DateTime ApplicationDate { get; set; }

    public Employer? Employer { get; set; }

    public Position? Position { get; set; }
}