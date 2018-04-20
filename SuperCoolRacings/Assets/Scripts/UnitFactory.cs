using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitFactory : UnitFactoryBase {

    [SerializeField]
    private List<ResourceCost> Costs;

    [SerializeField]
    private Unit prototype;

    void Awake()
    {

    }


    public override void SpawnUnit(Cell cell)
    {

        bool canAfford = true;

        foreach (ResourceCost cost in Costs)
        {
            if (!cost.CanAfford())
            {
                canAfford = false;
            }
        }


        if (canAfford && cell != null)
        {
            foreach (ResourceCost cost in Costs)
            {
                cost.Resource.ReduceAmount(cost.Cost);
            }

            Unit newUnit = Instantiate(prototype);
            newUnit.Initialize(gameController);

            newUnit.transform.SetParent(cell.transform, false);
        }
    }

    
}


