using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour {


	public float yellowScore = 1;
	public float greenScore = 5;
	public float redScore = 15;

	public Text scoreText;
	float score = 0;

	public Camera cannonCam;
	public Camera cannonBallCam;
	FollowCamera followCamera;

	void Start() {
		cannonBallCam.enabled = false;
		
	}

	public void DataLink() {
		string path = Application.dataPath + "/logs.dat";
		string ShotLog = "Shots fired at: " + System.DateTime.Now + ": ";

		if (!File.Exists(path)) {
			File.WriteAllText(path,ShotLog);
			File.AppendAllText(path, scoreText.text);
		}
		else {
			File.AppendAllText(path, ShotLog);
			File.AppendAllText(path, scoreText.text);
		}

	}

	public void ChangeToCannonBall(){
		cannonBallCam.enabled = true;
		followCamera = cannonBallCam.GetComponent<FollowCamera>();
		followCamera.target = GameObject.FindGameObjectWithTag("CannonBall").transform;
		cannonCam.enabled = false;
	}

	public void ChangeToCannon(){
		cannonCam.enabled = true;
		cannonBallCam.enabled = false;
		ResetCannonBallCam();
	}

	public void ResetCannonBallCam(){
		cannonBallCam.transform.position = followCamera.initialPos;
	}


	public void GreenTargetHit() {

		score += greenScore;
		// scoreText.text = "Targets Hit:" + score;
		scoreText.text = "you have hit green\n";
		DataLink();
	}

	public void RedTargetHit() {

		score += redScore;
		// scoreText.text = "Targets Hit:" + score;
		scoreText.text = "you have hit red\n";
		DataLink();
	}

	public void YellowTargetHit() {

		score += yellowScore;
		// scoreText.text = "Targets Hit:" + score;
		scoreText.text = "you have hit yellow\n";
		DataLink();
	}

	public void voidHit() {

		//score += yellowScore;
		// scoreText.text = "Targets Hit:" + score;
		scoreText.text = "you have hit nothing\n";
		DataLink();
	}


	
}
