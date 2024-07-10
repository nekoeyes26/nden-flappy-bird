using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bird", menuName = "Bird")]
public class BirdScriptable : ScriptableObject
{
    public new string name;
    public Sprite sprite;
}
