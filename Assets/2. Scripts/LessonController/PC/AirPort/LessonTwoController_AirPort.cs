﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LessonTwoController_AirPort : GameController
{
    public GameObject passport;
    public GameObject pointBox;
    public NPCController npcController;

    public override void Action()
    {
        switch (dialogIndex)
        {
            case 0:
                FristAction();
                break;
            case 1:
                StartCoroutine("CheckButton");
                AddDialogIndex();
                break;
            case 2:
                diaLogHolder.SoundOutput();
                break;
            case 3:
                npcController.SetCharaterState(NPCController.CharaterState.Typing);
                diaLogHolder.SoundOutput();
                break;
            case 4:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                //여권 NPC 한테 주기 
                SetGrabObjectText("여권");
                passport.SetActive(true);
                pointBox.SetActive(true);
                break;
            case 5:
                npcController.SetCharaterState(NPCController.CharaterState.Give);
                passport.SetActive(false);
                pointBox.SetActive(false);
                diaLogHolder.SoundOutput();
                break;
            case 6:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;
            case 7:
            case 8:
                diaLogHolder.SoundOutput();
                break;

            default:
                EndAction();
                break;
        }
    }
}    
    
   
