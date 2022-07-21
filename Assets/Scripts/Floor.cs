using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Floor", menuName = "Floor")]
public class Floor : ScriptableObject
{

    public Material material;
    public string floorName;
    public int amountOfCoin;
    public bool isUnlock;
    public bool isSelected;
}
