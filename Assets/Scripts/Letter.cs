using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            //setting the material to the new one
            renderers.sharedMaterial = materials[1];
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (renderers != null)
            {
                //resetting the material to the origional one
                renderers.sharedMaterial = materials[0];
            }
        }
    }

    void Selecting()
    {
        //when pressing space
        if (Input.GetKey("space"))
        {
            Debug.Log(gameObject.name);
            Destroy(gameObject);
        }
    }
}
