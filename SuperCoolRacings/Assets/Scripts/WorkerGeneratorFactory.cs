using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerGeneratorFactory : UnitFactoryBase {

    [SerializeField]
    private List<ResourceCost> Costs;

    [SerializeField]
    private WorkerGenerator prototype;

    [SerializeField]
    private Resource workers;

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

            WorkerGenerator newUnit = Instantiate(prototype);
            newUnit.Initialize(workers, gameController);

            newUnit.transform.SetParent(cell.transform, false);
        }
    }
}
