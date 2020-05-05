using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextAssetReader : ScriptableObject
{

    public TextAsset myTextAsset;

    public QuestSettings[] quests;
    
}

public enum RewardType {Gold, Score, Fame, Friends, Fear};


[System.Serializable]
public struct QuestSettings
{
    public int index;
    public string title, description;
    public RewardType rewardType;
    public float rewardValue;
}
