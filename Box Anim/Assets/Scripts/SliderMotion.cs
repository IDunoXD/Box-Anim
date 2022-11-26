using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SliderMotion : MonoBehaviour
{
    public Transform MoveTo;
    Vector3 StartPosition,StartScale;
    public float MoveTime = 1; //s
    public float GoBackTime = 4; //s
    float BeginTime;
    MeshRenderer mesh;
    void Start()
    {
        StartPosition = transform.position;
        StartScale = transform.localScale;
        BeginTime = Time.time;
        transform.localScale = Vector3.zero;
        mesh = transform.GetComponent<MeshRenderer>();
    }
    void Update()
    {   
        if(transform.localScale.x<=0) //disable mesh if object too small
                mesh.enabled=false;
        else
                mesh.enabled=true;
        if(Time.time-BeginTime<MoveTime){ //move to the end position animation
            transform.position = Vector3.Lerp(StartPosition,MoveTo.position,Mathf.Clamp01((Time.time-BeginTime)/MoveTime));
            transform.localScale = Vector3.Lerp(Vector3.zero,StartScale,Mathf.Clamp01((Time.time-BeginTime)/MoveTime));
            //Debug.Log("IN");
        }
        if(Time.time-BeginTime>MoveTime && Time.time-BeginTime<GoBackTime) //follow the end position
            transform.position = MoveTo.position;
        if((Time.time-BeginTime-GoBackTime<MoveTime)&&(Time.time-BeginTime>GoBackTime)){ //move back animation
            transform.position = Vector3.Lerp(MoveTo.position,StartPosition,Mathf.Clamp01((Time.time-BeginTime-GoBackTime)/MoveTime));  
            transform.localScale = Vector3.Lerp(StartScale,Vector3.zero,Mathf.Clamp01((Time.time-BeginTime-GoBackTime)/MoveTime));
            //Debug.Log("OUT");
        }
    }
}