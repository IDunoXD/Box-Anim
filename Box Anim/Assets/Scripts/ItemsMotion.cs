using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemsMotion : MonoBehaviour
{
    public Transform MoveTo;
    Vector3 StartPosition,StartScale;
    public float RotationSpeed;
    public float MoveTime = 1; //s
    public float GoBackTime = 4; //s
    float BeginTime;
    [SerializeField]
    Animator BoxAnimator;
    MeshRenderer[] mesh;
    void Start()
    {
        StartPosition = transform.position;
        StartScale = transform.localScale;
        BeginTime = Time.time;
        transform.localScale = Vector3.zero;
        mesh = transform.GetComponentsInChildren<MeshRenderer>();
    }
    void Update()
    {   
        if(transform.localScale.x<=10f) //disable mesh if object too small
            for (int i = 0; i < mesh.Length; ++i)
                mesh[i].enabled=false;
        else
            for (int i = 0; i < mesh.Length; ++i)
                mesh[i].enabled=true;
        if(Time.time-BeginTime<MoveTime){ //move to the camera animation
            transform.position = Vector3.Lerp(StartPosition,MoveTo.position,Mathf.Clamp01((Time.time-BeginTime)/MoveTime));
            transform.localScale = Vector3.Lerp(Vector3.zero,StartScale,Mathf.Clamp01((Time.time-BeginTime)/MoveTime));
            //Debug.Log("IN");
        }
        if(Time.time-BeginTime>MoveTime && Time.time-BeginTime<GoBackTime) //follow the camera
            transform.position = MoveTo.position;
        if((Time.time-BeginTime-GoBackTime<MoveTime)&&(Time.time-BeginTime>GoBackTime)){ //move back animation
            transform.position = Vector3.Lerp(MoveTo.position,StartPosition,Mathf.Clamp01((Time.time-BeginTime-GoBackTime)/MoveTime));  
            transform.localScale = Vector3.Lerp(StartScale,Vector3.zero,Mathf.Clamp01((Time.time-BeginTime-GoBackTime)/MoveTime));
            //Debug.Log("OUT");
        }
        transform.Rotate(Vector3.back*RotationSpeed*Time.deltaTime,Space.Self); //rotate all of the time with fixed speed
        if(Time.time-BeginTime>=GoBackTime){BoxAnimator.SetTrigger("SpawnToken");} //go to next animation
    }
}