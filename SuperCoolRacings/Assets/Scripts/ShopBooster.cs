using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopBooster : MonoBehaviour {

    public BoostEvent ShopBoostChanged = new BoostEvent();

    private int boostLevel = 0;

    public int MaxBoostLevel = 10;

    public void AddBoost()
    {
        if (boostLevel < 10)
        {
            boostLevel++;
            ShopBoostChanged.Invoke(boostLevel);
        }
    }

    public void RemoveBoost()
    {
        if (boostLevel < 0)
        {
            boostLevel--;
            ShopBoostChanged.Invoke(boostLevel);
        }
    }

}

[System.Serializable]
public class BoostEvent : UnityEvent<int>
{

}
