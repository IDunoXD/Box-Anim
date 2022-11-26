using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed=1;
    Material mat;
    void Start()
    {
        mat=GetComponent<MeshRenderer>().material;
    }
    void Update()
    {
        mat.SetTextureOffset("_MainTex",Vector2.up*(0.16f*speed*Time.time));
    }
}
