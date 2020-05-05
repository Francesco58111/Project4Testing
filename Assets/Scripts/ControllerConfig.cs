using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Controller Config.asset", menuName = "Custom/ControllerConfig", order = 100)]
public class ControllerConfig : ScriptableObject
{
    public float speed;

    public AnimationCurve acceleration = AnimationCurve.EaseInOut(0,0,1,1);

    public Vector3 gravity;
}
