using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showcase : MonoBehaviour {
    public Vector3 this_Axis;
    public float deg;
    public float time;

    private bool isRotating;
    // Update is called once per frame
    void Update() {
        if (!isRotating) {
            StartCoroutine(RotateAround(this_Axis, deg, time));
        }
    }
    
    IEnumerator RotateAround(Vector3 axis, float degrees, float duration){
        if(axis == Vector3.zero || degrees == 0){
            yield return true;
        }
        isRotating = true;
        float d = 0;
        Quaternion q;
        Quaternion startRot = transform.rotation;
        float progress = 0;    
        while(progress <= 1){
            d = Mathf.Lerp(0, degrees, progress);
            q = Quaternion.AngleAxis(d, axis);
            transform.rotation = startRot*q;
            progress += Time.deltaTime/duration;
            yield return null;
        }
        transform.rotation = startRot*Quaternion.AngleAxis(degrees, axis);
        isRotating = false;
    }
}