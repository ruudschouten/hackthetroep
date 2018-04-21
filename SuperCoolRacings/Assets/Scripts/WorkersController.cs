using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkersController : MonoBehaviour {

    public Resource Workers;

    private List<WorkerSpender> workerSpenders = new List<WorkerSpender>();

    void Start()
    {
        Workers.OnValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged()
    {
        Distributeworkers();
    }

    public void RegisterWorkerSpender(WorkerSpender spender)
    {
        workerSpenders.Add(spender);
    }

    public void RemoveWorkerSpender(WorkerSpender spender)
    {
        workerSpenders.Remove(spender);
    }

    private void Distributeworkers()
    {
        int availableWorkers = Workers.Amount;

        foreach (WorkerSpender spender in workerSpenders)
        {
            if (availableWorkers > 0)
            {
                if (availableWorkers >= spender.RequiredWorkers)
                {
                    availableWorkers -= spender.RequiredWorkers;
                    spender.AssignedWorkers = spender.RequiredWorkers;
                }
                else
                {
                    spender.AssignedWorkers = availableWorkers;
                    availableWorkers = 0;
                }
            }
            else
            {
                spender.AssignedWorkers = 0;
            }
        }

    }
}
