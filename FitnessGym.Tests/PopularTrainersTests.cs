namespace FitnessGym.Tests;

/// <summary>
/// Тесты определения наиболее популярных тренеров
/// </summary>
/// <param name="fixture">Фикстура с тестовыми данными</param>
public class PopularTrainersTests(FitnessGymFixture fixture) : IClassFixture<FitnessGymFixture>
{
    /// <summary>
    /// Проверяет, что возвращаются пять тренеров с наибольшим числом занятий,
    /// упорядоченные по убыванию популярности
    /// </summary>
    [Fact]
    public void GetTopFivePopularTrainers_AllSessions_ReturnsTopFiveTrainers()
    {
        // arrange
        string[] expectedFullNames =
        [
            "Тарасов Андрей Викторович",
            "Громова Елена Сергеевна",
            "Белов Максим Олегович",
            "Орлова Наталья Ивановна",
            "Крылов Дмитрий Андреевич",
        ];

        // act
        var actualFullNames = fixture.Sessions
            .GroupBy(s => s.Trainer)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key.FullName)
            .ToList();

        // assert
        Assert.Equal(expectedFullNames, actualFullNames);
    }
}