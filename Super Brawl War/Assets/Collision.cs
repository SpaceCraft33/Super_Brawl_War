using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
	
	public CharacterController Joueur;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Pieds")
		{
			Destroy(Joueur.gameObject);
			print ("Die Bitch !");
		}
	}
	
}
