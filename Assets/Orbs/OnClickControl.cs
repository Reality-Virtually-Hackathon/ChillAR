﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickControl : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
        {
            Debug.Log("clicked!");
        }
	}
}
