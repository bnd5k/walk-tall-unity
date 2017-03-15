using UnityEngine;
using System.Collections;

public class GuardLogic : MonoBehaviour {

	public Transform sightStart, sightEnd;

	public bool spotted = false;
	public bool facingLeft = true;

	public GameObject arrow;

	void Start() 
	{
		Invoke("Patrol", Random.Range(2f, 6f));
	}

	void Update()
	{

		Raycasting();
		Behaviors();
	}

	void Raycasting() 
	{
		// rays are invisible, which is why we use Debug.DrawLine
		Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);
		spotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
		 // linecast common for 2D
		// LayerMask b.s. ensures that spotted only goes true if guard sees player object.


	}

	void Behaviors() 
	{
		if (spotted == true)
		{
			arrow.SetActive(true);
		}
		else
		{
			arrow.SetActive(false);
		}

	}

	void Patrol() {
		facingLeft = !facingLeft; // toggle that shit

		if (facingLeft == true)
		{
			
			transform.localRotation = Quaternion.Euler(0, 0, 0);

		}
		else 
		{
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
	}
}