using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public Material[] materials;
    private List<GameObject> alphabet = new List<GameObject>();

    private Renderer renderers;
    private GameObject letterWithSprite;

    public LetterManager letterManager;


    private void Awake()
    {
        letterManager = GetComponentInParent<LetterManager>();
    }

    private void Start()
    {
        //getting the materials
        GetAllProducts();
        if (letterWithSprite != null)
        {
            letterWithSprite.SetActive(true);
            renderers = letterWithSprite.GetComponent<Renderer>();

            //Debug.Log(renderers);

            renderers.enabled = true;
            renderers.sharedMaterial = materials[0];
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        //when touching the player
        if (collider.gameObject.tag == "Player")
        {
            Selecting();

            //setting the material to the new one
            if (renderers != null)
            {
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

    private void Selecting()
    {
        //when pressing space
        if (Input.GetKey("space"))
        {
            if (letterWithSprite != null)
            {
                //Debug.Log(letterWithSprite.name);
                PickUp();
                //Destroy(gameObject);
            }
        }
    }

    public void GetAllProducts()
    {
        foreach (Transform tr in this.GetComponentsInChildren<Transform>(true))
        {
            if (tr.name.Equals(this.name) && (tr != this.transform))
            {
                letterWithSprite = tr.gameObject;
            }
        }

        if (letterWithSprite != null)
        {
            //Debug.Log(letterWithSprite.name);
            //Debug.Log("End of list");
        }
    }

    private void PickUp()
    {
        transform.position = letterManager.letterPlacement[letterManager.getAmount()].transform.position;
        letterManager.SetAmount();
    }
}
