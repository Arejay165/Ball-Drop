﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public int inGamecost;
    public int moneyCost;
    public bool hasBrought;
    public float exp;
    public bool isSelected;
    public Sprite characterImage;
}
