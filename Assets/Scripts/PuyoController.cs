using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PuyoController : MonoBehaviour
{
    //Declare 
    public const string NORMAL = "normal";
    public const string TOP = "top";
    public const string RIGHT = "right";
    public const string TOP_RIGHT = "top_right";
    public const string DOWN = "down";
    public const string TOP_DOWN = "top_down";
    public const string RIGHT_DOWN = "right_down";
    public const string TOP_RIGHT_DOWN = "top_right_down";
    public const string LEFT = "left";
    public const string TOP_LEFT = "top_left";
    public const string RIGHT_LEFT = "right_left";
    public const string TOP_RIGHT_LEFT = "top_right_left";
    public const string LEFT_DOWN = "left_down";
    public const string TOP_LEFT_DOWN = "top_left_down";
    public const string RIGHT_LEFT_DOWN = "right_left_down";
    public const string TOP_RIGHT_LEFT_DOWN = "top_right_left_down";
    public const string Destroy = "destroy";
    //Declare 
    public Sprite[] Puyo_Blue;
    public Sprite[] Puyo_Green;
    public Sprite[] Puyo_Red;
    public Sprite[] Puyo_Yellow;
 

    public static Dictionary<string, Sprite> Puyo_Blue_Direct = new Dictionary<string, Sprite>();
    public static Dictionary<string, Sprite> Puyo_Green_Direct = new Dictionary<string, Sprite>();
    public static Dictionary<string, Sprite> Puyo_Red_Direct = new Dictionary<string, Sprite>();
    public static Dictionary<string, Sprite> Puyo_Yellow_Direct = new Dictionary<string, Sprite>();
    

    private void Start()
    {
        PuyoOrientation(Puyo_Blue, Puyo_Blue_Direct);
        PuyoOrientation(Puyo_Green, Puyo_Green_Direct);
        PuyoOrientation(Puyo_Red, Puyo_Red_Direct);
        PuyoOrientation(Puyo_Yellow, Puyo_Yellow_Direct);
    }
 
    public static void PuyoSprite(Puyo puyo, string imgkey) {
        Image Image = puyo.getPuyo().GetComponent<Image>();
        switch (puyo.getColor())
        {
            case 0:
                Image.sprite = Puyo_Blue_Direct[imgkey];
                break;
            case 1:
                Image.sprite = Puyo_Green_Direct[imgkey];
                break;
            case 2:
                Image.sprite = Puyo_Red_Direct[imgkey];
                break;
            case 3:
                Image.sprite = Puyo_Yellow_Direct[imgkey];
                break;
        }
    }
    private void PuyoOrientation(Sprite[] sprite, Dictionary<string, Sprite> dic)
    {
        dic.Add(NORMAL, sprite[0]);
        dic.Add(TOP, sprite[1]);
        dic.Add(RIGHT, sprite[2]);
        dic.Add(TOP_RIGHT, sprite[3]);
        dic.Add(DOWN, sprite[4]);
        dic.Add(TOP_DOWN, sprite[5]);
        dic.Add(RIGHT_DOWN, sprite[6]);
        dic.Add(TOP_RIGHT_DOWN, sprite[7]);
        dic.Add(LEFT, sprite[8]);
        dic.Add(TOP_LEFT, sprite[9]);
        dic.Add(RIGHT_LEFT, sprite[10]);
        dic.Add(TOP_RIGHT_LEFT, sprite[11]);
        dic.Add(LEFT_DOWN, sprite[12]);
        dic.Add(TOP_LEFT_DOWN, sprite[13]);
        dic.Add(RIGHT_LEFT_DOWN, sprite[14]);
        dic.Add(TOP_RIGHT_LEFT_DOWN, sprite[15]);
        dic.Add(Destroy, sprite[16]);
    }

}
