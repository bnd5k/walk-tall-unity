using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour{

	void Update() {
		Movement();
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
