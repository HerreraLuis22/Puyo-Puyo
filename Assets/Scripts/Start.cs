using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start : MonoBehaviour
{
    public void startgame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame() {
        Application.Quit();
    }
}
