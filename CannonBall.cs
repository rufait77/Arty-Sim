using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {


	public float lifeTime = 5f;
	public GameObject explosion;
	public float minY = -20f;
	public float distance;
	public GameObject RT;

	GameManager gameManager;

	// Use this for initialization
	void Start () {
		
		gameManager = (GameManager) FindObjectOfType(typeof(GameManager)) ;
	}
	
	// Update is called once per frame
	void Update () {

		StatusCheck();
	}

		

	void StatusCheck() {

		lifeTime -= Time.deltaTime;

		if (lifeTime < 0){

			CannonBallDestroy();
		}

		if (transform.position.y < minY){


			CannonBallDestroy();
		}

		
	}

	void CannonBallDestroy() {

		Instantiate(explosion, transform.position, transform.rotation);
		
		
		Destroy(this.gameObject);
		gameManager.ChangeToCannon();

	}


	void OnCollisionEnter (Collision coll) {


		// ScreenshotHandler.TakeScreenshot_Static(2048,2048);


		if (coll.gameObject.tag == "GreenTarget"){

			gameManager.GreenTargetHit();
			CannonBallDestroy();

		}

		if (coll.gameObject.tag == "RedTarget"){

			gameManager.RedTargetHit();
			CannonBallDestroy();
		}

		if (coll.gameObject.tag == "YellowTarget") {

			gameManager.YellowTargetHit ();
			CannonBallDestroy ();
		} 
		else 
		{
			gameManager.voidHit ();
			CannonBallDestroy();


		}


		CannonBallDestroy();


	}


}
