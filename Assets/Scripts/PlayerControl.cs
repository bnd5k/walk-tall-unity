using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour{

	public bool interact = false;
	public bool grounded = false;
	public Transform lineStart, lineEnd, groundedEnd;

	RaycastHit2D whatIHit;


	void Update() {
		Movement();
		Raycasting();
	}

	void Raycasting()
	{
		Debug.DrawLine(lineStart.position, lineEnd.position, Color.green);
		Debug.DrawLine(this.transform.position, groundedEnd.position, Color.green);

		grounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Physics2D.Linecast(lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer("Guard")))
		{
			whatIHit = Physics2D.Linecast(lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer("Guard"));
			interact = true;

		}
		else 
		{
			interact = false;
		}
		if (Input.GetKeyDown(KeyCode.E) && interact == true) 
		{
			Destroy((whatIHit.collider.gameObject));
		}

		Physics2D.IgnoreLayerCollision(8,9);
	}

	void Movement() {
		if(Input.GetKey(KeyCode.D)) 
		{
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}		
		if(Input.GetKey(KeyCode.A)) 
		{
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
			transform.localRotation =  Quaternion.Euler(0, 180, 0);

		}
		if(Input.GetKeyDown(KeyCode.Space) && grounded == true) 
		{
			// FIXME: Jumping not working
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200f);
		}
	}
}
