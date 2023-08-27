using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerTest : MonoBehaviour
{
    public Player testPlayerA; // The player we are testing
    public Player testPlayerB; // The player we are testing
    public Property testProperty; // The property we are testing

    void Start()
    {
        testPlayerA.money = 1500;
        testPlayerB.money = 1500;
        Debug.Log($"Initial money: {testPlayerA.name} {testPlayerA.money}");
        testPlayerA.PurcaseProperty(testProperty);
        Debug.Log($"Money after purchase: {testPlayerA.money}");
        Debug.Log($"Property owner: {(testProperty.owner != null ? testProperty.owner.playerName : "None")}");

        // Money transfer test
        Debug.Log($"Player initial A money: {testPlayerA.money}");
        Debug.Log($"Player initial B money: {testPlayerB.money}");


        testPlayerB.PayRent(testProperty.rentPrices[0], testProperty.owner);

        Debug.Log($"Player B money after transferring {testProperty.rentPrices[0]}: {testPlayerB.money}");
        Debug.Log($"Player A money after receiving {testProperty.rentPrices[0]}: {testPlayerA.money}");
        
    }

}
