using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Puyo_Green;
    public GameObject Puyo_Blue;
    public GameObject Puyo_Red;
    public GameObject Puyo_Yellow;
    public static GameObject ObPb;
    public static GameObject ObPg;
    public static GameObject ObPr;
    public static GameObject ObPy;
    void Start()
    {
        ObPb = Puyo_Blue;
        ObPg = Puyo_Green;
        ObPr = Puyo_Red;
        ObPy = Puyo_Yellow;
    }
    public static Puyo PuyoCreate(int x, int y) {
        Puyo puyo = GameController.ObPs.AddComponent<Puyo>();
        puyo.setColor(Random.Range(0, 4));
        puyo.setStatus(PuyoController.NORMAL);
        GameObject newPuyoObj;
        switch (puyo.getColor())
        {
            case 0:
                newPuyoObj = Instantiate(ObPb);
                break;
            case 1:
                newPuyoObj = Instantiate(ObPg);
                break;
            case 2:
                newPuyoObj = Instantiate(ObPr);
                break;
            case 3: newPuyoObj = Instantiate(ObPy);
                break;
            default:
                newPuyoObj = Instantiate(ObPb);
                break;
        }

        newPuyoObj.transform.SetParent(GameController.ObPs.transform);
        newPuyoObj.transform.localPosition = new Vector3(x, y, 0);
        newPuyoObj.transform.localScale = new Vector3(1, 1, 1);
        puyo.setPuyo(newPuyoObj);

        List<Puyo> PuyoList = new List<Puyo>();
        PuyoList.Add(puyo);
        puyo.setPuyoList(PuyoList);

        return puyo;
    }

    
}
