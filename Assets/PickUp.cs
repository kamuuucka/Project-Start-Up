using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    RaycastHit hit;
    public float range;


    void Update()
    {
        //raycast out. from the player, hit is information gather from the thing that it hits, forwards direction, how far.
        Debug.DrawRay(transform.position, hit.point, Color.yellow);
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Selecting();
        }
    }

    void Selecting()
    {
        //get the infro from hit object, save it 
        var selection = hit.transform;
        //get the material
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            //change the material to the highlighted material
            selectionRenderer.material = highlightMaterial;
        }

        if (Input.GetKey("space"))
        {
            //name of the object you have selected
            Debug.Log(hit.transform.name);

            //momentairily link the letter to the player. 
            Letter letter = hit.transform.GetComponent<Letter>();
            if (letter != null)
            {
                //call upon the dystroy function of the letter
                letter.Dissapear();
            }
        }
    }
}
