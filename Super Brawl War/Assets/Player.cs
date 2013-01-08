using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	// Caractéristiques du personnage.
	public float speed = 30.0F;
    public float jumpSpeed = 20.0F;
    public float gravity = 60.0F;
	public float dive_speed = 300.0F;
	public Vector3 GroundDetectorVector;

	
	// Initialisations des contours.
	public KeyCode Left;
	public KeyCode Right;
	public KeyCode Down;
	public KeyCode Jump;
	
	private bool CanJump = true;
	
	
	// Autres
    private Vector3 moveDirection = Vector3.zero;
	
	// On garde la vélocité verticale dans une variable.
	private float vSpeed = 0F; 
	public string destroy_target = "MotherFucker";
	
    void Update()
	{
		
		// On récupère l'objet CharacterController présent sur l'objet ayant ce script.
        CharacterController controller = GetComponent<CharacterController>();
		
		// On bouge même si le Player ne touche pas le sol.
		if(Input.GetKey(Left))
			moveDirection = transform.TransformDirection(new Vector3(-1, 0, 0))*speed;
		
		if(Input.GetKey(Right))
			moveDirection = transform.TransformDirection(new Vector3(1, 0, 0))*speed;
		
		if(Input.GetKey (Down))
		{
			gravity = dive_speed;
		}else
		{
			gravity = 60.0F;
		}
		
		
		
		// S'il touche le sol.
        if (controller.isGrounded)
		{
			// Si le Player est au sol, il n'a aucune vélocité verticale, sauf ...
            vSpeed = 0;	
			
			// ... sauf s'il saute.
            if (Input.GetKeyDown(Jump)) 
                vSpeed = jumpSpeed;
        }
		
		
		// On applique la gravité à la vélocité verticale.
        vSpeed -= gravity * Time.deltaTime; 
		
		// On applique la vélocité verticale au movement verticale ( en Y ) du player.
        moveDirection.y = vSpeed; 
		
		// On bouge le player.
		controller.Move(moveDirection * Time.deltaTime);
		
		// Quand aucun touche n'est appuyée, on arrête le mouvement.
		moveDirection = transform.TransformDirection(new Vector3(0, 0, 0))*speed;
	
    }
	/*
	 // S'il touche le sol.
        if (rayForJumping())
		{
			// Si le Player est au sol, il n'a aucune vélocité verticale, sauf ...
            vSpeed = 0;
			
			// ... sauf s'il saute.
            if (Input.GetKeyDown(Jump) && CanJump == true){
                vSpeed = jumpSpeed;	
				CanJump = false;
			}
        }
        
	bool rayForJumping() {
		bool _b = false;
		
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.position+GroundDetectorVector, out hit)){
			if(hit.collider.tag == "World")
			{
				_b = true;
				CanJump = false;
			}
		}
		return _b;
	}
	
	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(transform.position, transform.position+GroundDetectorVector);
	}
	
	*/
}