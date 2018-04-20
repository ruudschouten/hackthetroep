using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourceGenerator))]
public class RecyclingCenter : MonoBehaviour
{
    
    public ResourceGenerator resourceGenerator;
    public Resource Plastic;
    public Resource Material;
    public Resource CO2;
    public bool isRecycling;
    public int RecyclePlasticUsage;
    public int MaterialProduction;
    public int CO2Production;
    public int BurnPlasticUsage;
    public int RequiredWorkers;
    public int CurrentWorkers;

    public void NextTurn()
    {
        int Effectiveness = (100/ RequiredWorkers) * CurrentWorkers;

        if (isRecycling)
        {
            Plastic.ReduceAmount(RecyclePlasticUsage);
            Material.AddAmount(MaterialProduction);
        }
        else
        {
            Plastic.ReduceAmount(BurnPlasticUsage);
            CO2.AddAmount(CO2Production);
        }
         
    }

    public int GetFreeSpaces()
    {
        return RequiredWorkers - CurrentWorkers;
    }

    public int GetWorkerAmount()
    {
        return CurrentWorkers;
    }

    public void Addworker(int amount)
    {
        CurrentWorkers += amount;
    }

    public void RemoveWorker(int amount)
    {
        CurrentWorkers -= amount;
    }

}
