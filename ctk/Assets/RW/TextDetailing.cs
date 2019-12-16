using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextDetailing : MonoBehaviour
{
    TextMesh textObject;
    // Start is called before the first frame update
    void Start()
    {
         textObject = GameObject.Find("TextPr").GetComponent<TextMesh>();
        textObject.text = "test";
        StartCoroutine(Example());

        
    }

    // Update is called once per frame
    void Update()
    {
        textObject.text = "t1";
        //yield return new WaitForSeconds(4);
       
        Debug.Log("called");
        //
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(60);
        print(Time.time);
        SceneManager.LoadScene("Exemple_Night");
    }
}
