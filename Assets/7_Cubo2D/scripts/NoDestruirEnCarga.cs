﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestruirEnCarga : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
    }
}
