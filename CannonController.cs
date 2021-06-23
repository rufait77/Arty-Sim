using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour {

	// Cannon Rotation Variables
	public int speed;
    public float friction;
    public float lerpSpeed;
    float xDegrees;
    float yDegrees;
    Quaternion fromRotation;
    Quaternion toRotation;
    Camera camera;

    // Cannon firing variables
    public GameObject cannonBall;
    
    public Slider slider;
    Rigidbody cannonballRB;
    public Transform shotPos;
    public GameObject explosion;
    public float firePower;
    public float distance;
    public int powerMultiplier = 2000 ;
    public GameObject RT; 
    public GUIStyle style;

    GameManager GM;


	// Use this for initialization
	void Start () {

		camera = Camera.main;
		GM = (GameManager) FindObjectOfType(typeof(GameManager)) ;
		// firePower *= powerMultiplier;
		powerMultiplier = 2000;

        style.fontSize = 30;
		
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit)){
            if(hit.transform.gameObject.tag == "Cannon"){
                    //if(Input.GetMouseButton(0)) {
                            xDegrees -= Input.GetAxis("Mouse Y") * speed * friction;
                            yDegrees -= Input.GetAxis("Mouse X") * speed * friction;
                            fromRotation = transform.rotation;
                            toRotation = Quaternion.Euler(xDegrees, yDegrees ,0);
                            transform.rotation = Quaternion.Lerp(fromRotation,toRotation, Time.deltaTime * lerpSpeed);

                    //}

                
            }

        }

    if (Input.GetMouseButtonDown(1)) {
		FireCannon();
	}

    // if (Input.GetKeyDown(KeyCode.Space)) {
	// 	ScreenshotHandler.TakeScreenshot_Static(500,500);
	// }
    
    // distance = Vector3.Distance(RT.transform.position,GT.transform.position);
    
		
	}

	
	public void FireCannon(){
	    

		// shotPos.rotation = transform.rotation;
		// firePower = 500;
		firePower = slider.value * powerMultiplier ;
		GameObject cannonBallCopy = Instantiate(cannonBall, shotPos.position, transform.rotation) as GameObject;
		cannonballRB = cannonBallCopy.GetComponent<Rigidbody>();
		cannonballRB.AddForce(transform.forward * firePower);

        distance = Vector3.Distance(RT.transform.position,cannonballRB.transform.position);
        
		Instantiate(explosion, shotPos.position, shotPos.rotation);
        
		GM.ChangeToCannonBall();


    }

    private void OnGUI(){
        GUI.Label(new Rect(50,150,200,200),"Deviation: "+ distance, style) ;
    }
}
