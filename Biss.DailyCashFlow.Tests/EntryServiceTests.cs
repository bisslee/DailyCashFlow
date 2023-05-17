using Biss.DailyCashFlow.Data.Interface;
using Biss.DailyCashFlow.Domain.Entities;
using Biss.DailyCashFlow.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Biss.DailyCashFlow.Tests;

[TestFixture]
public class EntryServiceTests
{
    private Mock<IEntryRepository> _entryRepositoryMock;
    private EntryService _entryService;

    [SetUp]
    public void Setup()
    {
        _entryRepositoryMock = new Mock<IEntryRepository>();
        _entryService = new EntryService(_entryRepositoryMock.Object);
    }

    [Test]
    public void AddEntryAsync_WhenDescriptionIsNullOrEmpty_ThrowsArgumentException()
    {
        // Arrange
        var entity = new Entry { Description = string.Empty, Value = 100 };

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(() => _entryService.AddEntryAsync(entity));
    }

    [Test]
    public void AddEntryAsync_WhenValueIsZero_ThrowsArgumentException()
    {
        // Arrange
        var entity = new Entry { Description = "Test Entry", Value = 0 };

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(() => _entryService.AddEntryAsync(entity));
    }

    [Test]
    public async Task AddEntryAsync_AssignsNewGuidToEntryId()
    {
        // Arrange
        var entity = new Entry { Description = "Test Entry", Value = 100 };

        // Act
        await _entryService.AddEntryAsync(entity);

        // Assert
        Assert.That(entity.Id, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public async Task AddEntryAsync_CallsAddEntryAsyncOnRepository()
    {
        // Arrange
        var entity = new Entry { Description = "Test Entry", Value = 100 };

        // Act
        await _entryService.AddEntryAsync(entity);

        // Assert
        _entryRepositoryMock.Verify(r => r.AddEntryAsync(entity), Times.Once);
    }
}