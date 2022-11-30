using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public Material[] materials;
    Renderer renderers;

    
    private void Start()
    {
        //getting the materials
        renderers = GetComponent<Renderer>();
        renderers.enabled = true;
        renderers.sharedMaterial = materials[0];
    }

    private void OnTriggerStay(Collider collider)
    {
        //when touching the player
        if (collider.gameObject.tag == "Player")
        {
            Selecting();
            if (renderers != null)
            {
                //setting the material to the new one
                renderers.sharedMaterial = materials[1];
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //if touched by player
        if (collider.gameObject.tag == "Player")
        {
            if (renderers != null)
            {
                //resetting the material to the origonal one
                renderers.sharedMaterial = materials[0];
            }
        }
    }

    void Selecting()
    {
        //when pressing space
        if (Input.GetKey("space"))
        {
            //get the string name of the object and then destroy

            Debug.Log(gameObject.name);



            Destroy(gameObject);
        }
    }
}
