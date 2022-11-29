using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EpicWin : MonoBehaviour
{
    public int sceneBuildIndex;

    // Level move zoned enter, if collider is a player
    // Move game to another scene

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        // Could use other.GetComponent<Player>() to see if teh game object has a player component
        // Tags work too. Maybe some players have different script components?
        if (other.tag == "Player")
        {
            // Player entered, so move level
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
