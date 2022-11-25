using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawRay(transform.position, hit.point, Color.yellow);
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Selecting();
        }
    }

    void Selecting()
    {
        Debug.Log(hit.transform.name);

        var selection = hit.transform;
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = highlightMaterial;
        }

        if (Input.GetKey("space"))
        {
            Destroy(gameObject);
        }
    }

}
