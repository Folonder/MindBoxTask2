namespace ShapeCalculator.Geometry.Shapes;

/// <summary>
/// Interface for shapes.
/// </summary>
public interface IShape
{
    /// <summary>
    /// Method to calculate the area of the shape.
    /// </summary>
    /// <returns>The area value.</returns>
    double CalculateArea();
}