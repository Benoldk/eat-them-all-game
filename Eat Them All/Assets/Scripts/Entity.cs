using System;
using UnityEngine;

public class Entity: MonoBehaviour
{
    public Action ReduceCrowdSizeEvent;

    public void Dying()
    {
        if(ReduceCrowdSizeEvent != null)
        {
            ReduceCrowdSizeEvent();
        }
    }
}