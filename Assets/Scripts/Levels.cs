using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Levels : ScriptableObject
{
    public bool isUnlock;
    public float desiredScore;
    public int pointsCost;
    public string levelNumber;

}
