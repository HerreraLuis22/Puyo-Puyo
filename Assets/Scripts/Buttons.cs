using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public GameObject Game;
    public static GameObject game;
    

    private void Start()
    {
        game = Game;
    }
    public void OnPause()
    {
        Time.timeScale = 0;
        game.SetActive(true);
    }
    public static void OnResume()
    {
        Time.timeScale = 1f;
        game.SetActive(true);
    }
    public static void OnRestart()
    {
        PuyoController.Puyo_Blue_Direct.Clear();
        PuyoController.Puyo_Green_Direct.Clear();
        PuyoController.Puyo_Red_Direct.Clear();
        PuyoController.Puyo_Yellow_Direct.Clear();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
