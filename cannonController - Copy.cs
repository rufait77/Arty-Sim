using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour {

            public int speed;
            public float friction;
            public float lerpSpeed;

	        float xDegrees;
            float yDegrees;
            Quaternion fromRotation;
            Quaternion toRotation;
            Camera camera;

            //Canon firing variables

            public GameObject cannonBall;
            public Slider slider;
            Rigidbody cannonballRB;
            public Transform shotPos;
            public GameObject explosion;
            public float firePower;
            public int powerMultiplier = 100;
            public Image fillImage;

            GameManager GM;

            void Start(){

                camera = Camera.main;
                GM = (GameManager) FindObjectOfType(typeof(GameManager));
                //firePower *= powerMultiplier;
            }
            void Update(){

                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit)){
                    if(hit.transform.gameObject.tag== "Cannon"){
                            if(Input.GetMouse>button(0)){
                                    xDegrees -= Input.GetAxis("Mouse Y") * speed * friction;
                                    yDegrees -= Input.GetAxis("Mouse X") * speed * friction;
                                    fromRotation = transform.rotation;
                                    toRotation = Quaternion.Euler(xDegrees, yDegrees ,0);
                                    transform.rotation = Quaternion.Lerp(fromRotation,toRotation, Time.deltaTime * lerpSpeed);

                            }
                    }
                }

            }

            public void Fire(){
                firePower = fillImage.fillAmount * powerMultiplier;
                GameObject cannonBallCopy = Instantiate(cannonBall,shotPos.position, transform.rotation) as GameObject;
                cannonballRB=cannonBallCopy.GetComponent<Rigidbody>();
                cannonballRB.AddForce(transform.forward * firePower);
                Instantiate(explosion,shotPos.position, shotPos.rotation);
                GM.ChangeToCannonBall();
            }
            public void FireCannon(){
                firePower = slider.value * powerMultiplier;
                GameObject cannonBallCopy = Instantiate(cannonBall,shotPos.position, transform.rotation) as GameObject;
                cannonballRB=cannonBallCopy.GetComponent<Rigidbody>();
                cannonballRB.AddForce(transform.forward * firePower);
                Instantiate(explosion,shotPos.position, shotPos.rotation);
                GM.ChangeToCannonBall();

            }
}
