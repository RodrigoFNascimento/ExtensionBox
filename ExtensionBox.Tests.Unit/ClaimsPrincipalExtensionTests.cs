using System.Collections.Generic;
using System.Security.Claims;

namespace ExtensionBox.Tests.Unit;

public class ClaimsPrincipalExtensionTests
{
    [Fact]
    public void GetClaim_ShouldReturnClaimValue_WhenGivenKeyAndCollection()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, "example name"),
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim("custom-claim", "example claim value"),
        }, "mock"));
        var key = "custom-claim";
        var expected = "example claim value";

        // Act
        var result = user.GetClaim<string>(key);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetClaim_ShouldReturnDefaultValue_WhenValueCantBeFoundAndGivenDefaultReturnValue()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, "example name"),
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim("custom-claim", "example claim value"),
        }, "mock"));
        string key = "qwerty";
        var defaultValue = "s";
        var expected = defaultValue;

        // Act
        var result = user.GetClaim(key, defaultValue);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetClaim_ShouldThrowException_WhenKeyCantBeFound()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, "example name"),
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim("custom-claim", "example claim value"),
        }, "mock"));
        var key = "qwerty";

        // Act

        // Assert
        Assert.Throws<KeyNotFoundException>(() => user.GetClaim<int>(key));
    }

    [Fact]
    public void GetClaim_ShouldThrowException_WhenValueCantBeConverted()
    {
        // Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, "example name"),
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim("custom-claim", "example claim value"),
        }, "mock"));
        var key = "custom-claim";

        // Act

        // Assert
        Assert.Throws<FormatException>(() => user.GetClaim<int>(key));
    }
}
