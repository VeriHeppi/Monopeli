using UnityEngine;

/// <summary>
/// Defines all values of a property in the Monopoly game.
/// </summary>
[CreateAssetMenu(fileName = "New Property", menuName = "Monopeli/Property")]
public class Property : ScriptableObject
{
    /// <summary>
    /// The name of the property.
    /// </summary>
    public string propertyName;

    /// <summary>
    /// The current owner of this property.
    /// </summary>
    public Player owner;

    /// <summary>
    /// The purchase price of the property.
    /// </summary>
    public int propertyPrice;

    /// <summary>
    /// An array containing the various rent prices for the property.
    /// </summary>
    public int[] rentPrices;

    /// <summary>
    /// The mortgage value of the property.
    /// </summary>
    public int mortgageValue;

    /// <summary>
    /// Indicates whether the property is currently mortgaged.
    /// </summary>
    public bool isMortgaged;

    /// <summary>
    /// The price of building one house on the property.
    /// </summary>
    public int housePrice;

    /// <summary>
    /// The price of building a hotel on the property after having 4 houses.
    /// </summary>
    public int hotelPrice;

    /// <summary>
    /// The number of houses currently on the property.
    /// </summary>
    public int numberOfHouses = 0;

    /// <summary>
    /// Indicates whether the property currently has a hotel.
    /// </summary>
    public bool hasHotel = false;

    /// <summary>
    /// The image representing the property card.
    /// </summary>
    public Sprite propertyCardImage;
}
