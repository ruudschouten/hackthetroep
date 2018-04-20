using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RecycleCenter))]
public class RecycleCenterFactory : UnitFactoryBase {

    [SerializeField]
    private RecycleCenter prototype;

    private RecycleCenter resourcePrototype;

    void Awake()
    {
        resourcePrototype = GetComponent<RecycleCenter>();
    }

    public List<ResourceCost> Costs;

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

            RecycleCenter newUnit = Instantiate(prototype);
            newUnit.Initialize(resourcePrototype, gameController);

            newUnit.transform.SetParent(cell.transform, false);
        }
    }
}
