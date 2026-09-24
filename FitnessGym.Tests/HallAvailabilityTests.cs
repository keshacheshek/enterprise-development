using FitnessGym.Domain.Enums;

namespace FitnessGym.Tests;

/// <summary>
/// Тесты проверки доступности зала для записи на текущий момент
/// </summary>
/// <param name="fixture">Фикстура с тестовыми данными</param>
public class HallAvailabilityTests(FitnessGymFixture fixture) : IClassFixture<FitnessGymFixture>
{
    /// <summary>
    /// Проверяет, что зал считается недоступным, если в нём идёт занятие,
    /// и доступным, если занятие уже завершилось
    /// </summary>
    /// <param name="hall">Проверяемый зал</param>
    /// <param name="expectedAvailability">Ожидаемая доступность</param>
    [Theory]
    [InlineData(Hall.YogaRoom, false)] // занятие идёт прямо сейчас
    [InlineData(Hall.Ring, true)]      // занятие завершилось 15 минут назад
    public void CheckHallAvailability_HallAtCurrentMoment_ReturnsExpectedAvailability(
        Hall hall,
        bool expectedAvailability)
    {
        // arrange
        var now = fixture.Now;

        // act
        var isAvailable = !fixture.Sessions.Any(s => s.HallName == hall && s.IsInProgressAt(now));

        // assert
        Assert.Equal(expectedAvailability, isAvailable);
    }
}