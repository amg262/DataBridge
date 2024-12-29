using DataBridge.Options;

namespace UnitTests;

/// <summary>
/// Unit tests for <see cref="DelivraOptions"/>.
/// </summary>
public class DelivraOptionsTests
{
    /// <summary>
    /// Tests the default values of the DelivraOptions properties.
    /// </summary>
    [Fact]
    public void DefaultValues_ReturnsExpectedDefaultValues()
    {
        // Arrange
        var delivraOptions = new DelivraOptions();

        // Act & Assert
        Assert.Null(delivraOptions.BaseUrl);
        Assert.Null(delivraOptions.Username);
        Assert.Null(delivraOptions.Password);
        Assert.Null(delivraOptions.Listname);
    }

    /// <summary>
    /// Tests the property values of the DelivraOptions object.
    /// </summary>
    [Fact]
    public void PropertyValues_SetValues_ReturnsExpectedValues()
    {
        // Arrange
        var delivraOptions = new DelivraOptions
        {
            BaseUrl = "https://integration.delivra.com/DelivraRESTServices/Services.svc/",
            Username = "testuser",
            Password = "testpassword",
            Listname = "testlist"
        };

        // Act & Assert
        Assert.Equal("https://integration.delivra.com/DelivraRESTServices/Services.svc/", delivraOptions.BaseUrl);
        Assert.Equal("testuser", delivraOptions.Username);
        Assert.Equal("testpassword", delivraOptions.Password);
        Assert.Equal("testlist", delivraOptions.Listname);
    }

    /// <summary>
    /// Tests the BaseUrl property of the DelivraOptions object.
    /// </summary>
    [Fact]
    public void BaseUrlProperty_SetValue_ReturnsExpectedValue()
    {
        // Arrange
        var delivraOptions = new DelivraOptions { BaseUrl = "https://integration.delivra.com/DelivraRESTServices/Services.svc/" };

        // Act & Assert
        Assert.Equal("https://integration.delivra.com/DelivraRESTServices/Services.svc/", delivraOptions.BaseUrl);
    }

    /// <summary>
    /// Tests the Username property of the DelivraOptions object.
    /// </summary>
    [Fact]
    public void UsernameProperty_SetValue_ReturnsExpectedValue()
    {
        // Arrange
        var delivraOptions = new DelivraOptions { Username = "testuser" };

        // Act & Assert
        Assert.Equal("testuser", delivraOptions.Username);
    }

    /// <summary>
    /// Tests the Password property of the DelivraOptions object.
    /// </summary>
    [Fact]
    public void PasswordProperty_SetValue_ReturnsExpectedValue()
    {
        // Arrange
        var delivraOptions = new DelivraOptions { Password = "testpassword" };

        // Act & Assert
        Assert.Equal("testpassword", delivraOptions.Password);
    }

    /// <summary>
    /// Tests the Listname property of the DelivraOptions object.
    /// </summary>
    [Fact]
    public void ListnameProperty_SetValue_ReturnsExpectedValue()
    {
        // Arrange
        var delivraOptions = new DelivraOptions { Listname = "testlist" };

        // Act & Assert
        Assert.Equal("testlist", delivraOptions.Listname);
    }

    /// <summary>
    /// Tests the default constructor of the DelivraOptions object.
    /// </summary>
    [Fact]
    public void DefaultConstructor_ReturnsExpectedValues()
    {
        // Arrange
        var delivraOptions = new DelivraOptions();

        // Act & Assert
        Assert.Null(delivraOptions.BaseUrl);
        Assert.Null(delivraOptions.Username);
        Assert.Null(delivraOptions.Password);
        Assert.Null(delivraOptions.Listname);
    }
}