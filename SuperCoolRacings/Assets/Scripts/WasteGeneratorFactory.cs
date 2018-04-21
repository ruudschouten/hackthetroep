using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteGeneratorFactory : UnitFactoryBase
{
    [SerializeField]
    private List<ResourceCost> Costs;

    [SerializeField]
    private WasteGenerator prototype;

    [SerializeField]
    private ResourceGeneration moneyPerTick;
    [SerializeField]
    private ResourceGeneration wastePerTick;

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

            WasteGenerator newUnit = Instantiate(prototype);
            newUnit.Initialize(gameController, moneyPerTick, wastePerTick);

            newUnit.transform.SetParent(cell.transform, false);
        }
    }
}
