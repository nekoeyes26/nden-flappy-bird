using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBird : MonoBehaviour
{
    public BirdScriptable birdScriptable;

    public void ChooseBird()
    {
        GameSingleton.instance.assignBird(birdScriptable);
        SceneManager.LoadScene("SampleScene");
    }
}
