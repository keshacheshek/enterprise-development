namespace FitnessGym.Tests;

/// <summary>
/// Тесты выборки клиентов с истёкшим абонементом
/// </summary>
/// <param name="fixture">Фикстура с тестовыми данными</param>
public class ExpiredSubscriptionTests(FitnessGymFixture fixture) : IClassFixture<FitnessGymFixture>
{
    /// <summary>
    /// Проверяет, что возвращаются только клиенты с истёкшим абонементом,
    /// упорядоченные по ФИО
    /// </summary>
    [Fact]
    public void GetClientsWithExpiredSubscription_ExpiredSubscription_ReturnsClientsOrderedByFullName()
    {
        // arrange
        var today = fixture.Today;
        string[] expectedFullNames =
        [
            "Гусев Роман Валерьевич",
            "Ершова Полина Дмитриевна",
            "Медведев Артур Игоревич",
            "Соколова Виктория Андреевна",
            "Фролов Никита Сергеевич",
        ];

        // act
        var actualFullNames = fixture.Clients
            .Where(c => c.SubscriptionEnd < today)
            .OrderBy(c => c.FullName)
            .Select(c => c.FullName)
            .ToList();

        // assert
        Assert.Equal(expectedFullNames, actualFullNames);
    }
}