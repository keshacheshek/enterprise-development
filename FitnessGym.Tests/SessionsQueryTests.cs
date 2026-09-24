using FitnessGym.Domain.Enums;

namespace FitnessGym.Tests;

/// <summary>
/// Тесты выборки занятий за текущий месяц в выбранном зале
/// </summary>
/// <param name="fixture">Фикстура с тестовыми данными</param>
public class SessionsQueryTests(FitnessGymFixture fixture) : IClassFixture<FitnessGymFixture>
{
    /// <summary>
    /// Проверяет, что возвращаются только занятия выбранного зала за текущий месяц
    /// </summary>
    [Fact]
    public void GetCurrentMonthSessionsInHall_SelectedHall_ReturnsOnlyCurrentMonthSessions()
    {
        // arrange
        var selectedHall = Hall.Gym;
        var today = fixture.Today;
        int[] expectedSessionIds = [0, 1, 2];

        // act
        var actualSessionIds = fixture.Sessions
            .Where(s => s.HallName == selectedHall
                        && s.StartsTraining.Year == today.Year
                        && s.StartsTraining.Month == today.Month)
            .OrderBy(s => s.Id)
            .Select(s => s.Id)
            .ToList();

        // assert
        Assert.Equal(expectedSessionIds, actualSessionIds);
    }
}