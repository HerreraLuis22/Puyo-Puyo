using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puyo : MonoBehaviour
{

    private GameObject puyo;
    private List<Puyo> PuyoList;
    private int color;
    private Vector2 position;
    private string Status;

    public void setPuyo(GameObject puyoObj)
    {
        this.puyo = puyoObj;
    }
    public GameObject getPuyo()
    {
        return puyo;
    }

    public void setColor(int color)
    {
        this.color = color;
    }
    public int getColor()
    {
        return color;
    }

    public void setPuyoList(List<Puyo> PuyoList)
    {
        this.PuyoList = PuyoList;
    }
    public List<Puyo> getPuyoList()
    {
        return PuyoList;
    }

    public void setPosition(Vector2 position)
    {
        this.position = position;
    }
    public Vector2 getPosition()
    {
        return position;
    }

    public void setStatus(string Status)
    {
        this.Status = Status;
    }
    public string getStatus()
    {
        return Status;
    }
}
