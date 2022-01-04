using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public enum Gs
    {
        GameInitializing, Creating, Falling, Orientation, Connection, GameScore, GamePause
    }
    public GameObject Canvas;
    public GameObject PuyoSpawner;
    public float fs;
    public GameObject Pm;

    public static Gs gs;
    public static GameObject ObPs;
    public static GameObject ObPm;
    public static Puyo[,] puyo = new Puyo[6, 13];
    public static Puyo ctlMp;
    public static Puyo ctlSp;
    public static Queue<Puyo> inventory;
    public static int PD = 2;
    public static int bottomPosition = 186;
    public static int leftPosition =200;
    public static int rightPosition = 206;
    public Text score;
    public static int Score = 0;
    private bool falling = true;
    void Start()
    {
        ObPs = PuyoSpawner;
        inventory = new Queue<Puyo>();
        gs = Gs.GameInitializing;
        ObPm = Pm;
        Canvas.SetActive(true);
    }
    private void Update()
    {
        if (gs == Gs.GameInitializing)
        {
            inventory.Enqueue(Spawner.PuyoCreate(340, 190));
            inventory.Enqueue(Spawner.PuyoCreate(340, 188));
            inventory.Enqueue(Spawner.PuyoCreate(340, 186));
            inventory.Enqueue(Spawner.PuyoCreate(340, 184));
            gs = Gs.Creating;
        }
        if (gs == Gs.Creating)
        {
            
            PuyoMaster.puyoCreate();
            gs = Gs.Falling;
        }

        if (gs == Gs.Falling)
        {
            if (falling)
            {
                StartCoroutine("Puyosfalling");
                falling = false;
            }
        }

        if (gs == Gs.Orientation)
        {
            PuyoMaster.puyoange();
            gs = Gs.Connection;
        }

        if (gs == Gs.Connection)
        {
            PuyoMaster.resetStatusAndPuyoList();
            PuyoMaster.SamePuyo();
            gs = Gs.GameScore;
        }

        if (gs == Gs.GameScore)
        {
            
            if (PuyoMaster.readyToEliminate())
            {
                StartCoroutine("WaitingDelete");
                gs = Gs.GamePause;
            }
            else
            {
                gs = Gs.Creating;
            }
        }
    }

    IEnumerator Puyosfalling()
    {
        yield return new WaitForSeconds(fs);
        if (PuyoMaster.Bottom((int)ctlMp.getPosition().x, (int)ctlMp.getPosition().y) || PuyoMaster.Bottom((int)ctlSp.getPosition().x, (int)ctlSp.getPosition().y))
        {
           if (PuyoMaster.GameOver())
            {
                GameOver.textscore = Score;
                SceneManager.LoadScene(2);
            }
            else
            {
                int mX = (int)ctlMp.getPosition().x;
                int mY = (int)ctlMp.getPosition().y;
                int sX = (int)ctlSp.getPosition().x;
                int sY = (int)ctlSp.getPosition().y;
                puyo[mX, mY] = ctlMp;
                puyo[sX, sY] = ctlSp;

                gs = Gs.Orientation;
            }
        }
        else
        {
            PuyoMaster.puyoDown(true);
        }
        falling = true;
    }

    IEnumerator WaitingDelete()
    {
        yield return new WaitForSeconds(0.5f);
        PuyoMaster.eliminatePuyo();
        gs = Gs.Orientation;
        Score = Score + 1;
        score.text = Score.ToString();
    }
}

    