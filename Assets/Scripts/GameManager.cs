using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;
	bool SceneLoaded = false;
	public static bool gameWin = false;

	public void EndGame ()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Debug.Log("GAME OVER");

			SceneManager.LoadScene(5, LoadSceneMode.Single);
		}
	}

	void Update ()
	{
        if (SceneManager.GetActiveScene == 1 && SceneLoaded == false)
        {
            // need to load the next scene after a set amoutn of time or after a certain dialog box pops up
        }
    }
}
