using FluentAssertions;
using Moq;
using NoExp.Application.Services;
using NoExp.Domain.Entities;
using NoExp.Domain.Entities.Abstracts;
using NoExp.Domain.Interfaces;

namespace NoExp.Application.Tests.Services;

public class ProfileServiceTests
{
    private readonly Mock<IProfileRepository> _mockRepository;
    private readonly ProfileService _service;

    public ProfileServiceTests()
    {
        _mockRepository = new Mock<IProfileRepository>();
        _service = new ProfileService(_mockRepository.Object);
    }

    #region SaveProfileAsync Tests

    [Fact]
    public async Task SaveProfileAsync_ShouldReturnSavedProfile_WhenCandidateProfileIsValid()
    {
        // Arrange
        var candidateProfile = new CandidateProfile
        {
            Id = "profile-123",
            UserId = "user-123",
            Bio = "Experienced developer",
            Location = "New York",
            Skills = "C#, .NET, Azure",
            Experience = "5 years",
            Education = "BSc Computer Science",
            IsOpenToWork = true,
            ExpectedSalary = 100000
        };

        _mockRepository
            .Setup(repo => repo.AddProfileAsync(It.IsAny<UserProfile>()))
            .ReturnsAsync(candidateProfile);

        // Act
        var result = await _service.SaveProfileAsync(candidateProfile);

        // Assert
        result.Should().NotBeNull();
        result.Should().Be(candidateProfile);
        result.Should().BeOfType<CandidateProfile>();
        ((CandidateProfile)result).Skills.Should().Be("C#, .NET, Azure");
        _mockRepository.Verify(repo => repo.AddProfileAsync(candidateProfile), Times.Once);
    }

    [Fact]
    public async Task SaveProfileAsync_ShouldReturnSavedProfile_WhenEmployerProfileIsValid()
    {
        // Arrange
        var employerProfile = new EmployerProfile
        {
            Id = "profile-456",
            UserId = "user-456",
            CompanyName = "Tech Corp",
            IdentificationNumber = "123456789",
            CompanyDescription = "Leading tech company",
            CompanySize = 500,
            CompanyAddress = "123 Tech Street",
            IsVerified = true
        };

        _mockRepository
            .Setup(repo => repo.AddProfileAsync(It.IsAny<UserProfile>()))
            .ReturnsAsync(employerProfile);

        // Act
        var result = await _service.SaveProfileAsync(employerProfile);

        // Assert
        result.Should().NotBeNull();
        result.Should().Be(employerProfile);
        result.Should().BeOfType<EmployerProfile>();
        ((EmployerProfile)result).CompanyName.Should().Be("Tech Corp");
        _mockRepository.Verify(repo => repo.AddProfileAsync(employerProfile), Times.Once);
    }

    #endregion

    #region GetEmployerProfileByUserIdAsync Tests

    [Fact]
    public async Task GetEmployerProfileByUserIdAsync_ShouldReturnProfile_WhenProfileExists()
    {
        // Arrange
        var userId = "user-123";
        var employerProfile = new EmployerProfile
        {
            Id = "profile-123",
            UserId = userId,
            CompanyName = "Test Company",
            IdentificationNumber = "987654321",
            IsVerified = false
        };

        _mockRepository
            .Setup(repo => repo.GetEmployerProfileByUserIdAsync(userId))
            .ReturnsAsync(employerProfile);

        // Act
        var result = await _service.GetEmployerProfileByUserIdAsync(userId);

        // Assert
        result.Should().NotBeNull();
        result!.UserId.Should().Be(userId);
        result.CompanyName.Should().Be("Test Company");
        _mockRepository.Verify(repo => repo.GetEmployerProfileByUserIdAsync(userId), Times.Once);
    }

    [Fact]
    public async Task GetEmployerProfileByUserIdAsync_ShouldReturnNull_WhenProfileDoesNotExist()
    {
        // Arrange
        var userId = "nonexistent-user";

        _mockRepository
            .Setup(repo => repo.GetEmployerProfileByUserIdAsync(userId))
            .ReturnsAsync((EmployerProfile?)null);

        // Act
        var result = await _service.GetEmployerProfileByUserIdAsync(userId);

        // Assert
        result.Should().BeNull();
        _mockRepository.Verify(repo => repo.GetEmployerProfileByUserIdAsync(userId), Times.Once);
    }

    #endregion

    #region GetCandidateProfileByUserIdAsync Tests

    [Fact]
    public async Task GetCandidateProfileByUserIdAsync_ShouldReturnProfile_WhenProfileExists()
    {
        // Arrange
        var userId = "user-456";
        var candidateProfile = new CandidateProfile
        {
            Id = "profile-456",
            UserId = userId,
            Skills = "Python, Django, PostgreSQL",
            Experience = "3 years",
            IsOpenToWork = true,
            ExpectedSalary = 75000
        };

        _mockRepository
            .Setup(repo => repo.GetCandidateProfileByUserIdAsync(userId))
            .ReturnsAsync(candidateProfile);

        // Act
        var result = await _service.GetCandidateProfileByUserIdAsync(userId);

        // Assert
        result.Should().NotBeNull();
        result!.UserId.Should().Be(userId);
        result.Skills.Should().Be("Python, Django, PostgreSQL");
        result.IsOpenToWork.Should().BeTrue();
        _mockRepository.Verify(repo => repo.GetCandidateProfileByUserIdAsync(userId), Times.Once);
    }

    #endregion

    #region UpdateEmployerProfileAsync Tests

    [Fact]
    public async Task UpdateEmployerProfileAsync_ShouldReturnUpdatedProfile_WhenProfileIsValid()
    {
        // Arrange
        var employerProfile = new EmployerProfile
        {
            Id = "profile-789",
            UserId = "user-789",
            CompanyName = "Updated Company Name",
            IdentificationNumber = "111222333",
            CompanyDescription = "Updated description",
            CompanySize = 1000,
            IsVerified = true,
            UpdatedAt = DateTime.UtcNow
        };

        _mockRepository
            .Setup(repo => repo.UpdateEmployerProfileAsync(It.IsAny<EmployerProfile>()))
            .ReturnsAsync(employerProfile);

        // Act
        var result = await _service.UpdateEmployerProfileAsync(employerProfile);

        // Assert
        result.Should().NotBeNull();
        result.Should().Be(employerProfile);
        result.CompanyName.Should().Be("Updated Company Name");
        result.IsVerified.Should().BeTrue();
        result.UpdatedAt.Should().NotBeNull();
        _mockRepository.Verify(repo => repo.UpdateEmployerProfileAsync(employerProfile), Times.Once);
    }

    #endregion
}