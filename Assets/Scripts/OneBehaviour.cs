using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct BehaviourStats
{
    public float something, otherThing, more;

    public AnimationCurve animCurve;
}


public class OneBehaviour : MonoBehaviour
{
    [Header("Some variables")]
    public float life;

    public BehaviourStats myStats;

    [SerializeField] private float defense;

    public int[] arrayColor;

}
