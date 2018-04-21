using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteProcessorFactory : UnitFactoryBase
{
    [SerializeField]
    private List<ResourceCost> Costs;

    [SerializeField]
    private WasteProcessor prototype;

    [SerializeField]
    private ResourceGeneration pollutionPerTick;
    [SerializeField]
    private ResourceGeneration wastePerTick;
    [SerializeField]
    private ResourceGeneration materialsPerTick;
    [SerializeField]
    private ResourceGeneration moneyPerTick;

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

            WasteProcessor newUnit = Instantiate(prototype);
            newUnit.Initialize(gameController, pollutionPerTick, wastePerTick, materialsPerTick, moneyPerTick);

            newUnit.transform.SetParent(cell.transform, false);
        }
    }

}
