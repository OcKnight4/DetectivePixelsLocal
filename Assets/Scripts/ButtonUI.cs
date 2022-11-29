using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{

    [SerializeField] private string NewGameLevel = "(1) Intro Car Scene";

    public void PlayGameButton()
    {
        SceneManager.LoadScene(NewGameLevel);
    }
}
