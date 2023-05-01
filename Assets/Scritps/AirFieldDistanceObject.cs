using System.Collections;
using System.Collections.Generic;
using BezierSolution;
using UnityEngine;

public class AirFieldDistanceObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AirPlane")
        {
            Debug.Log("uçak ara panelde");
            GameController.current.isReturn = true;
            GameController.current.gameStart = false;
            GameController.current.ReturnAirField();
            GameController.current.airPlane.GetComponent<BezierWalkerWithSpeed>().NormalizedT = 0;
        }
    }
}
