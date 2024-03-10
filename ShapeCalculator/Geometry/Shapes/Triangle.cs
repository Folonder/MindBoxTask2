using static System.Math;
using System.ComponentModel.DataAnnotations;
using ShapeCalculator.Geometry.Primitives;

namespace ShapeCalculator.Geometry.Shapes;

/// <summary>
/// Class representing a triangle.
/// </summary>
public class Triangle : IShape
{
    /// <summary>
    /// The LineSegment of the first side of the triangle.
    /// </summary>
    public LineSegment Side1 { get; private set; }

    /// <summary>
    /// The LineSegment of the second side of the triangle.
    /// </summary>
    public LineSegment Side2 { get; private set; }

    /// <summary>
    /// The LineSegment of the third side of the triangle.
    /// </summary>
    public LineSegment Side3 { get; private set; }

    /// <summary>
    /// Array of LineSegments - sides.
    /// </summary>
    public LineSegment[] Sides => new[] { Side1, Side2, Side3 };

    /// <summary>
    /// Constructs an instance of a triangle with the specified sides.
    /// </summary>
    /// <param name="side1">The LineSegment of the first side.</param>
    /// <param name="side2">The LineSegment of the second side.</param>
    /// <param name="side3">The LineSegment of the third side.</param>
    public Triangle(LineSegment side1, LineSegment side2, LineSegment side3)
    {
        if (!IsTriangleValid(side1, side2, side3))
        {
            throw new ValidationException("A triangle with such sides cannot exist." +
                                          " The sum of lengths of two sides must be greater than the third side.");
        }
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }
    
    /// <summary>
    /// Constructs an instance of a triangle with the specified sides.
    /// </summary>
    /// <param name="sides">Array of LineSegments - sides.</param>
    public Triangle(LineSegment[] sides)
    {
        if (sides.Length != 3)
        {
            throw new ArgumentException("The array must contain 3 sides");
        }
        if (!IsTriangleValid(sides[0], sides[1], sides[2]))
        {
            throw new ValidationException("A triangle with such sides cannot exist." +
                                          " The sum of lengths of two sides must be greater than the third side.");
        }
        Side1 = sides[0];
        Side2 = sides[1];
        Side3 = sides[2];
    }

    /// <summary>
    /// Calculates the area of the triangle using Heron's formula.
    /// </summary>
    /// <returns>The area value of the triangle.</returns>
    public double CalculateArea()
    {
        var semiperimeter = (Side1.Length + Side2.Length + Side3.Length) / 2;
        return Sqrt(semiperimeter * (semiperimeter - Side1.Length) * (semiperimeter - Side2.Length) *
                    (semiperimeter - Side3.Length));
    }

    /// <summary>
    /// Checks if triangle is right.
    /// </summary>
    /// <returns>True if triangle is right, otherwise false</returns>
    public bool IsRightTriangle()
    {
        const double tolerance = 0.01;
        return Abs(Side1.Length - Sqrt(Pow(Side2.Length, 2) + Pow(Side3.Length, 2))) < tolerance ||
               Abs(Side2.Length - Sqrt(Pow(Side1.Length, 2) + Pow(Side3.Length, 2))) < tolerance ||
               Abs(Side3.Length - Sqrt(Pow(Side1.Length, 2) + Pow(Side2.Length, 2))) < tolerance;
    }

    /// <summary>
    /// Checks if triangle can exist.
    /// </summary>
    /// <param name="side1">The LineSegment of the first side.</param>
    /// <param name="side2">The LineSegment of the second side.</param>
    /// <param name="side3">The LineSegment of the third side.</param>
    /// <returns>True if triangle can exist, otherwise false</returns>
    private static bool IsTriangleValid(LineSegment side1, LineSegment side2, LineSegment side3)
    {
        return side1.Length + side2.Length > side3.Length &&
               side2.Length + side2.Length > side1.Length &&
               side1.Length + side3.Length > side2.Length;
    }
}