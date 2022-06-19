namespace ExtensionBox.Tests.Unit;

public class TypeExtensionTests
{
    [Theory]
    [InlineData(typeof(int?), true)]
    [InlineData(typeof(int), false)]
    [InlineData(typeof(string), false)]
    [InlineData(typeof(TestClass), false)]
    public void IsNullable_ShouldReturnTrue_WhenTypeIsNullable(Type type, bool expected)
    {
        // Arrange

        // Act
        var result = type.IsNullable();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(typeof(int?), true)]
    [InlineData(typeof(int), false)]
    [InlineData(typeof(string), false)]
    [InlineData(typeof(TestClass), false)]
    [InlineData(typeof(bool?), false)]
    public void IsNullableNumeric_ShouldReturnTrue_WhenTypeIsNullableNumeric(Type type, bool expected)
    {
        // Arrange

        // Act
        var result = type.IsNullableNumeric();

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(typeof(int?), true)]
    [InlineData(typeof(int), true)]
    [InlineData(typeof(string), false)]
    [InlineData(typeof(TestClass), false)]
    [InlineData(typeof(bool?), false)]
    [InlineData(typeof(byte), true)]
    public void IsNumeric_ShouldReturnTrue_WhenTypeIsNumeric(Type type, bool expected)
    {
        // Arrange

        // Act
        var result = type.IsNumeric();

        // Assert
        Assert.Equal(expected, result);
    }
}

internal class TestClass
{

}
