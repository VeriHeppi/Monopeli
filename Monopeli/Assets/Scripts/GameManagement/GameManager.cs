using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The game manager manages all aspects of gameplay for example player turns, player movement, player actions, etc.
/// </summary>
public class GameManager : MonoBehaviour
{

    public int STARTING_MONEY = 1500;

    public Player[] players;
    public int currentPlayerIndex = 0;
    public bool gameIsOver = false;
    // public PropertyManager propertyManager;
    // public BoardManager boardManager;
    // public Dicec dice;

    void Start()
    {
        InitializeGame();
    }

    /// <summary>
    /// Initializes the game by setting up the board, players, etc.
    /// </summary>
    private void InitializeGame()
    {
        // Initialization Logic
        foreach (Player player in players)
        {
            player.money = STARTING_MONEY; // Fore example, if starting with $1500
            player.routePosition = 0;
        }
    }

    /// <summary>
    /// Starts a players turn.
    /// </summary>
    public void StartTurn()
    {
        Player currentPlayer = players[currentPlayerIndex];
    }

    /// <summary>
    /// Ends current players turn.
    /// </summary>
    public void EndTurn()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length; // Cycle through the players

        if (CheckGameOverCondition())
        {
            gameIsOver = true;
        }
        else
        {
            
        }
    }

    /// <summary>
    /// Check's if game over conditions are met. FE only 1 player remains not bankrupt.
    /// </summary>
    /// <returns>False if the game is not over and true if the game is over.</returns>
    private bool CheckGameOverCondition()
    {
        // TODO check if any player has gone bankrupt
        return false;
    }

}
