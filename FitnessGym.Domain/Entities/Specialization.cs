namespace FitnessGym.Domain.Entities;

/// <summary>
/// Специализация тренера
/// </summary>
public class Specialization
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public required string Name { get; set; }
}