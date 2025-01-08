using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class TeleportableSection : MonoBehaviour
{
    public TeleportableSection upNeighbor;
    public TeleportableSection downNeighbor;
    public TeleportableSection leftNeighbor;
    public TeleportableSection rightNeighbor;
    public  SceneAsset enterLevel;
   
   
    public void TeleportPlayer(Transform player, Vector3 direction)
    {
       
        TeleportableSection targetSection = null;

        if (direction == Vector3.up && upNeighbor != null)
        {
            targetSection = upNeighbor;
        }
        else if (direction == Vector3.down && downNeighbor != null)
        {
            targetSection = downNeighbor;
        }
        else if (direction == Vector3.left && leftNeighbor != null)
        {
            targetSection = leftNeighbor;
        }
        else if (direction == Vector3.right && rightNeighbor != null)
        {
            targetSection = rightNeighbor;
        }

       
        if (targetSection != null)
        {
            player.position = targetSection.transform.position;
            Debug.Log($"Teleported to {targetSection.name}");
        }
        else
        {
            Debug.Log("No neighbor in that direction.");
        }
    }

}
