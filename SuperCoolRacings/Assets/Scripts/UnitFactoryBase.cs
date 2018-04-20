using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class UnitFactoryBase : MonoBehaviour {

    [SerializeField]
    protected GameController gameController;

    public virtual void SpawnUnit(Cell cell)
    {

    }

    void Start()
    {

    }

    public virtual void PrimeForSpawning()
    {
        if (gameController != null)
        {
            gameController.SpawningMode.PrimeThisMode(this);
        }
    }
}

[System.Serializable]
public class ResourceCost
{
    public Resource Resource;
    public int Cost;

    public bool CanAfford()
    {
        return Resource.CanAfford(Cost);
    }
}
