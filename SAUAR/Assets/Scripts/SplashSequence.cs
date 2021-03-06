﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSequence : MonoBehaviour {

	void Start () {
		Screen.orientation = ScreenOrientation.Portrait;
        StartCoroutine(Splash());
	}

	IEnumerator Splash(){
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(1);
	} 
}
