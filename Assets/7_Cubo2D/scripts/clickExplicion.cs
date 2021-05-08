using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickExplicion : MonoBehaviour {

	public GameObject objetivo;
	public float fuerza = 10.0f;
	public float radio = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		/*for (int i = 0; i < Input.touchCount; ++i)
		{
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				Debug.Log ("Explota" + transform.position.ToString ());
				foreach(Rigidbody r in objetivo.GetComponentsInChildren<Rigidbody>()){
					r.AddExplosionForce(10, transform.position, 20, 3.0F);

				}
			}
				//clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
				
		}*/

		/*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			// Get movement of the finger since last frame
			//Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			Debug.Log ("Explota" + transform.position.ToString ());
			// Move object across XY plane
			//transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}*/

		if (Input.GetMouseButtonDown (0)) {

			Vector3 mouse = Input.mousePosition;
			mouse.z = 30;

			Vector3 world = Camera.main.ScreenToWorldPoint(mouse);

			transform.position = world;

			Debug.Log("Pressed left click. world :" + world.ToString() +" mouse " + mouse.ToString());

			foreach(Rigidbody r in objetivo.GetComponentsInChildren<Rigidbody>()){
				
				r.AddExplosionForce(fuerza, world, radio, 3.0F);

			}
		}
			
	}
}
