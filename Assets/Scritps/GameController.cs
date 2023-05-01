using System;
using System.Collections;
using System.Collections.Generic;
using BezierSolution;
using UnityEngine;
using DG.Tweening;

public class GameController : MonoBehaviour
{

    public Transform airPlaneStartPos; //Uçağın pissten ayrıldıktan sonraki konumu
    public Transform airFieldPos; //uçağın pistteki konumu
    public Transform airFieldCamPos; //kameranın pissteki konumu

    public GameObject airPlane;  //uçak objemiz
    public GameObject camera; //kameramız
    public GameObject airPlaneDistanceObject;
    
    public GameObject airFiedlControlPanel; // Canvastaki uçağımızın hareket ve atış kontrolünü tutan panelimiz
    public GameObject airFieldStartPanel; // Canvastaki oyunun başlangıç paneli.
    
    public bool gameStart = false;
    public bool airPlaneMovement;
    public bool isReturn = false;
    public bool atTheAirField;

    public GameObject fieldToAreaBezier;
    public GameObject areaToFieldBezier;

    public BezierSpline fieldToAreaSpline;
    public BezierSpline areaToFieldSpline;
    
    public static GameController current;

    private void Start()
    {
        current = this;
        
        // uçağın başlangıç konumunu ve yönünü belirliyoruz.
        airPlane.transform.position = airFieldPos.position;
        airPlane.transform.rotation = airFieldPos.rotation;

        // kameranın konumunu ve bakış açısını belirtiyoruz.
        camera.transform.position = airFieldCamPos.position;
        camera.transform.rotation = airFieldCamPos.rotation;
        
        // başlangıçta kullanmayacağımız kodları kapatıyoruz.
        airPlane.GetComponent<AirplaneController>().isActive = false;
        airPlane.GetComponent<BezierWalkerWithSpeed>().enabled = false;

        camera.GetComponent<CameraFollow>().enabled = false;
        
        airFiedlControlPanel.SetActive(false);
        airPlaneDistanceObject.SetActive(false);
    }

    public void GameStartButton()
    {
        gameStart = true;
        GameStart();
        airPlane.GetComponent<BezierWalkerWithSpeed>().NormalizedT = 0;
        Debug.Log("oyun başladı");
    }

    public void GameStart()
    {
        var airPlaneBezierSpeed = airPlane.GetComponent<BezierWalkerWithSpeed>();
        
        airPlaneBezierSpeed.spline = fieldToAreaSpline;
        airPlaneBezierSpeed.enabled = true;
        if (airPlaneMovement)
        {
            airPlaneBezierSpeed.enabled = false;
        }
        Invoke("CancelAreaBezier", 2.5f);
        Invoke("AirPlaneSettingOpen", 2.5f);
        
        
        camera.GetComponent<CameraFollow>().enabled = true;
        airFiedlControlPanel.SetActive(true);
        airFieldStartPanel.SetActive(false);
        
        Invoke("ActiveDistancePanel", 3);
       
    }

    public void ReturnAirField()
    {
        AirPlaneSettingClose();

        var airPlaneBezierSpeed = airPlane.GetComponent<BezierWalkerWithSpeed>();

        airPlaneBezierSpeed.spline = areaToFieldSpline;
        airPlaneBezierSpeed.enabled = true;
        camera.GetComponent<CameraFollow>().enabled = false;
        
        camera.transform.DOMove(airFieldCamPos.position,3);
        camera.transform.DORotateQuaternion(airFieldCamPos.rotation, 3);

        airPlane.transform.rotation = airFieldPos.rotation;
        
        airFiedlControlPanel.SetActive(false); 
        airFieldStartPanel.SetActive(true);
        
        airPlaneDistanceObject.SetActive(false);
    }

    public void ActiveDistancePanel()
    {
        airPlaneDistanceObject.SetActive(true);
    }

    public void AirPlaneSettingOpen()
    {
        airPlaneMovement = true; 
        airPlane.GetComponent<AirplaneController>().isActive = true;
        airPlane.GetComponent<BezierWalkerWithSpeed>().enabled = false;
        airPlane.GetComponent<FireController>().enabled = true;
    }

    public void AirPlaneSettingClose()
    {
        airPlaneMovement = false; 
        airPlane.GetComponent<AirplaneController>().isActive = false;
        airPlane.GetComponent<FireController>().enabled = false;
    }

    public void CancelAreaBezier()
    {
        airPlane.GetComponent<BezierWalkerWithSpeed>().enabled = false;
        airPlane.GetComponent<AirplaneController>().isActive = true;
        
        fieldToAreaBezier.SetActive(false);
    }
    
}
