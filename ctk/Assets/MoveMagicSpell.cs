
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMagicSpell : MonoBehaviour
{

    public float speed;
    GameObject spell;
    Vector3 v;
    public GameObject magic_spell;
    public GameObject blue_spell;
    public GameObject arrow;
    public GameObject test1;
    public GameObject[] all_magic_spells;
    public GameObject temp;
    int total_object = 50;
    GameObject cameraRig;
    public Vector3 CameraPosition;
    public Vector3 initialPosition;
    public static int randomRange =10;
    public static int savedRandomRange = 10;
    public GameObject scoreText;
    public GameObject gameOverText;
    public bool passedCamera =false;
    // Added new spells vars
    public GameObject Model;
    private GameObject modelInstance;
    public GameObject[] Prefabs;
    //
    public static GameObject lightDisabled;
    public GameObject left_hand;
    public  GameObject right_hand;
    public static GameObject[] left_gems;
    public static GameObject[] right_gems;
    public float xD, yD, zD;
    //AudioSource audioSource;
    public static void spawnLeftGems(GameObject[] left_gems, GameObject left_hand)
    {
        left_gems = new GameObject[5];
        left_gems[0] = left_hand.transform.Find("Index_Finger_1/first_gem").gameObject;
        left_gems[1] = left_hand.transform.Find("Middle_Finger_1/second_gem").gameObject;
        left_gems[2] = left_hand.transform.Find("Ring_Finger_1/fourth_gem").gameObject;
        left_gems[3] = left_hand.transform.Find("Pinky_Finger_1/third_gem").gameObject;
        left_gems[4] = left_hand.transform.Find("Thumb_1/fifth_gem").gameObject;
        
        for(int i = 0; i < left_gems.Length; i++)
        {
            left_gems[i].SetActive(false);
        }

    }

    public static void spawnRightGems(GameObject[] right_gems, GameObject right_hand)
    {
        right_gems = new GameObject[3];
        right_gems[0] = right_hand.transform.Find("Index_Finger_1/first_gem").gameObject;
        right_gems[1] = right_hand.transform.Find("Middle_Finger_1/second_gem").gameObject;
        right_gems[2] = right_hand.transform.Find("Ring_Finger_1/third_gem").gameObject;
    }

    void Start()
    {
        //scoreText = GameObject.Find("[CameraRig]/Camera/Hello World");
        //gameOverText = GameObject.Find("[CameraRig]/Camera/Game Over");
        //audioSource = GetComponent<AudioSource>(),mute = true;
        //audioSource.mute = true;
        spawnLeftGems(left_gems, left_hand);
        spawnRightGems(right_gems, right_hand);
        if(test1 == null)
        {
            Debug.Log("Camera Rig is null");

        }
        else
        {
            Debug.Log("its not null");
        }
        lightDisabled = GameObject.Find("HALL/LIGHTS");
        lightDisabled.SetActive(false);
        //gameOverText.SetActive(false);
        //scoreText.SetActive(false);
        // Initialize Water Spells GameArray 
        all_magic_spells = new GameObject[50];
        for (int i = 0; i < total_object; i++)
        {
            Vector3 pos = RandomCircle(CameraPosition, 50.0f);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, CameraPosition - pos);
            GameObject single_water_spell;
            if (i < 16)
            {
        
                single_water_spell = Instantiate(magic_spell,pos,rot);
          
            }
            else if(i<32)
            {
                Model.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                single_water_spell = Instantiate(Model, pos, rot);
         
                var effectInstance = Instantiate(Prefabs[0]);
                effectInstance.transform.parent = single_water_spell.transform;
                //effectInstance.transform.localPosition = Vector3.zero;
                effectInstance.transform.localRotation = new Quaternion();
                var meshUpdater = effectInstance.GetComponent<PSMeshRendererUpdater>();
                meshUpdater.UpdateMeshEffect(single_water_spell);
                Debug.Log(single_water_spell.transform.localScale.x + "b");
                //single_water_spell.GetComponent<Animator>().enabled = false;
                single_water_spell.transform.localScale = new Vector3(0.375f, 0.375f, 0.375f);
                Debug.Log(single_water_spell.transform.localScale.x + "a");
                // single_water_spell.GetComponent<AudioSource>().mute = false;
            }
            else
            {
                single_water_spell = Instantiate(Model, pos, rot);
                
                var effectInstance = Instantiate(Prefabs[1]);
                effectInstance.transform.parent = single_water_spell.transform;
                //effectInstance.transform.localPosition = Vector3.zero;
                effectInstance.transform.localRotation = new Quaternion();
                var meshUpdater = effectInstance.GetComponent<PSMeshRendererUpdater>();
                meshUpdater.UpdateMeshEffect(single_water_spell);
                meshUpdater.UpdateColor(Color.yellow);
                Debug.Log(single_water_spell.transform.localScale.x + "b");
                //single_water_spell.GetComponent<Animator>().enabled = false;
                single_water_spell.transform.localScale = new Vector3(0.3f, 0.3f, 0.375f);
                Debug.Log(single_water_spell.transform.localScale.x + "a");
                //  single_water_spell.GetComponent<AudioSource>().mute = false;
            }
            //   single_water_spell.transform.localScale = Vector3.one;
            all_magic_spells[i] = single_water_spell;
        }

        temp = all_magic_spells[0];
        initialPosition = temp.transform.position;
        
        cameraRig = GameObject.Find("[CameraRig]/Camera (eye)");
        if(cameraRig == null)
        {
            Debug.Log("null");
        }
        Debug.Log(all_magic_spells);

    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;

        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + 3.0f;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }


    // Update is called once per frame
    void Update()
    {
        float oX, oY, oZ;
        oX = initialPosition.x;
        oY = initialPosition.y;
        oZ = initialPosition.z;

        float cX, cY, cZ;
        cX = CameraPosition.x;
        cY = CameraPosition.y;
        cZ = CameraPosition.z;



        xD = cX - oX;
        yD = cY - oY;
        zD = cZ - oZ;

        if (xD > 10)
        {
            xD = 10;
        }
        else if (xD < -10)
        {
            xD = -10;
        }

        if (zD > 10)
        {
            zD = 10;
        }
        else if (zD < -10)
        {
            zD = -10;
        }


        if (DynamicChange.isStart)
        {
            float step = speed * Time.deltaTime;
            Vector3 nextPos = new Vector3(cX + xD, cY, cZ + zD);




            if (Vector3.Distance(temp.transform.position, CameraPosition) < 0.001f && !passedCamera)
            {
                passedCamera = true;

            }
            else if (passedCamera)
            {
                if (Vector3.Distance(temp.transform.position, nextPos) < 0.001f)
                {
                    temp.transform.position = initialPosition;
                    randomRange = (randomRange + 10) % 50;
                    //randomRange = Random.Range(0, 49);
                    temp = all_magic_spells[randomRange];
                    initialPosition = temp.transform.position;
                    //cameraRig = GameObject.Find("[CameraRig]/Camera");
                    StartCoroutine(Example());
                    if (randomRange < 16)
                    {
                        CameraPosition = new Vector3(cameraRig.transform.position.x, cameraRig.transform.position.y - 0.3f, cameraRig.transform.position.z + 0.5f);
                    }
                    else
                    {
                        CameraPosition = new Vector3(cameraRig.transform.position.x, cameraRig.transform.position.y - 0.3f, cameraRig.transform.position.z);
                    }
                    if (speed < 7)
                    {
                        speed += 0.2f;
                    }
                    passedCamera = false;
                }
                else
                {
                    temp.transform.position = Vector3.MoveTowards(temp.transform.position, nextPos, step);
                }

            }
            else
            {
                temp.transform.position = Vector3.MoveTowards(temp.transform.position, CameraPosition, step);
            }
        }
           
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(1);
       // scoreText.SetActive(true);
        yield return new WaitForSeconds(3);
        //scoreText.SetActive(false);
        print(Time.time);
    }

}
