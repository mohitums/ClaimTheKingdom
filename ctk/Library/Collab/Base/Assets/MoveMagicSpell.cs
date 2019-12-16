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
    public GameObject[] all_magic_spells;
    public GameObject temp;
    int total_object = 100;
    GameObject cameraRig;
    public Vector3 CameraPosition;
    public Vector3 initialPosition;
    public static int randomRange = 0;
    public static int savedRandomRange = 0;
    public GameObject scoreText;
    public GameObject gameOverText;
    public static GameObject lightDisabled;
    void Start()
    {
        scoreText = GameObject.Find("[CameraRig]/Camera/Hello World");
        gameOverText = GameObject.Find("[CameraRig]/Camera/Game Over");
        lightDisabled = GameObject.Find("HALL/LIGHTS");
        lightDisabled.SetActive(false);
        gameOverText.SetActive(false);
        scoreText.SetActive(false);
        // Initialize Water Spells GameArray 
        all_magic_spells = new GameObject[100];
        for (int i = 0; i < total_object; i++)
        {
            Vector3 pos = RandomCircle(CameraPosition, 50.0f);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, CameraPosition - pos);
            GameObject single_water_spell;
            if (i < 33)
            {
                single_water_spell = Instantiate(magic_spell, pos, rot);
            }
            else if(i<66)
            {
                single_water_spell = Instantiate(blue_spell, pos, rot);
            }
            else
            {
                single_water_spell = Instantiate(arrow, pos, rot);
            }
            single_water_spell.transform.localScale = Vector3.one;
            all_magic_spells[i] = single_water_spell;
        }

        temp = all_magic_spells[0];
        initialPosition = temp.transform.position;
        cameraRig = GameObject.Find("[CameraRig]/Camera");
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
        if (DynamicChange.isStart)
        {
            float step = speed * Time.deltaTime;

            temp.transform.position = Vector3.MoveTowards(temp.transform.position, CameraPosition, step);
            if (Vector3.Distance(temp.transform.position, CameraPosition) < 0.001f)
            {
                savedRandomRange = randomRange;
                temp.transform.position = initialPosition;
                randomRange = Random.Range(0, 99);
                temp = all_magic_spells[randomRange];
                initialPosition = temp.transform.position;
                cameraRig = GameObject.Find("[CameraRig]/Camera");
                StartCoroutine(Example());
            if (randomRange < 33)
                {
                    CameraPosition = new Vector3(cameraRig.transform.position.x + 0.5f, cameraRig.transform.position.y, cameraRig.transform.position.z+0.5f);
                }
                else
               {
                    CameraPosition = new Vector3(cameraRig.transform.position.x, cameraRig.transform.position.y, cameraRig.transform.position.z);
                }
                if (speed < 8)
                {
                    speed += 0.2f;
                }
                
            }
        }

        

    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(1);
        scoreText.SetActive(true);
        yield return new WaitForSeconds(3);
        scoreText.SetActive(false);
        print(Time.time);
    }

}
