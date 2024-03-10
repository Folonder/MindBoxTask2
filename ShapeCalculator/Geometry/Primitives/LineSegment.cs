namespace ShapeCalculator.Geometry.Primitives;

/// <summary>
/// Class representing a line segment.
/// </summary>
public record LineSegment
{
    private double _length;

    /// <summary>
    /// The length of the line segment.
    /// </summary>
    public double Length
    {
        get => _length;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("The length of the segment must be a positive number.");
            }

            _length = value;
        }
    }

    /// <summary>
    /// Constructs an instance of a line segment with the specified length.
    /// </summary>
    /// <param name="length">The length of the line segment.</param>
    public LineSegment(double length)
    {
        Length = length;
    }
}