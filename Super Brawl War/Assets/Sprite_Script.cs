using UnityEngine;
using System.Collections;

public class Sprite_Script : MonoBehaviour {
	
	public Texture2D normal;
	public Texture2D saut;
	public Texture2D atterissage;
	
	public KeyCode Jump;
	public KeyCode Down;
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey(Jump))
		{
			renderer.material.mainTexture = saut;
		}
		else if (Input.GetKey(Down)){
			renderer.material.mainTexture = atterissage;}
		else{
			renderer.material.mainTexture = normal;
		}



		
	}
}
