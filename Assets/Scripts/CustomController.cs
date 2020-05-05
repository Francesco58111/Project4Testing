using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomController : MonoBehaviour
{
    public ControllerConfig currentConfig;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Moving()
    {
        float speed = currentConfig.speed;
    }
}
