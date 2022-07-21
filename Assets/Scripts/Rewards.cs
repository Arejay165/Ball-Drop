using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Reward", menuName = "Reward")]
public class Rewards : ScriptableObject
{
    public int points;
    public int coins;
    public bool hasUnlock;
    public Sprite Image;

    public RewardType rewardType;
    public enum RewardType {PointReward, CoinReward, CharacterReward };
}
