using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Water : MonoBehaviour {

    private int debugCO2;

    public float StartHeight;
    public float Maxheight;
    private float currentHeight;

    public float MaxRateMultiplier;
    public float MinRateMultiplier;
    public float BaseRisingRate;
    private float currentRisingRate;

    public GameObject Visual;

    public UnityEvent evt_OnGameOver;

    void Awake()
    {

        currentHeight = StartHeight;
        currentRisingRate = BaseRisingRate;
        ChangeWaterRate(0);
    }

    [ContextMenu("co2 + 20")]
    public void UpCO2()
    {
        debugCO2 += 20;
        ChangeWaterRate(debugCO2);
    }

    [ContextMenu("co2 - 20")]
    public void MinCO2()
    {
        debugCO2 -= 20;
        ChangeWaterRate(debugCO2);
    }

    public void ChangeWaterRate(int co2)
    {
        if(co2 < 21)
        {
            currentRisingRate = 0;
        }
        else if (co2 > 99)
        {

        }
        else
        {
            float difference = MaxRateMultiplier - MinRateMultiplier;


            //Klopt dit?????
            currentRisingRate = MinRateMultiplier + ( difference / 100 * co2);

        }
    }

    void Update()
    {
        currentHeight += BaseRisingRate * currentRisingRate;
        UpdateWaterLevelVisual();

        if (currentHeight >= Maxheight)
        {
            evt_OnGameOver.Invoke();
        }
    }


    void UpdateWaterLevelVisual()
    {
        Visual.transform.position = new Vector3(0,currentHeight,0);
    }

}
