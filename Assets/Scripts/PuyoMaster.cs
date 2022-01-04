using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class PuyoMaster : MonoBehaviour
{
    public static void puyoCreate() {
        GameController.ctlMp = GameController.inventory.Dequeue();
        GameController.ctlSp = GameController.inventory.Dequeue();
        GameController.inventory.ElementAt(1).getPuyo().transform.localPosition = new Vector3(340, 190, 0);
        GameController.inventory.ElementAt(0).getPuyo().transform.localPosition = new Vector3(340, 188, 0);
        GameController.inventory.Enqueue(Spawner.PuyoCreate(340, 186));
        GameController.inventory.Enqueue(Spawner.PuyoCreate(340, 184));
        GameController.ctlMp.getPuyo().transform.localPosition = new Vector3(350, 200, 0);
        GameController.ctlSp.getPuyo().transform.localPosition = new Vector3(350, 202, 0);
        GameController.ctlMp.setPosition(new Vector2(3, 12));
        GameController.ctlSp.setPosition(new Vector2(3, 13));
        GameController.PD = 0;
        GameController.ObPm.transform.localPosition = new Vector3(350, 200, 0);
        GameController.ObPm.transform.SetAsLastSibling();
        //PuyoController.setShinyPuyo(GameController.ctlMp.getColor());
    }
    public static void puyoDown(bool moveShinyPuyo) {
        GameController.ctlMp.getPuyo().transform.localPosition = new Vector3(GameController.ctlMp.getPuyo().transform.localPosition.x, GameController.ctlMp.getPuyo().transform.localPosition.y - 2,GameController.ctlMp.getPuyo().transform.localPosition.z);
        GameController.ctlSp.getPuyo().transform.localPosition = new Vector3(GameController.ctlSp.getPuyo().transform.localPosition.x, GameController.ctlSp.getPuyo().transform.localPosition.y - 2, GameController.ctlSp.getPuyo().transform.localPosition.z);
        GameController.ctlMp.setPosition(new Vector2(GameController.ctlMp.getPosition().x, GameController.ctlMp.getPosition().y - 1));
        GameController.ctlSp.setPosition(new Vector2(GameController.ctlSp.getPosition().x, GameController.ctlSp.getPosition().y - 1));
        if (moveShinyPuyo)
        {
            GameController.ObPm.transform.localPosition = GameController.ctlMp.getPuyo().transform.localPosition;
        }
    }
    public static void puyoleft(bool moveShinyPuyo) {
        GameController.ctlMp.getPuyo().transform.localPosition = new Vector3(GameController.ctlMp.getPuyo().transform.localPosition.x - 2, GameController.ctlMp.getPuyo().transform.localPosition.y, GameController.ctlMp.getPuyo().transform.localPosition.z);
        GameController.ctlSp.getPuyo().transform.localPosition = new Vector3(GameController.ctlSp.getPuyo().transform.localPosition.x -2, GameController.ctlSp.getPuyo().transform.localPosition.y, GameController.ctlSp.getPuyo().transform.localPosition.z);
        GameController.ctlMp.setPosition(new Vector2(GameController.ctlMp.getPosition().x - 1, GameController.ctlMp.getPosition().y));
        GameController.ctlSp.setPosition(new Vector2(GameController.ctlSp.getPosition().x - 1, GameController.ctlSp.getPosition().y));
        if (moveShinyPuyo)
        {
            GameController.ObPm.transform.localPosition = GameController.ctlMp.getPuyo().transform.localPosition;
        }
    }
    public static void puyoright(bool moveShinyPuyo) {
        GameController.ctlMp.getPuyo().transform.localPosition = new Vector3(GameController.ctlMp.getPuyo().transform.localPosition.x + 2, GameController.ctlMp.getPuyo().transform.localPosition.y, GameController.ctlMp.getPuyo().transform.localPosition.z);
        GameController.ctlSp.getPuyo().transform.localPosition = new Vector3(GameController.ctlSp.getPuyo().transform.localPosition.x + 2, GameController.ctlSp.getPuyo().transform.localPosition.y, GameController.ctlSp.getPuyo().transform.localPosition.z);
        GameController.ctlMp.setPosition(new Vector2(GameController.ctlMp.getPosition().x + 1, GameController.ctlMp.getPosition().y));
        GameController.ctlSp.setPosition(new Vector2(GameController.ctlSp.getPosition().x + 1, GameController.ctlSp.getPosition().y));
        if (moveShinyPuyo)
        {
            GameController.ObPm.transform.localPosition = GameController.ctlMp.getPuyo().transform.localPosition;
        }
    }
    public static void puyoCounterclokwise() {
        int x = (int)GameController.ctlMp.getPosition().x;
        int y = (int)GameController.ctlSp.getPosition().y;
        if (GameController.PD==0)
        {
            if ((x==6 || GameController.puyo[x-1,y] != null)&& (x==0|| GameController.puyo[x+1,y]==null))
            {
                if (x==6 || GameController.puyo[x-1,y] != null)
                {
                    puyoright(true);
                }
                GameController.PD = 3;
                OriantarioSubLeft();
            }
        }
        else if (GameController.PD == 1)
        {
            GameController.PD = 0;
            OrientationSubTop();
        }
        else if (GameController.PD == 2)
        {
            if ((x == 0 || GameController.puyo[x + 1, y] == null) && (x == 6 || GameController.puyo[x - 1, y] == null))
            {
                if (x == 0 || GameController.puyo[x + 1, y] != null)
                {
                    puyoleft(true);
                }
                GameController.PD = 1;
                OrientationSubRight();
            }
        }
        else if (GameController.PD == 3)
        {
            if (y != 0)
            {
                GameController.PD = 2;
                OriantationSubDown();
            }
        }
    }
    public static void puyoClockwise()
    {
        int x = (int)GameController.ctlMp.getPosition().x;
        int y = (int)GameController.ctlMp.getPosition().y;
        if (GameController.PD == 0)
        {
            if ((x == 6 || GameController.puyo[x + 1, y] == null) && (x == 0 || GameController.puyo[x - 1, y] == null))
            {
                if (x == 6 || GameController.puyo[x + 1, y] != null)
                {
                    puyoleft(true);
                }
                GameController.PD = 1;
                OrientationSubRight();
            }
        }
        else if (GameController.PD == 1)
        {
            if (y != 0)
            {
                GameController.PD = 2;
                OriantationSubDown();
            }
        }
        else if (GameController.PD == 2)
        {
            if ((x == 0 || GameController.puyo[x - 1, y] == null) && (x ==  6 || GameController.puyo[x + 1, y] == null))
            {
                if (x == 0 || GameController.puyo[x - 1, y] != null)
                {
                    puyoright(true);
                }
                GameController.PD = 3;
                OriantarioSubLeft();
            }
        }
        else if (GameController.PD == 3)
        {
            GameController.PD = 0;
            OrientationSubTop();
        }

    }

    public static void puyoange()
    {
        GameController.ObPm.transform.localPosition = new Vector3(0, -7, 0);
        for (int y = 1; y < 13; y++)
        {
            for (int x = 0; x < 6; x++)
            {
                if (GameController.puyo[x, y] != null)
                {
                    if (GameController.puyo[x, y - 1] == null)
                    {
                        GameObject tempPuyo = GameController.puyo[x, y].getPuyo();
                        tempPuyo.transform.localPosition = new Vector3(tempPuyo.transform.localPosition.x, tempPuyo.transform.localPosition.y -2, tempPuyo.transform.localPosition.z);
                        GameController.puyo[x, y - 1] = GameController.puyo[x, y];
                        GameController.puyo[x, y] = null;
                        y = 1;
                        x = -1;
                    }
                }
            }
        }
    }

    public static bool Bottom(int x, int y)
    {
        if (y == 3)
        {
            return true;
        }
        if (GameController.puyo[x, y - 2] != null)
        {
            return true;
        }
        return false;
    }

    public static bool Walls(int type, int x, int y)
    {
        if (y >= 15)
            return false;

        if (x <= 0 && type == 0)
            return true;

        if (x >= 5 && type == 1)
            return true;

        if (type == 0)
        {
            if (GameController.puyo[x - 1, y] != null)
            {
                return true;
            }
        }
        else
        {
            if (GameController.puyo[x + 1, y] != null)
            {
                return true;
            }
        }
        return false;
    }

    public static void OriantarioSubLeft()
    {
        GameController.ctlSp.getPuyo().transform.localPosition = new Vector3(GameController.ctlMp.getPuyo().transform.localPosition.x - 2, GameController.ctlMp.getPuyo().transform.localPosition.y, GameController.ctlMp.getPuyo().transform.localPosition.z);
        GameController.ctlSp.setPosition(new Vector2(GameController.ctlMp.getPosition().x - 1, GameController.ctlMp.getPosition().y));
    }

    public static void OrientationSubRight()
    {
        GameController.ctlSp.getPuyo().transform.localPosition = new Vector3(GameController.ctlMp.getPuyo().transform.localPosition.x + 2, GameController.ctlMp.getPuyo().transform.localPosition.y, GameController.ctlMp.getPuyo().transform.localPosition.z);
        GameController.ctlSp.setPosition(new Vector2(GameController.ctlMp.getPosition().x + 1, GameController.ctlMp.getPosition().y));
    }
    public static void OrientationSubTop()
    {
        GameController.ctlSp.getPuyo().transform.localPosition = new Vector3(GameController.ctlMp.getPuyo().transform.localPosition.x, GameController.ctlMp.getPuyo().transform.localPosition.y + 2, GameController.ctlMp.getPuyo().transform.localPosition.z);
        GameController.ctlSp.setPosition(new Vector2(GameController.ctlMp.getPosition().x, GameController.ctlMp.getPosition().y + 1));
    }

    public static void OriantationSubDown()
    {
        GameController.ctlSp.getPuyo().transform.localPosition = new Vector3(GameController.ctlMp.getPuyo().transform.localPosition.x, GameController.ctlMp.getPuyo().transform.localPosition.y - 2, GameController.ctlMp.getPuyo().transform.localPosition.z);
        GameController.ctlSp.setPosition(new Vector2(GameController.ctlMp.getPosition().x, GameController.ctlMp.getPosition().y - 1));
    }

    

    public static void SamePuyo()
    {
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 5; x++)
            {
                if (GameController.puyo[x, y] != null)
                {
                    emptyRow = false;
                    if (GameController.puyo[x + 1, y] != null && GameController.puyo[x, y].getColor() == GameController.puyo[x + 1, y].getColor())
                    {
                        if (PuyoController.LEFT == GameController.puyo[x, y].getStatus())
                        {
                            GameController.puyo[x, y].setStatus(PuyoController.RIGHT_LEFT);
                        }
                        else
                        {
                            GameController.puyo[x, y].setStatus(PuyoController.RIGHT);
                            GameController.puyo[x + 1, y].setStatus(PuyoController.LEFT);
                        }
                        setPuyoALinkList(GameController.puyo[x, y], GameController.puyo[x + 1, y]);
                    }
                }
            }
            if (emptyRow)
                break;
        }
        
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameController.puyo[x, y] != null)
                {
                    emptyRow = false;
                    if (GameController.puyo[x, y + 1] != null && GameController.puyo[x, y].getColor() == GameController.puyo[x, y + 1].getColor())
                    {
                        switch (GameController.puyo[x, y + 1].getStatus())
                        {
                            case PuyoController.NORMAL:
                                GameController.puyo[x, y + 1].setStatus(PuyoController.DOWN);
                                break;
                            case PuyoController.TOP:
                                GameController.puyo[x, y + 1].setStatus(PuyoController.TOP_DOWN);
                                break;
                            case PuyoController.LEFT:
                                GameController.puyo[x, y + 1].setStatus(PuyoController.LEFT_DOWN);
                                break;
                            case PuyoController.RIGHT:
                                GameController.puyo[x, y + 1].setStatus(PuyoController.RIGHT_DOWN);
                                break;
                            case PuyoController.RIGHT_LEFT:
                                GameController.puyo[x, y + 1].setStatus(PuyoController.RIGHT_LEFT_DOWN);
                                break;
                            case PuyoController.TOP_LEFT:
                                GameController.puyo[x, y + 1].setStatus(PuyoController.TOP_LEFT_DOWN);
                                break;
                            case PuyoController.TOP_RIGHT:
                                GameController.puyo[x, y + 1].setStatus(PuyoController.TOP_RIGHT_DOWN);
                                break;
                            case PuyoController.TOP_RIGHT_LEFT:
                                GameController.puyo[x, y + 1].setStatus(PuyoController.TOP_RIGHT_LEFT_DOWN);
                                break;
                        }
                        switch (GameController.puyo[x, y].getStatus())
                        {
                            case PuyoController.NORMAL:
                                GameController.puyo[x, y].setStatus(PuyoController.TOP);
                                break;
                            case PuyoController.LEFT:
                                GameController.puyo[x, y].setStatus(PuyoController.TOP_LEFT);
                                break;
                            case PuyoController.RIGHT:
                                GameController.puyo[x, y].setStatus(PuyoController.TOP_RIGHT);
                                break;
                            case PuyoController.RIGHT_LEFT:
                                GameController.puyo[x, y].setStatus(PuyoController.TOP_RIGHT_LEFT);
                                break;
                            case PuyoController.DOWN:
                                GameController.puyo[x, y].setStatus(PuyoController.TOP_DOWN);
                                break;
                            case PuyoController.LEFT_DOWN:
                                GameController.puyo[x, y].setStatus(PuyoController.TOP_LEFT_DOWN);
                                break;
                            case PuyoController.RIGHT_DOWN:
                                GameController.puyo[x, y].setStatus(PuyoController.TOP_RIGHT_DOWN);
                                break;
                            case PuyoController.RIGHT_LEFT_DOWN:
                                GameController.puyo[x, y].setStatus(PuyoController.TOP_RIGHT_LEFT_DOWN);
                                break;
                        }

                        setPuyoALinkList(GameController.puyo[x, y], GameController.puyo[x, y + 1]);
                    }
                }
            }
            if (emptyRow)
                break;
        }
        UpdateSprite();
    }

    public static void UpdateSprite()
    {
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameController.puyo[x, y] != null)
                {
                    emptyRow = false;
                    PuyoController.PuyoSprite(GameController.puyo[x, y], GameController.puyo[x, y].getStatus());
                }
            }
            if (emptyRow)
            {
                break;
            }
        }
    }

    public static void setPuyoALinkList(Puyo MainPuyo, Puyo SubPuyo)
    {
        List<Puyo> puyoAList = MainPuyo.getPuyoList();
        if (!puyoAList.Contains(SubPuyo))
        {
            puyoAList.Add(SubPuyo);
        }
        List<Puyo> puyoBList = SubPuyo.getPuyoList();
        if (!puyoBList.Contains(MainPuyo))
        {
            puyoBList.Add(MainPuyo);
        }
        List<Puyo> puyoList = puyoAList.Union(puyoBList).ToList<Puyo>();

        for (int i = 0; i < puyoAList.Count; i++)
        {
            puyoAList[i].setPuyoList(puyoList);
        }
        for (int i = 0; i < puyoBList.Count; i++)
        {
            puyoBList[i].setPuyoList(puyoList);
        }
    }

    public static void resetStatusAndPuyoList()
    {
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameController.puyo[x, y] != null)
                {
                    emptyRow = false;
                    GameController.puyo[x, y].setStatus(PuyoController.NORMAL);
                    List<Puyo> puyoList = new List<Puyo>();
                    puyoList.Add(GameController.puyo[x, y]);
                    GameController.puyo[x, y].setPuyoList(puyoList);
                }
            }
            if (emptyRow)
                break;
        }
    }

    public static bool readyToEliminate()
    {
        bool haveLinkPuyo = false;
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameController.puyo[x, y] != null)
                {
                    emptyRow = false;
                    if (GameController.puyo[x, y].getPuyoList().Count >= 4)
                    {
                        haveLinkPuyo = true;
                        GameController.puyo[x, y].setStatus(PuyoController.Destroy);
                    }
                }
            }
            if (emptyRow)
                break;
        }
        UpdateSprite();
        return haveLinkPuyo;
    }

    public static void eliminatePuyo()
    {
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameController.puyo[x, y] != null)
                {
                    if (PuyoController.Destroy== GameController.puyo[x, y].getStatus())
                    {
                        Destroy(GameController.puyo[x, y].getPuyo());
                        GameController.puyo[x, y] = null;
                    }
                    emptyRow = false;
                }
            }
            if (emptyRow)
                break;
        }
    }
    
    public static bool GameOver()
    {
        if (GameController.ctlMp.getPosition().y >= 12 || GameController.ctlSp.getPosition().y >= 12) {
            return true;
        }

        return false;
    }
    
    
}
