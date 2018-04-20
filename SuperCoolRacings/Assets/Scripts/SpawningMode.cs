using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionController))]
public class SpawningMode : MonoBehaviour {

    private SelectionController selectionController;

    private UnitFactoryBase factory;
    
    void Awake()
    {
        selectionController = GetComponent<SelectionController>();
    }
    
    void Start () {
        selectionController.SelectedCellEvent.AddListener(SpawnOnCell);
        selectionController.ClickedUIEvent.AddListener(DePrime);
    }

    public void PrimeThisMode(UnitFactoryBase factory)
    {
        this.factory = factory;
    }

    private void SpawnOnCell(Cell cell)
    {
        if (factory != null && !cell.IsOccupied())
        {
            factory.SpawnUnit(cell);
        }

        DePrime();
    }

    private void DePrime()
    {
        factory = null;
    }
}
