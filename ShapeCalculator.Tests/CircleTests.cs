using ShapeCalculator.Geometry.Primitives;
using ShapeCalculator.Geometry.Shapes;

namespace ShapeCalculator.Tests;

public class CircleTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void CircleConstructorInvalidRadiusThrowsArgumentException(double radius)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Circle(new LineSegment(radius)));
    }

    [Theory]
    [InlineData(1, Math.PI)]
    [InlineData(5, 78.54)]
    [InlineData(10, 314.16)]
    public void CircleAreaValidRadiusReturnsExpected(double radius, double expectedArea)
    {
        // Arrange
        Circle circle = new Circle(new LineSegment(radius));

        // Act
        double area = circle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, area, 2);
    }
}