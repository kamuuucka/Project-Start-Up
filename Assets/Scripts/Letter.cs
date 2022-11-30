using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public Material[] materials;

    private Renderer renderers;
    private GameObject letterWithSprite;
    private LetterManager letterManager;

    private void Start()
    {
        letterManager = GetComponentInParent<LetterManager>();
        //getting the materials
        GetAllProducts();
        if (letterWithSprite != null)
        {
            letterWithSprite.SetActive(true);
            renderers = letterWithSprite.GetComponent<Renderer>();

            renderers.enabled = true;
            renderers.sharedMaterial = materials[0];
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        //when touching the player
        if (collider.gameObject.CompareTag("Player"))
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
                //resetting the material to the original one
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
                PickUp();
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
    }

    private void PickUp()
    {
        if (letterManager.GetAmount() < 9)
        {
            transform.position = letterManager.letterPlacement[letterManager.GetAmount()].transform.position;
            letterManager.SetAmount();
            letterManager.AddToList(this.gameObject);
        }
        else
        {
            Debug.Log("There is no more space on the shelf!");
            letterManager.LevelReload();
        }
    }
}
