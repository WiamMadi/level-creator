using UnityEngine;

[CreateAssetMenu(fileName = "Checkpoint", menuName = "Level Creator/Checkpoint", order = 2)]
public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Trigger Event
        Debug.Log("Entered Checkpoint !");
    }
}
