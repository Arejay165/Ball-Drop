using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Trail", menuName = "Trails")]

public class Trails : ScriptableObject
{
    public bool isUnlock;
    public int amountOfPoints;
    public Material material;
    public bool isSelected;
}
