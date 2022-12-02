using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //Add this script to an object with an animation to make this script work!
    private MeshRenderer Mesh;
    private Animation anim;
    private Animator animator;
    [ReadOnly]
    public string AnimationName;   

    // Start is called before the first frame update
    void Start()
    {
        //Gets the components and stores it in an variable.
        anim = gameObject.GetComponent<Animation>();
        

        animator = GetComponent<Animator>();
        Mesh = gameObject.GetComponent<MeshRenderer>();

        //Gets the name of the animation.

        AnimationName = anim.clip.name;

        

        //Mesh.enabled = false;

        animator.SetBool(AnimationName, true);
        //anim.Play(AnimationName);
    }

    public void Update()
    {
        if(Input.GetKey("w"))
        {
            //_animator.SetBool("BackWall", true);
            //_animator.SetBool("Roof", true);
            // _animator.SetBool("LeftWall", true);

            Mesh.enabled = true;
            animator.SetInteger("PlayBack",0);

        }
        /*

        //Checks if animation is played, if it does it will enable the mesh renderer.
        if (anim.IsPlaying(AnimationName) == true)
            {
                Mesh.enabled = true;
            }

        /*
        //button trigger test: Press P to start animation.
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            anim.Play(AnimationName);
        }
        */


    }

}
