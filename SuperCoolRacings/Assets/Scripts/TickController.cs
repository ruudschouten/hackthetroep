using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TickController : MonoBehaviour {

    [SerializeField]
    private float ticksPerSecond = 1;
    [SerializeField]
    private bool ticksActive = true;

    public UnityEvent OnTickEvent = new UnityEvent();

    private bool masterEnable = true;

    private IEnumerator tickRoutine;

    public float TicksPerSecond { get { return ticksPerSecond; } set { ticksPerSecond = value; } }

    public bool TicksActive { get { return TicksActive; } set { ticksActive = value; } }

    void Start () {
        tickRoutine = TicksCoroutine();
        StartCoroutine(tickRoutine);
    }

    private IEnumerator TicksCoroutine()
    {
        while (masterEnable)
        {
            if (ticksActive)
            {
                OnTickEvent.Invoke();

                yield return new WaitForSeconds(1 / ticksPerSecond);
            }
            else
            {
                yield return null;
            }
        }
    }

    [ContextMenu("DisableTicks")]
    public void DisableTicks()
    {
        masterEnable = false;
        StopCoroutine(tickRoutine);
    }

    [ContextMenu("RestartTicks")]
    public void RestartTicks()
    {
        masterEnable = true;
        if (tickRoutine != null)
        {
            StopCoroutine(tickRoutine);
        }
        tickRoutine = TicksCoroutine();
        StartCoroutine(tickRoutine);
    }
}
