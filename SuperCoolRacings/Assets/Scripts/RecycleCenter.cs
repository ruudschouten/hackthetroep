using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleCenter : MonoBehaviour {

    [SerializeField]
    private List<ResourceGeneration> ResourcesPerTick;

    private Unit unit;

    private ResourceGeneration Plastic;
    private ResourceGeneration Material;
    private ResourceGeneration CO2;
    public bool isIncinerating;
    public int MaxWorkers;
    public int CurrentWorkers;
    private int Efficiency;

    void Awake()
    {
        unit = GetComponent<Unit>();
    }

    public void Initialize(RecycleCenter generator, GameController gameController)
    {
        unit.Initialize(gameController);
        unit.OnTickEvent.AddListener(OnTick);

        foreach (ResourceGeneration generation in generator.ResourcesPerTick)
        {
            ResourcesPerTick.Add(new ResourceGeneration(generation.Resource, generation.Amount, generation.RemoveResource));
            if (generation.Resource.gameObject.name.Equals("Plastic"))
            {
                Plastic = generation;
            }
            else if(generation.Resource.gameObject.name.Equals("Material"))
            {
                Material = generation;
            }
            else if(generation.Resource.gameObject.name.Equals("CO2"))
            {
                CO2 = generation;
            }
        }

    }

    private void OnTick()
    {
        Efficiency = (100 / MaxWorkers) * CurrentWorkers;

        if(isIncinerating)
        {
            GenerateResource(CO2);
            GenerateResource(Plastic);
        }
        else if(!isIncinerating)
        {
            GenerateResource(Material);
            GenerateResource(Plastic);
        }
    }

    private void GenerateResource(ResourceGeneration generation)
    {
        if (generation.RemoveResource)
        {
            generation.Resource.ReduceAmount(generation.Amount * Efficiency);
        }
        else
        {
            generation.Resource.AddAmount(generation.Amount * Efficiency);
        }
    }

    public int GetWorkSpace()
    {
        return MaxWorkers - CurrentWorkers;
    }

    public void Addworkers(int amount)
    {
        CurrentWorkers += amount;
    }

    public void RemoveWorkers(int amount)
    {
        CurrentWorkers -= amount;
    }
}
