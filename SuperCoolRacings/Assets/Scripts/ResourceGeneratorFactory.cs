using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourceGenerator))]
public class ResourceGeneratorFactory : UnitFactoryBase {
    
    [SerializeField]
    private ResourceGenerator prototype;

    private ResourceGenerator resourcePrototype;

    public List<ResourceCost> Costs;

    void Awake()
    {
        resourcePrototype = GetComponent<ResourceGenerator>();
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

            ResourceGenerator newUnit = Instantiate(prototype);
            newUnit.Initialize(resourcePrototype, gameController);

            newUnit.transform.SetParent(cell.transform, false);
        }
    }


}
