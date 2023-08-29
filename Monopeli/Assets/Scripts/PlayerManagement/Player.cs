using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;


/// <summary>
/// This class represents a player in the game. 
/// It contains all the information about the player,
/// and also the logic for the player's turn and other player actions.
/// </summary>
public class Player : MonoBehaviour
{

    [Header("Player Settings")]
    // Start bonus (you can edit this in the editor directly.)
    [SerializeField, Tooltip("Starting money for the player.")]
    private int GO_BONUS = 2000; 

    public Route currentRoute; // Route of the game board-

    public string playerName; // Name of the player
    
    public int money; // The players current amount of money.
    public int routePosition; // The players current position on the board.
    public int stepsToMove; // The number of steps the player has to move.
    public int jailTurns; // How many turns the player has been in jail

    public bool isMoving; // Whether the player is moving or not.
    public bool isBankrupt = false; // Is the player bankrupt?
    public bool inJail = false; // Is the player in jail

    public List<Property> ownedProperties; // List of properties the player owns
    public GameObject token; // Token or game piece of the player

    // TODO add a array (2) of possible get out of jail cards that the player might posess.

    private void Update()
    {
        // FOR TESTING when space key is pressed roll the dice and move the player accordingly.
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            stepsToMove = rollTheDice();

            StartCoroutine(Move());
        }
    }

    /// <summary>
    /// Simple roll mechanic to be improved. Just for testing purposes. Rolls a random number between 2 and 13 min 2 max 12.
    /// </summary>
    /// <returns> returns an int value that represents the steps that the player has to move. </returns>
    public int rollTheDice()
    {
        int roll = UnityEngine.Random.Range(2, 13);
        Debug.Log($"Dice rolled a number {roll}");
        return roll;
    }

    /// <summary>
    /// This function is used to move the players token around the map and check when they pass go.
    /// </summary>
    /// <returns></returns>
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        // Move player around the board.

        while (stepsToMove > 0)
        {
            routePosition++;
            routePosition %= currentRoute.childNodeList.Count;

            if (routePosition == 0)
            {
                PassGo();
            }

            // This finds the next position on the board.
            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
            while (MoveToNextNode(nextPos)){yield return null;}

            yield return new WaitForSeconds(0.1f);
            stepsToMove--;
        }

        isMoving = false;
    }

    /// <summary>
    /// Moves the player to the specified position on the board.
    /// </summary>
    /// <param name="targetPos">Vector3 of the location where the player should move</param>
    /// <returns>True when target position not reached; False when the position has been reached</returns>
    bool MoveToNextNode(Vector3 targetPos)
    {
        
        return targetPos != (transform.position = Vector3.MoveTowards(transform.position, targetPos, 2f * Time.deltaTime));
    }
    
    /// <summary>
    /// This function adds the GO_BONUS to the players money when they pass go.
    /// </summary>
    private void PassGo()
    {
        money += GO_BONUS;
    }

    /// <summary>
    /// This function is used to pay rent on a property. AKA move money to other player.
    /// </summary>
    /// <param name="amount"> Amount of money that needs to be transferred.</param>
    /// <param name="owner"> Target of money transferral</param>
    public void PayRent(int amount, Player owner)
    {
        if (money - amount < 0)
        {
            // TODO player is bankrupt
            Debug.Log($"Player {playerName} is bankrupt ");
        }
        else
        {
            money -= amount;
            owner.ReceiveMoney(amount);
        }
    }

    /// <summary>
    /// This function is used to update the money of the player.
    /// </summary>
    /// <param name="amount"> Amount of money that needs to be added to the players money.</param>
    public void ReceiveMoney(int amount)
    {
        money += amount;
    }

    /// <summary>
    /// This function is used to buy a property. Deducts money from the player account and 
    /// adds the property to the players owned property list.
    /// </summary>
    /// <param name="property"> Property to be bought. </param>
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
            Debug.LogError($"Player does not have enough money to purchase property ({playerName}) ({property.propertyName})");
        }
    }

}
