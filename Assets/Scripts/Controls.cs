using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
  
 
    void Update()
    {
        if (GameController.gs== GameController.Gs.Falling)
        {

            if (Input.GetKeyUp(KeyCode.LeftArrow) && (!PuyoMaster.Walls(0, (int)GameController.ctlMp.getPosition().x, (int)GameController.ctlMp.getPosition().y) && !PuyoMaster.Walls(0, (int)GameController.ctlSp.getPosition().x, (int)GameController.ctlSp.getPosition().y)))
            {
                PuyoMaster.puyoleft(true);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && (!PuyoMaster.Walls(1, (int)GameController.ctlMp.getPosition().x, (int)GameController.ctlMp.getPosition().y) && !PuyoMaster.Walls(1, (int)GameController.ctlSp.getPosition().x, (int)GameController.ctlSp.getPosition().y)))
            {
                PuyoMaster.puyoright(true);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                PuyoMaster.puyoCounterclokwise();
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                PuyoMaster.puyoClockwise();
            }
            
        }
    }
}
