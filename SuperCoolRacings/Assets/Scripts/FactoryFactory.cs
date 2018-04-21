using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryFactory : UnitFactoryBase
{
    [SerializeField]
    private List<ResourceCost> Costs;

    [SerializeField]
    private FactoryBuilding prototype;

    [SerializeField]
    private ResourceGeneration materialsPerTick;
    [SerializeField]
    private ResourceGeneration moneyPerTick;

    [SerializeField]
    private Resource materials;

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

            FactoryBuilding newUnit = Instantiate(prototype);
            newUnit.Initialize(materials,gameController, materialsPerTick, moneyPerTick);

            newUnit.transform.SetParent(cell.transform, false);
        }
    }
}
