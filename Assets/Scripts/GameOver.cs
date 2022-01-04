using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public static int textscore;
    public  Text TextScore;

    
    void Update()
    {
        TextScore.text = "Your Score: "+textscore.ToString();
    }
    
    public void OnRestart() {
        SceneManager.LoadScene(0);
        PuyoController.Puyo_Blue_Direct.Clear();
        PuyoController.Puyo_Green_Direct.Clear();
        PuyoController.Puyo_Red_Direct.Clear();
        PuyoController.Puyo_Yellow_Direct.Clear();
        
    }
}
