using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines a route on the game board using a list of nodes (Transform objects).
/// Also provides functionality to visualize the route within the Unity Editor using Gizmos.
/// </summary>
public class Route : MonoBehaviour
{
    /// <summary>
    /// An array to hold all child Transforms.
    /// </summary>
    Transform[] childObjects;

    /// <summary>
    /// A List to hold nodes that form the route.
    /// </summary>
    public List<Transform> childNodeList = new List<Transform>();

    /// <summary>
    /// Draws Gizmos in the Unity Editor for visualizing the route.
    /// This is automatically called by Unity during scene editing.
    /// </summary>
    void OnDrawGizmos()
    {

        // Set the color for the Gizmos
        Gizmos.color = Color.green;

        // Fill the node list with child Transform objects
        FillNodes();

        // Draw lines between adjacent nodes and wireframe spheres at node positions
        for (int i = 0; i < childNodeList.Count; i++)
        {
            Vector3 currentPos = childNodeList[i].position;
            if (i > 0)
            {
                Vector3 prevPos = childNodeList[i - 1].position;
                Gizmos.DrawLine(prevPos, currentPos);
                Gizmos.DrawWireSphere(currentPos, 0.3f);
            }
        }
    }

    /// <summary>
    /// Fills the childNodeList with all child Transforms of this GameObject, excluding itself.
    /// </summary>
    void FillNodes()
    {
        // Clear any existing nodes from the list
        childNodeList.Clear();
        
        // Get all child Transforms
        childObjects = GetComponentsInChildren<Transform>();

        // Populate the node list
        foreach (Transform child in childObjects)
        {
            if (child != this.transform)
            {
                childNodeList.Add(child);
            }
        }
    }

}