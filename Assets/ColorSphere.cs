using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSphere : MonoBehaviour {
    Renderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject main = GameObject.FindGameObjectWithTag("MainCamera");
        Color currColor = main.GetComponent<Renderer>().material.GetColor("_Color");
        rend.material.SetColor("_Color", Color.Lerp(rend.material.color, RotateTrigger.currColor, Time.deltaTime * 2f));
    }
}
