using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void InitializeGame()
    {
        // Initialization Logic
        foreach (Player player in players)
        {
            player.money = STARTING_MONEY; // Fore example, if starting with $1500
            player.routePosition = 0;
        }
    }

    public void StartTurn()
    {
        Player currentPlayer = players[currentPlayerIndex];
    }

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

    private bool CheckGameOverCondition()
    {
        // TODO check if any player has gone bankrupt
        return false;
    }

}
