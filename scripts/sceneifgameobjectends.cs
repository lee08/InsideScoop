﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class sceneifgameobjectends : MonoBehaviour {
	[System.Serializable]
	public class MyEventType : UnityEvent { }

	bool allActive = true;
	public GameObject[]cond;
	public MyEventType doit;
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
		for (int i = 0; i < cond.Length; i++) {
			if (!cond [i].activeInHierarchy) {
				allActive = false;
				break; 
			}
		}

		if (allActive&&doit!=null) {
			doit.Invoke ();
		}
	}
}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			for (int i = 0; i < cond.Length; i++) {
				if (!cond [i].activeInHierarchy) {
					allActive = false;
					break; 
				}
			}

			if (allActive&&doit!=null) {
				doit.Invoke ();
			}
		}
	}
}
