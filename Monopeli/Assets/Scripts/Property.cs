using UnityEngine;

[CreateAssetMenu(fileName = "New Property", menuName = "Monopeli/Property")]
public class Property : ScriptableObject
{
    public string propertyName; // Name of the property
    public Player owner; // Current owner of this property.
    public int propertyPrice; // Price of the property
    public int[] rentPrices; // Rent prices of the property
    public int mortgageValue; // Mortgage value of the property
    public bool isMortgaged; // Is the property mortgaged
    public int housePrice; // Price of one house
    public int hotelPrice; // Price of a hotel after 4 houses
    public int numberOfHouses = 0; // Number of houses on the property
    public bool hasHotel = false; // Does the property have a hotel
    public Sprite propertyCardImage; // Image of the property card
}
