using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Selectable))]
public class Unit : MonoBehaviour {
    
    public UnityEvent OnTickEvent = new UnityEvent();

    private GameController gameController;

    public void Initialize(GameController gameController)
    {
        this.gameController = gameController;
        this.gameController.TickController.OnTickEvent.AddListener(OnTick);
    }

    void Awake()
    {

    }

    void Start()
    {

    }

    private void OnTick()
    {

    }
}
