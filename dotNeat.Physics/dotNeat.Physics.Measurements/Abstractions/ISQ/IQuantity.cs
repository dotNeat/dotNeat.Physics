namespace dotNeat.Physics.Measurements.Abstractions.ISQ
{
    using SI;
#nullable enable

    /// <summary>
    /// Interface IQuantity
    /// models the concept of Quantity from the International System of Quantities (ISQ).
    /// </summary>
    public interface IQuantity
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        QuantityID ID { get; }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }
        /// <summary>
        /// Gets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        string? Symbol { get; }
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; }
        /// <summary>
        /// Gets the dimension.
        /// </summary>
        /// <value>The dimension.</value>
        string Dimension { get; }
        /// <summary>
        /// Gets the comment.
        /// </summary>
        /// <value>The comment.</value>
        string? Comment { get; }
        /// <summary>
        /// Gets the si unit.
        /// </summary>
        /// <value>The si unit.</value>
        IUnit SIUnit { get; }
        /// <summary>
        /// Gets a value indicating whether this instance is base quantity.
        /// </summary>
        /// <value><c>true</c> if this instance is base quantity; otherwise, <c>false</c>.</value>
        bool IsBaseQuantity { get; }
    }
}
