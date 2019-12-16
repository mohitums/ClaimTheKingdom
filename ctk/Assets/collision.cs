using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;



public class collision : MonoBehaviour
{
    //public SteamVR_Action_Vibration coll;
    public static int permissible_hits = 4;
    public int counthit = 0;
    public static int score = 0;
    private SteamVR_TrackedController device1;
    //public GameObject gameOverText;
    //public TextMesh gameWinText;
    ////private void pulse(float duration, float frequency, float amplitute, SteamVR_Input_Sources abc)
    ////{
    ////    coll.Execute(0, duration, frequency, amplitute, abc);
    ////}
    ///
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;
    public GameObject left_hand;
    public GameObject right_hand;
    public GameObject gameOver;
    public TextMesh gameText;
    private void OnTriggerEnter(Collider other)
    {
        //device1 = GetComponent<SteamVR_TrackedController>();
       // device1.Tr
    
        if (counthit == 0)
        {
           // Debug.Log("Goes in  - collider");
           
            counthit++;
            Debug.Log(other.gameObject.name);
            if (other.gameObject.name.Contains("Magic_3"))
            {
                
                Debug.Log("&&&&");
                Debug.Log(this.gameObject.name);
                left_hand.transform.GetChild(score).GetChild(0).gameObject.SetActive(true);
                score += 1;
                if (score == 5)
                {
                    //  gameOver = GameObject.Find("[CameraRig]/Camera (head)/GameOver");
                    gameText = gameOver.GetComponent<TextMesh>();
                    gameText.text = "YOU CLAIMED THE KINGDOM!!!";
                    gameText.color = new Color(12, 215, 36);
                    gameOver.SetActive(true);
                    DynamicChange.isStart = false;
                    MoveMagicSpell.lightDisabled.SetActive(true);
                }


            }
            else
            {
               
                permissible_hits -= 1;
                right_hand.transform.GetChild(permissible_hits).gameObject.SetActive(false);
                Debug.Log(this.gameObject.name);
                if (permissible_hits == 0)
                {
                    // gameOver = GameObject.Find("[CameraRig]/Camera (head)/GameOver");
                    Debug.Log(gameOver.transform.position);
          
                    gameOver.SetActive(true);
                    DynamicChange.isStart = false;
                    Debug.Log("Game Over");
                }

            }


           

           

           // Debug.Log("Hits: " + permissible_hits.ToString());
           // Debug.Log("Score: " + score.ToString());
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (counthit == 1)
        {
            counthit = 0;
        }

    }

    //IEnumerator Example()
    //{
    //    yield return new WaitForSeconds(5);
    //    // Application.Quit();
    //}
}
