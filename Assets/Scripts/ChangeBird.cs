using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBird : MonoBehaviour
{
    public PlayerController playerController;
    public BirdScriptable birdScriptable;

    public void ChooseBird()
    {
        GameSingleton.instance.assignBird(birdScriptable);
    }
}
