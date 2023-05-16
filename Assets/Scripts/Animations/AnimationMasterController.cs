using UnityEngine;

public class AnimationMasterController : MonoBehaviour
{
    // make sure everything is in here, and that the order of both arrays match! -> ugly, but thats how it is...
    public Animator[] anims;
    string[] boolNames = { "RightWall", "BackWall", "LeftWall", "FrontWall", "Roof", "Door", "WindowCircle", "WindowSquare", "Chimney" };
    public LetterManager manager;
    public ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem.Stop();
    }
    void Update()
    {// test code / demo:
        for (int i = 0; i < 4; i++)
        {
            // TODO: instead of GetKeyDown, control this by game code...
            //if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            //{
            //    Debug.Log(anims[i]);
            //    Debug.Log(boolNames[i]);
            //    anims[i].SetBool(boolNames[i], true);
            //}

            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                switch (i)
                {
                    case 0:
                        //for (int j = 0; j < 4; j++)
                        //{
                        //    anims[j].SetBool(boolNames[j], true);
                        //}
                        anims[0].SetBool(boolNames[0], true);
                        anims[1].SetBool(boolNames[1], true);
                        anims[2].SetBool(boolNames[2], true);
                        anims[3].SetBool(boolNames[3], true);
                        break;      //walls
                    case 1:
                        anims[4].SetBool(boolNames[4], true);
                        break;      //roof
                    case 2:
                        for (int j = 5; j < 8; j++)
                        {
                            anims[j].SetBool(boolNames[j], true);
                        }
                        break;      //door windows
                    case 3:
                        anims[8].SetBool(boolNames[8], true);
                        break;      //chimney
                    case 4:
                        Debug.Log("SMOK");
                        break;      //smoke
                    default:
                        break;
                }
            }

        }

        if (manager.GetLevelDone())
        {
            //Debug.Log("ANIMATION PLAY");
            //anims[manager.GetAnswerNumber() - 1].SetBool(boolNames[manager.GetAnswerNumber() - 1], true);
            //Invoke("SetLevelState", 2f);
            switch (manager.GetAnswerNumber() - 1)
            {
                case 0:
                    //for (int j = 0; j < 4; j++)
                    //{
                    //    anims[j].SetBool(boolNames[j], true);
                    //}
                    anims[0].SetBool(boolNames[0], true);
                    anims[1].SetBool(boolNames[1], true);
                    anims[2].SetBool(boolNames[2], true);
                    anims[3].SetBool(boolNames[3], true);
                    break;      //walls
                case 1:
                    anims[4].SetBool(boolNames[4], true);
                    break;      //roof
                case 2:
                    for (int j = 5; j < 8; j++)
                    {
                        anims[j].SetBool(boolNames[j], true);
                    }
                    break;      //door windows
                case 3:
                    anims[8].SetBool(boolNames[8], true);
                    break;      //chimney
                case 4:
                    particleSystem.Play();
                    break;      //smoke
                default:
                    break;
            }
            manager.SetLevelDone(false);

        }
    }
}
