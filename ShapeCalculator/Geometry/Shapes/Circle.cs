using static System.Math;
using ShapeCalculator.Geometry.Primitives;

namespace ShapeCalculator.Geometry.Shapes;

/// <summary>
/// Class representing a circle.
/// </summary>
public class Circle : IShape
{
    /// <summary>
    /// The radius of the circle.
    /// </summary>
    public LineSegment Radius { get; private set; }

    /// <summary>
    /// Constructs an instance of a circle with the specified radius.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    public Circle(LineSegment radius)
    {
        Radius = radius;
    }

    /// <summary>
    /// Calculates the area of the circle.
    /// </summary>
    /// <returns>The area value of the circle.</returns>
    public double CalculateArea()
    {
        return PI * Pow(Radius.Length, 2);
    }
}