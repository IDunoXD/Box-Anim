using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PrizeAnimation : MonoBehaviour
{
    public Transform MoveTo;
    Vector3 StartPosition,StartScale;
    public float RotationSpeed;
    public float MoveTime = 1; //s
    public bool GoBack = false;
    bool TriggerOnce = true;
    float BeginTime, GoBackTime=0;
    void Start()
    {
        StartPosition = transform.position;
        StartScale = transform.localScale*2;
        BeginTime = Time.time;
    }
    void Update()
    {   
        if(Time.time-BeginTime<MoveTime){ //move to the camera animation
            transform.position = Vector3.Lerp(StartPosition,MoveTo.position,Time.time-BeginTime);
            transform.localScale = Vector3.Lerp(Vector3.zero,StartScale,Time.time-BeginTime);
            //Debug.Log("IN");
        }
        if(GoBack && TriggerOnce){ //prepare for move back animation
            GoBackTime = Time.time;
            TriggerOnce = false;
        }
        if(GoBack && Time.time-GoBackTime<MoveTime){ //move back animation
            transform.position = Vector3.Lerp(MoveTo.position,StartPosition,Time.time-GoBackTime);
            transform.localScale = Vector3.Lerp(StartScale,Vector3.zero,Time.time-GoBackTime);
        }
        transform.Rotate(Vector3.down*RotationSpeed*Time.deltaTime,Space.Self); //rotate all of the time with fixed speed
    }
}
