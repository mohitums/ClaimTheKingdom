using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    public static int scoreValue = 0;
    public static int hitValue = 3;
    public TextMesh outputTarget;
    void Start()
    {
        outputTarget = GameObject.Find("Hello World").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        outputTarget.text = "Score: " + scoreValue.ToString() + "\n\n" + "Lives:  " + hitValue.ToString();
    }
}
