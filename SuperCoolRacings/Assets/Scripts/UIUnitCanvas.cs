using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUnitCanvas : MonoBehaviour {

    [SerializeField]
    private Canvas canvas;


    public void EnableCanvas()
    {
        canvas.transform.gameObject.SetActive(true);
    }

    public void DisableCanvas()
    {
        canvas.transform.gameObject.SetActive(false);
    }
}
