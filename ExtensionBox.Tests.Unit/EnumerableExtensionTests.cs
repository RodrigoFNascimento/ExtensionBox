namespace ExtensionBox.Tests.Unit;

public class EnumerableExtensionTests
{
    [Fact]
    public void ElementAtOrDefault_ShouldReturnDefaultElement_WhenCollectionIsEmpty()
    {
        // Arrange
        var collection = Array.Empty<int>().ToList();
        var index = 4;
        var defaultElement = 10;
        var expected = defaultElement;

        // Act
        var result = collection.ElementAtOrDefault(index, defaultElement);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void ElementAtOrDefault_ShouldReturnDefaultElement_WhenIndexIsOutOfRange()
    {
        // Arrange
        var collection = new List<int>() { 1, 2, 3 };
        var index = 4;
        var defaultElement = 10;
        var expected = defaultElement;

        // Act
        var result = collection.ElementAtOrDefault(index, defaultElement);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void ElementAtOrDefault_ShouldThrowException_WhenCollectionIsNull()
    {
        // Arrange
        List<int> collection = null;
        var index = 4;
        var defaultElement = 10;
        var expected = defaultElement;

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => collection.ElementAtOrDefault(index, defaultElement));
    }
    
    [Fact]
    public void FirstOrDefault_ShouldReturnDefaultElement_WhenCollectionIsEmpty()
    {
        // Arrange
        var collection = Array.Empty<int>().ToList();
        var element = 6;
        var defaultElement = 10;
        var expected = defaultElement;

        // Act
        var result = collection.FirstOrDefault(x => x == element, defaultElement);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void FirstOrDefault_ShouldReturnDefaultElement_WhenElementCantBeFound()
    {
        // Arrange
        var collection = new List<int>() { 1, 2, 3 };
        var element = 6;
        var defaultElement = 10;
        var expected = defaultElement;

        // Act
        var result = collection.FirstOrDefault(x => x == element, defaultElement);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void FirstOrDefault_ShouldThrowException_WhenCollectionIsNull()
    {
        // Arrange
        List<int> collection = null;
        var element = 6;
        var defaultElement = 10;
        var expected = defaultElement;

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => collection.FirstOrDefault(x => x == element, defaultElement));
    }
}
