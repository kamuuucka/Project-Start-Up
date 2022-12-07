using UnityEngine;

/// <summary>
/// Script responsible for the Letter behaviours
/// </summary>
public class Letter : MonoBehaviour
{
    public Material[] materials;

    private Renderer letterRenderer;
    private GameObject letterWithSprite;
    private LetterManager letterManager;

    private void Start()
    {
        letterManager = GetComponentInParent<LetterManager>();
        GetAllProducts();

        if (letterWithSprite != null)
        {
            letterWithSprite.SetActive(true);
            letterRenderer = letterWithSprite.GetComponent<Renderer>();

            letterRenderer.enabled = true;
            letterRenderer.sharedMaterial = materials[0];
        }
    }

    /// <summary>
    /// Changing colour of the material when player touches it
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Selecting();
            if (letterRenderer != null) letterRenderer.sharedMaterial = materials[1];
        }
    }

    /// <summary>
    /// Changing colour of the material when player stops touching it
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (letterRenderer != null) letterRenderer.sharedMaterial = materials[0];   
        }
    }

    /// <summary>
    /// Pick up letters when pressing space
    /// </summary>
    private void Selecting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (letterWithSprite != null) PickUp();
        }
    }

    /// <summary>
    /// Getting the materials
    /// </summary>
    public void GetAllProducts()
    {
        foreach (Transform tr in GetComponentsInChildren<Transform>(true))
        {
            if (tr.name.Equals(name) && (tr != transform)) letterWithSprite = tr.gameObject; 
        }
    }

    /// <summary>
    /// Picking up the letters and updating the shelf information
    /// </summary>
    private void PickUp()
    {
        if (letterManager.GetAmountOfLettersInWord() < 9)
        {
            transform.position = letterManager.letterPlacement[letterManager.GetAmountOfLettersInWord()].transform.position;
            letterManager.AddToList(gameObject.name);
        }
        else
        {
            //If player wants to collect more than 9 letters, reset the board
            letterManager.LevelReload();
        }
    }
}
