using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class DynamicChange : MonoBehaviour
{
    // a reference to the action
   // public SteamVR_Action_Boolean SphereOnOff;
    // a reference to the hand
   // public SteamVR_Input_Sources handType;
    //reference to the sphere
    public GameObject Sphere;
    public int i = 0;
    public static Boolean isStart = true;
    TextMesh textObject1,textObject2,textObject3;
    Dictionary<int,String> hmap;
    Boolean isTriggerOn = true;
    private void Start()
    {/*
        hmap = new Dictionary<int, string>();
        hmap[1]= " HELLO!!! You are trapped. Press trigger to know more.";
        hmap[2] = "Want to claim your kingdom back???";
        hmap[3] = "You need to dodge all the magic spells except blue.";
        hmap[4] = "Win your kingdom by collecting 5 blue spells. Beware of other spells. You have only 3 lives.";
        hmap[5] = "The speed of the spell increases with time. GET READY!!!";


        //SphereOnOff.AddOnStateDownListener(TriggerDown, handType);
       // SphereOnOff.AddOnStateUpListener(TriggerUp, handType);
        textObject1 = GameObject.Find("TutorialText1").GetComponent<TextMesh>();
        textObject2 = GameObject.Find("TutorialText2").GetComponent<TextMesh>();
        textObject3 = GameObject.Find("TutorialText3").GetComponent<TextMesh>();
        textObject1.text = "Press trigger for instructions";*/
    }

    //public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) 
    //{
        
    //    if(i >= 5)
    //    {
    //        if(isTriggerOn)
    //        StartCoroutine(Example());

    //    }
    //    else
    //    {
    //        Debug.Log("Up ");
    //        i++;
    //        String data = hmap[i];
    //        String[] toPrint = data.Split('.');
    //        textObject1.text = toPrint[0];
    //        textObject2.text = "";
    //        textObject3.text = "";
    //        if (toPrint[1]!= null)
    //        {
    //            textObject2.text = toPrint[1];
    //        }
    //        else
    //        {
    //            textObject2.text = "";
    //        }
            
    //        if(toPrint[2]!= null)
    //        {
    //            textObject3.text = toPrint[2];
    //        }
    //        else
    //        {
    //            textObject3.text = "";
    //        }
            
    //        toPrint[1] = null;
    //        toPrint[2] = null;
    //    }
    //}
    //public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    //{
    //    Debug.Log("Down ");
    //}

    //IEnumerator Example()
    //{
    //    isTriggerOn = false;
    //    textObject2.text = "";
    //    textObject3.text = "";
    //    textObject1.text = "  Game starts in 3";
    //    yield return new WaitForSeconds(1);
    //    textObject1.text = "  Game starts in 2";
    //    yield return new WaitForSeconds(1);
    //    textObject1.text = "  Game starts in 1";
    //    yield return new WaitForSeconds(1);
    //    isStart = true;
    //    textObject1.text = "LOOK      AROUND";
    //    yield return new WaitForSeconds(1);
    //    textObject1.text = "";
    //}
}