using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour{

	public bool interact = false;
	public Transform lineStart, lineEnd;

	RaycastHit2D whatIHit;


	void Update() {
		Movement();
		Raycasting();
	}

	void Raycasting()
	{
		Debug.DrawLine(lineStart.position, lineEnd.position, Color.green);

		if (Physics2D.Linecast(lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer("Guard")))
		{
			Debug.Log("farts");

			whatIHit = Physics2D.Linecast(lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer("Guard"));
			interact = true;

		}
		else 
		{
			Debug.Log("poop");
			interact = false;
		}
		if (Input.GetKeyDown(KeyCode.E) && interact == true) 
		{
			Destroy((whatIHit.collider.gameObject));
		}
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
	}
}
