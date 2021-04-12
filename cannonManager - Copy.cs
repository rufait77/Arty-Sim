using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour{

    public float lifeTime = 5f;
    public GameObject explosion;
    public float minY = -20f;

    GameManager GM;

    void Start(){

        GM = (GameManager) FindObjectOfType(typeof(GameManager));

    }

    void Update(){

        StatusCheck();
    }

    void StatusCheck(){

        lifeTime -= Time.deltaTime;
        if(lifeTime<0){
            CannonBallDestroy();
        }
        if(transform.position.y < minY){
            CannonBallDestroy();
        }

    }

    void CannonBallDestroy(){
        Instantiate(explosion,transform.position,transform.rotation);
        GM.ChangeToCannon();
        Destroy(this.gameObject);

    }
    void OnCollisionEnter(Collision coll){

        if(coll.gameObject.tag== "GreenTarget"){
            GM.GreenTargetHit();
            CannonBallDestroy();
        }
        if(coll.gameObject.tag== "YellowTarget"){
            GM.YellowTargetHit();
            CannonBallDestroy();
        }
        if(coll.gameObject.tag== "RedTarget"){
            GM.RedTargetHit();
            CannonBallDestroy();
        }

    }
}
