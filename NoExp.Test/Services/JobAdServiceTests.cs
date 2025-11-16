using FluentAssertions;
using Moq;
using NoExp.Application.Services;
using NoExp.Domain.Entities;
using NoExp.Domain.Enums.JobAd;
using NoExp.Domain.Interfaces;

namespace NoExp.Application.Tests.Services;

public class JobAdServiceTests
{
    private readonly Mock<IJobAdRepository> _mockRepository;
    private readonly JobAdService _service;

    public JobAdServiceTests()
    {
        _mockRepository = new Mock<IJobAdRepository>();
        _service = new JobAdService(_mockRepository.Object);
    }

    #region SaveJobAdAsync Tests

    [Fact]
    public async Task SaveJobAdAsync_ShouldReturnSavedJobAd_WhenJobAdIsValid()
    {
        // Arrange
        var employerProfile = new EmployerProfile
        {
            Id = "employer-123",
            UserId = "user-123",
            CompanyName = "Test Company"
        };

        var jobAd = new JobAd
        {
            Id = Guid.NewGuid(),
            Title = "Senior .NET Developer",
            Description = "We are looking for a senior developer",
            WorkType = WorkType.FullTime,
            Location = "New York",
            WorkMode = WorkMode.Remote,
            SalaryMin = 80000,
            SalaryMax = 120000,
            TechStack = new List<string> { "C#", ".NET", "Azure" },
            PublishDate = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow.AddDays(30),
            WorkStatus = WorkStatus.Active,
            EmployerProfileId = employerProfile.Id,
            EmployerProfile = employerProfile
        };

        _mockRepository
            .Setup(repo => repo.AddJobAdAsync(It.IsAny<JobAd>()))
            .ReturnsAsync(jobAd);

        // Act
        var result = await _service.SaveJobAdAsync(jobAd);

        // Assert
        result.Should().NotBeNull();
        result.Should().Be(jobAd);
        result.Title.Should().Be("Senior .NET Developer");
        _mockRepository.Verify(repo => repo.AddJobAdAsync(jobAd), Times.Once);
    }

    #endregion

    #region GetAllJobAdsAsync Tests

    [Fact]
    public async Task GetAllJobAdsAsync_ShouldReturnAllJobAds_WhenJobAdsExist()
    {
        // Arrange
        var employerProfile = new EmployerProfile
        {
            Id = "employer-123",
            UserId = "user-123",
            CompanyName = "Test Company"
        };

        var jobAds = new List<JobAd>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Backend Developer",
                Description = "Backend position",
                WorkType = WorkType.FullTime,
                Location = "London",
                WorkMode = WorkMode.Hybrid,
                SalaryMin = 60000,
                SalaryMax = 90000,
                TechStack = new List<string> { "C#", "SQL" },
                EmployerProfileId = employerProfile.Id,
                EmployerProfile = employerProfile
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Frontend Developer",
                Description = "Frontend position",
                WorkType = WorkType.FullTime,
                Location = "Berlin",
                WorkMode = WorkMode.Remote,
                SalaryMin = 55000,
                SalaryMax = 85000,
                TechStack = new List<string> { "React", "TypeScript" },
                EmployerProfileId = employerProfile.Id,
                EmployerProfile = employerProfile
            }
        };

        _mockRepository
            .Setup(repo => repo.GetAllJobAdsAsync())
            .ReturnsAsync(jobAds);

        // Act
        var result = await _service.GetAllJobAdsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(jobAds);
        _mockRepository.Verify(repo => repo.GetAllJobAdsAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAllJobAdsAsync_ShouldReturnEmptyList_WhenNoJobAdsExist()
    {
        // Arrange
        _mockRepository
            .Setup(repo => repo.GetAllJobAdsAsync())
            .ReturnsAsync(new List<JobAd>());

        // Act
        var result = await _service.GetAllJobAdsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
        _mockRepository.Verify(repo => repo.GetAllJobAdsAsync(), Times.Once);
    }

    #endregion

    #region GetAllEmployerJobAdsAsync Tests

    [Fact]
    public async Task GetAllEmployerJobAdsAsync_ShouldReturnJobAdsForEmployer_WhenEmployerHasJobAds()
    {
        // Arrange
        var employerProfileId = "employer-123";
        var employerProfile = new EmployerProfile
        {
            Id = employerProfileId,
            UserId = "user-123",
            CompanyName = "Test Company"
        };

        var jobAds = new List<JobAd>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Job 1",
                Description = "Description 1",
                WorkType = WorkType.FullTime,
                Location = "Location 1",
                WorkMode = WorkMode.Remote,
                SalaryMin = 50000,
                SalaryMax = 70000,
                TechStack = new List<string> { "C#" },
                EmployerProfileId = employerProfileId,
                EmployerProfile = employerProfile
            }
        };

        _mockRepository
            .Setup(repo => repo.GetJobAdsByEmployerProfileIdAsync(employerProfileId))
            .ReturnsAsync(jobAds);

        // Act
        var result = await _service.GetAllEmployerJobAdsAsync(employerProfileId);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result.Should().AllSatisfy(ad => ad.EmployerProfileId.Should().Be(employerProfileId));
        _mockRepository.Verify(repo => repo.GetJobAdsByEmployerProfileIdAsync(employerProfileId), Times.Once);
    }

    #endregion

    #region GetJobAdByIdAsync Tests

    [Fact]
    public async Task GetJobAdByIdAsync_ShouldReturnJobAd_WhenJobAdExists()
    {
        // Arrange
        var jobAdId = Guid.NewGuid();
        var employerProfile = new EmployerProfile
        {
            Id = "employer-123",
            UserId = "user-123",
            CompanyName = "Test Company"
        };

        var jobAd = new JobAd
        {
            Id = jobAdId,
            Title = "Test Job",
            Description = "Test Description",
            WorkType = WorkType.Freelance,
            Location = "Anywhere",
            WorkMode = WorkMode.Remote,
            SalaryMin = 40000,
            SalaryMax = 60000,
            TechStack = new List<string> { "JavaScript", "Node.js" },
            EmployerProfileId = employerProfile.Id,
            EmployerProfile = employerProfile
        };

        _mockRepository
            .Setup(repo => repo.GetJobAdByIdAsync(jobAdId))
            .ReturnsAsync(jobAd);

        // Act
        var result = await _service.GetJobAdByIdAsync(jobAdId);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(jobAdId);
        result.Title.Should().Be("Test Job");
        _mockRepository.Verify(repo => repo.GetJobAdByIdAsync(jobAdId), Times.Once);
    }

    [Fact]
    public async Task GetJobAdByIdAsync_ShouldReturnNull_WhenJobAdDoesNotExist()
    {
        // Arrange
        var jobAdId = Guid.NewGuid();

        _mockRepository
            .Setup(repo => repo.GetJobAdByIdAsync(jobAdId))
            .ReturnsAsync((JobAd?)null);

        // Act
        var result = await _service.GetJobAdByIdAsync(jobAdId);

        // Assert
        result.Should().BeNull();
        _mockRepository.Verify(repo => repo.GetJobAdByIdAsync(jobAdId), Times.Once);
    }

    #endregion
}