using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //Add this script to an object with an animation to make this script work!
    private MeshRenderer Mesh;
    private Animation anim;
    private Animator animator;
    int number = 0;
    [ReadOnly]
    public string AnimationName;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        animator = GetComponent<Animator>();
        Mesh = gameObject.GetComponent<MeshRenderer>();

        AnimationName = anim.clip.name;
             
        Mesh.enabled = false;
    }

    public void LoadAnimations(string name)
    {
        if (name.Equals(AnimationName))
        {
            Mesh.enabled = true;
            animator.SetBool(name, true);
        }
    }
 }
