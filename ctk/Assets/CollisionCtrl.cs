using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCtrl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Ontrigger - controller");
        //Debug.Log(MoveMagicSpell.savedRandomRange);

        

    }

    private void OnTriggerExit(Collider other)
    {

        //if (counthit == 1)
        //{
        //    counthit = 0;
        //}

    }
}
