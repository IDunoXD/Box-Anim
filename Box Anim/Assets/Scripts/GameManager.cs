using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform MainCamera;
    Vector3 Pos,CameraAngle;
    Quaternion Rot;
    RaycastHit hit;
    [SerializeField]
    Button SpawnBoxButton;
    [SerializeField]
    GameObject Box,Pointer;
    [SerializeField]
    Transform BoxSpawner;
    void Start()
    {
        SpawnBoxButton.onClick.AddListener(Click);
    }
    void Update()
    {
        if(Physics.Raycast(BoxSpawner.position,Vector3.down,out hit,2)){
            Pos=hit.point;
            CameraAngle = MainCamera.forward;
            CameraAngle.y=0;
            Rot=Quaternion.LookRotation(CameraAngle,Vector3.up);
            Pointer.transform.GetComponentInChildren<MeshRenderer>().enabled=true;
            Pointer.transform.position=Pos;
            Pointer.transform.rotation=Rot;
        }else
            Pointer.transform.GetComponentInChildren<MeshRenderer>().enabled=false;
    }
    void Click(){
        if(hit.collider==null) return;
        var box = Instantiate(Box,Pos,Rot);
        box.transform.GetComponentInChildren<ActivateLootBox>().Camera = MainCamera;
    }
}
