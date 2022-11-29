using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public Material[] materials;
    Renderer renderers;

    private void Start()
    {
        renderers = GetComponent<Renderer>();
        renderers.enabled = true;
        renderers.sharedMaterial = materials[0];
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Selecting();
            Debug.Log("now");

            renderers.sharedMaterial = materials[1];
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            renderers.sharedMaterial = materials[0];
        }
    }

    void Selecting()
    {
        //when pressing space
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log(gameObject.name);
            Destroy(gameObject);
        }
    }
}
