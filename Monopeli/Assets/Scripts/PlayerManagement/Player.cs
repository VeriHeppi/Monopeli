using System;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;



public class Player : MonoBehaviour
{
    public int GO_BONUS = 200;

    public string playerName; // Name of the player
    public int money; // The players current amount of money.
    public bool isBankrupt = false; // Is the player bankrupt?
    public int position; // The players current position on the board.
    public bool inJail = false; // Is the player in jail
    public int jailTurns; // How many turns the player has been in jail
    public List<Property> ownedProperties; // List of properties the player owns
    public GameObject token; // Token or game piece of the player

    // TODO add a array (2) of possible get out of jail cards that the player might posess.

    public void Move(int spaces)
    {
        position += spaces;

        if (position >= 40)
        {
            position -= 40;
            PassGo();
        }
    }

    private void PassGo()
    {
        money += GO_BONUS;
    }

    public void PayRent(int amount, Player owner)
    {
        if (money - amount < 0)
        {
            // TODO player is bankrupt
            Debug.Log("Player is bankrupt {playerName}");
        }
        else
        {
            money -= amount;
            owner.ReceiveMoney(amount);
        }
    }

    public void ReceiveMoney(int amount)
    {
        money += amount;
    }

    public void PurcaseProperty(Property property)
    {
        if (money >= property.propertyPrice)
        {
            money -= property.propertyPrice;
            property.owner = this;
            ownedProperties.Add(property);
        }
        else
        {
            Debug.LogError("Player does not have enough money to purchase property {playerName} {property.propertyName}");
        }
    }

}

