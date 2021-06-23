using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;

public class StartPage : MonoBehaviour {

	
	public void StartButton()
    {
		Application.LoadLevel("Login Menu");
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Return))
        {
			StartButton();
        }
		
	}
}
