using DataBridge.Options;

namespace UnitTests;

/// <summary>
/// Unit tests for <see cref="JwtOptions"/>.
/// </summary>
public class JwtOptionsTests
{
    /// <summary>
    /// Tests the default values of the JwtOptions properties.
    /// </summary>
    [Fact]
    public void DefaultValues_ReturnsExpectedDefaultValues()
    {
        // Arrange
        var jwtOptions = new JwtOptions();

        // Act & Assert
        Assert.Equal(string.Empty, jwtOptions.Secret);
        Assert.Equal(string.Empty, jwtOptions.Issuer);
        Assert.Equal(string.Empty, jwtOptions.Audience);
        Assert.Equal(30, jwtOptions.ExpirationInDays);
    }

    /// <summary>
    /// Tests the property values of the JwtOptions object.
    /// </summary>
    [Fact]
    public void PropertyValues_SetValues_ReturnsExpectedValues()
    {
        // Arrange
        var jwtOptions = new JwtOptions
        {
            Secret = "mysecret",
            Issuer = "myissuer",
            Audience = "myaudience",
            ExpirationInDays = 60
        };

        // Act & Assert
        Assert.Equal("mysecret", jwtOptions.Secret);
        Assert.Equal("myissuer", jwtOptions.Issuer);
        Assert.Equal("myaudience", jwtOptions.Audience);
        Assert.Equal(60, jwtOptions.ExpirationInDays);
    }

    /// <summary>
    /// Tests the Secret property of the JwtOptions object.
    /// </summary>
    [Fact]
    public void SecretProperty_SetValue_ReturnsExpectedValue()
    {
        // Arrange
        var jwtOptions = new JwtOptions { Secret = "mysecret" };

        // Act & Assert
        Assert.Equal("mysecret", jwtOptions.Secret);
    }

    /// <summary>
    /// Tests the Issuer property of the JwtOptions object.
    /// </summary>
    [Fact]
    public void IssuerProperty_SetValue_ReturnsExpectedValue()
    {
        // Arrange
        var jwtOptions = new JwtOptions { Issuer = "myissuer" };

        // Act & Assert
        Assert.Equal("myissuer", jwtOptions.Issuer);
    }

    /// <summary>
    /// Tests the Audience property of the JwtOptions object.
    /// </summary>
    [Fact]
    public void AudienceProperty_SetValue_ReturnsExpectedValue()
    {
        // Arrange
        var jwtOptions = new JwtOptions { Audience = "myaudience" };

        // Act & Assert
        Assert.Equal("myaudience", jwtOptions.Audience);
    }

    /// <summary>
    /// Tests the ExpirationInDays property of the JwtOptions object.
    /// </summary>
    [Fact]
    public void ExpirationInDaysProperty_SetValue_ReturnsExpectedValue()
    {
        // Arrange
        var jwtOptions = new JwtOptions { ExpirationInDays = 60 };

        // Act & Assert
        Assert.Equal(60, jwtOptions.ExpirationInDays);
    }

    /// <summary>
    /// Tests the default constructor of the JwtOptions object.
    /// </summary>
    [Fact]
    public void DefaultConstructor_ReturnsExpectedValues()
    {
        // Arrange
        var jwtOptions = new JwtOptions();

        // Act & Assert
        Assert.Equal(string.Empty, jwtOptions.Secret);
        Assert.Equal(string.Empty, jwtOptions.Issuer);
        Assert.Equal(string.Empty, jwtOptions.Audience);
        Assert.Equal(30, jwtOptions.ExpirationInDays);
    }
}