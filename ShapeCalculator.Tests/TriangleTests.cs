using System.ComponentModel.DataAnnotations;
using ShapeCalculator.Geometry.Shapes;
using ShapeCalculator.Geometry.Primitives;

namespace ShapeCalculator.Tests;

public class TriangleTests
{
    [Theory]
    [InlineData(0, 1, 2)]
    [InlineData(1, 0, 2)]
    [InlineData(1, 2, 0)]
    [InlineData(-1, 2, 3)]
    public void TriangleConstructorInvalidSidesThrowsArgumentException(double side1, double side2, double side3)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Triangle(new LineSegment(side1), new LineSegment(side2), new LineSegment(side3)));
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(3, 4, 8)]
    public void TriangleConstructorImpossibleTriangleThrowsArgumentException(double side1, double side2, double side3)
    {
        // Act & Assert
        Assert.Throws<ValidationException>(() =>
            new Triangle(new LineSegment(side1), new LineSegment(side2), new LineSegment(side3)));
    }

    [Theory]
    [InlineData(3, 4, 5, 6)]
    [InlineData(6, 8, 10, 24)]
    [InlineData(5, 5, 5, 10.83)]
    public void TriangleAreaValidSidesReturnsExpected(double side1, double side2, double side3, double expectedArea)
    {
        // Arrange
        Triangle triangle = new Triangle(new LineSegment(side1), new LineSegment(side2), new LineSegment(side3));

        // Act
        double area = triangle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, area, 2);
    }

    [Fact]
    public void TriangleConstructorWithArrayOfSides()
    {
        //Arrange & Act
        Triangle triangle = new Triangle(new[] { new LineSegment(6), new LineSegment(8), new LineSegment(10) });
        
        //Assert
        Assert.Equal(6, triangle.Side1.Length);
        Assert.Equal(8, triangle.Side2.Length);
        Assert.Equal(10, triangle.Side3.Length);
    }
    
    [Fact]
    public void SidesPropertyUnmutable()
    {
        //Arrange
        var preparedSides = new[] { new LineSegment(6), new LineSegment(8), new LineSegment(10) };
        
        //Act
        Triangle triangle = new Triangle(preparedSides);
        var sides = triangle.Sides;
        sides[0] = new LineSegment(8);
        
        //Assert
        Assert.Equal(6, triangle.Side1.Length);
        Assert.Equal(8, triangle.Side2.Length);
        Assert.Equal(10, triangle.Side3.Length);
        Assert.NotEqual(triangle.Sides[0].Length, sides[0].Length);
    }
}