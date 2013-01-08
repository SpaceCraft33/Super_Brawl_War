using UnityEngine;
using System.Collections;
 
public class joueur : MonoBehaviour {

		public float SpeedRotate = 500f;
        public float Speed = 20f;
		public GameObject laser;
		public GameObject boom;
		public GameObject gameOver;
	
		public float timer = 1f;
		private float counter;
		private float reaparitionTime=3;
	
	void OnTriggerEnter(Collider other){
		
			if(other.tag == "Asteroid"){
				Destroy(this.gameObject);
				Instantiate(boom, transform.position, transform.rotation);
				Instantiate(gameOver);

				//reaparitionTime=0;
			}
		}
		
	
   
        void Update () {
	
			if(Input.GetKey(KeyCode.UpArrow)) {
				transform.Translate(Vector3.forward * Time.deltaTime*Speed);
		    }
			
			if(Input.GetKey(KeyCode.LeftArrow)){
				transform.Rotate(Vector3.up * Time.deltaTime* (-SpeedRotate));
		    }
	
			if(Input.GetKey(KeyCode.RightArrow)){
				transform.Rotate(Vector3.up * Time.deltaTime * SpeedRotate);
		    }
		
			if (counter<=0 && Input.GetKey (KeyCode.M)){
				counter=timer;
				Instantiate(laser, transform.position, transform.rotation);
			}  
			
			counter -= Time.deltaTime*8;
			
			Vector3 tempPosition = transform.position;
		
			if(transform.position.x<=-15 || transform.position.x>=15){
				tempPosition.x *= -1;
			}
		
			if(transform.position.z<=-20 || transform.position.z>=20){
				tempPosition.z *= -1;
			}
			
		transform.position = tempPosition;
		
		/*if(reaparitionTime<=3){
			reaparitionTime += Time.deltaTime/8;
		}
		if(reaparitionTime>3){
			this.gameObject.renderer.enabled=true;
		}
		print (reaparitionTime);*/
		
		
		
		
		}
}
