﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
	void OnAnimationFinish ()
	{
		Destroy (gameObject);
	}
}
