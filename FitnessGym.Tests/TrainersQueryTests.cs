namespace FitnessGym.Tests;

/// <summary>
/// Тесты выборки тренеров по стажу работы
/// </summary>
/// <param name="fixture">Фикстура с тестовыми данными</param>
public class TrainersQueryTests(FitnessGymFixture fixture) : IClassFixture<FitnessGymFixture>
{
    /// <summary>
    /// Проверяет, что в результат попадают только тренеры со стажем не менее 5 лет
    /// </summary>
    [Fact]
    public void GetTrainersByExperience_MinimumFiveYears_ReturnsOnlyEligibleTrainers()
    {
        // arrange
        const int minimumExperience = 5;
        string[] expectedFullNames =
        [
            "Громова Елена Сергеевна",
            "Киселёва Ольга Андреевна",
            "Крылов Дмитрий Андреевич",
            "Николаев Артём Павлович",
            "Орлова Наталья Ивановна",
            "Полякова Марина Владимировна",
            "Романова Екатерина Дмитриевна",
            "Соловьёва Анна Михайловна",
            "Тихонов Игорь Алексеевич",
        ];

        // act
        var actualFullNames = fixture.Trainers
            .Where(t => t.ExperienceYears >= minimumExperience)
            .OrderBy(t => t.FullName)
            .Select(t => t.FullName)
            .ToList();

        // assert
        Assert.Equal(expectedFullNames, actualFullNames);
    }
}