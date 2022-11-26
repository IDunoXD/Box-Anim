using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientMat : MonoBehaviour
{
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    public float TimeShift;
    public float GradientCycleTime=5;
    public Color[] GradientColors;
    Material mat;
    void Start()
    {
        mat=GetComponent<MeshRenderer>().material;
        gradient = new Gradient();
        int colors = GradientColors.Length;
        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[colors];
        alphaKey = new GradientAlphaKey[colors];
        for(int i=0;i<colors;i++){
            colorKey[i].color=GradientColors[i];
            colorKey[i].time=Mathf.InverseLerp(0,colors-1,i);
            alphaKey[0].alpha = 1.0f;
        }

        gradient.SetKeys(colorKey, alphaKey);
        mat.SetColor("_EmissionColor",gradient.Evaluate(0.0f));
    }
    void Update()
    {
        mat.SetColor("_EmissionColor",gradient.Evaluate(((Time.time + TimeShift) % GradientCycleTime)/GradientCycleTime));
    }
}
