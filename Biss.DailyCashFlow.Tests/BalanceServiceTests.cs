using Biss.DailyCashFlow.Data.Interface;
using Biss.DailyCashFlow.Domain.Entities;
using Biss.DailyCashFlow.Service;
using Moq;

namespace Biss.DailyCashFlow.Tests;

[TestFixture]
public class BalanceServiceTests
{
    private Mock<IEntryRepository> _entryRepositoryMock;
    private BalanceService _balanceService;

    [SetUp]
    public void Setup()
    {
        _entryRepositoryMock = new Mock<IEntryRepository>();
        _balanceService = new BalanceService(_entryRepositoryMock.Object);
    }

    [Test]
    public async Task GetBalanceAsync_ReturnsCorrectSumOfEntryValues()
    {
        // Arrange
        var dateTime = DateTime.Now;
        var entries = new List<Entry>
        {
            new Entry { Description = "Entry 1", Value = 100 },
            new Entry { Description = "Entry 2", Value = 200 },
            new Entry { Description = "Entry 3", Value = 300 }
        };
        _entryRepositoryMock.Setup(r => r.ListEntryAsync(dateTime)).ReturnsAsync(entries);

        // Act
        var balance = await _balanceService.GetBalanceAsync(dateTime);

        // Assert
        Assert.That(balance.Value, Is.EqualTo(entries.Sum(e => e.Value)));
    }
}

