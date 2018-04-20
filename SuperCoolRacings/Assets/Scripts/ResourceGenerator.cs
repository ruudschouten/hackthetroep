using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Unit))]
public class ResourceGenerator : MonoBehaviour {

    [SerializeField]
    private List<ResourceGeneration> ResourcesPerTick;

    private Unit unit;


    void Awake()
    {
        unit = GetComponent<Unit>();
    }

    public void Initialize(ResourceGenerator generator, GameController gameController)
    {
        unit.Initialize(gameController);
        unit.OnTickEvent.AddListener(OnTick);

        foreach (ResourceGeneration generation in generator.ResourcesPerTick)
        {
            ResourcesPerTick.Add(new ResourceGeneration(generation.Resource, generation.Amount));
        }

    }

    public void OnTick()
    {
        foreach (ResourceGeneration generation in ResourcesPerTick)
        {
            GenerateResource(generation);
        }
    }

    private void GenerateResource(ResourceGeneration generation)
    {
        generation.Resource.AddAmount(generation.Amount);
    }

    
}

[System.Serializable]
public class ResourceGeneration
{
    public Resource Resource;
    public int Amount;

    public ResourceGeneration(Resource resource, int amount)
    {
        Resource = resource;
        Amount = amount;
    }
}
