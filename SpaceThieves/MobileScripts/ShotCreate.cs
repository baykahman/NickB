using UnityEngine;
using System.Collections;

public class ShotCreate : MonoBehaviour
{
	public Rigidbody2D shotPrefab;
	public Transform shotPoint;
	public Transform shotInstance;
	public Transform crosshair;
	public float speed;
	public float mousey;
	public float mousex;
	public float touchy;
	public float touchx;
	public float mouseLoc;
	public Vector2 mousePosition;
	public float touchLoc;
	public float drag;
	public static int height;
	public float fireRate = 0.1F;
	private float nextFire = 0.0F;
	public AudioClip success;
	public Vector2 velocity;


	
	void Update ()
	{
		mousex = Input.mousePosition.x;
		mousey = Input.mousePosition.y;
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);



		mouseLoc = (mousex - Screen.width/2);

		int i = 1;

		if (Screen.width < 1200) {

		while (i < Input.touchCount){
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				touchx = Input.GetTouch(i).position.x;
				touchy = Input.GetTouch(i).position.y;
				touchLoc = (touchx -Screen.width/2);
				Rigidbody2D shotInstance;

					shotInstance = Instantiate(shotPrefab, shotPoint.position, shotPoint.rotation) as Rigidbody2D;
					//Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				shotInstance.AddForce(shotPoint.up * touchy*.9f);
				shotInstance.AddForce(shotPoint.right * touchLoc*.8f);
				shotInstance.AddTorque(100f);
					
				}
			++i;
			}
		}

		if (Screen.width >= 1200){
		
			if(Input.GetButtonDown("Fire1")&& Time.time > nextFire) 
			{
				//Instantiates a rigid body, the bullet used
				Rigidbody2D shotInstance;
				nextFire = Time.time + fireRate;
				shotInstance = Instantiate(shotPrefab, shotPoint.position, shotPoint.rotation) as Rigidbody2D;

			//Adds the force to the bullet based on the mouse position. This will move the bullet towards the location of the mouse
					shotInstance.AddForce(shotPoint.up * mousey);
					shotInstance.AddForce(shotPoint.right * mouseLoc);
					shotInstance.AddTorque(3f);
					//shotInstance.drag = 1.5f;
			



			//shotInstance.transform.Translate(h, speed, 0);
			//shotInstance.transform.Rotate(h, speed, 0);
			//shotInstance.AddForce(shotDir * speed);
			//Vector2.MoveTowards(shotPoint.position,mouse, 360);
			//shotInstance.rigidbody2D.fixedAngle = shotDir.x;
			//shotInstance.AddForce(shotDir);
			//transform.Translate(mouse);
			//shotInstance.transform.Equals(mouse);
			//print (h);
			//print (v);

		}
				++i;
			}


		if (Screen.width < 1200){
			
			if(Input.GetButtonDown("Fire1")&& Time.time > nextFire) 
			{
				//Instantiates a rigid body, the bullet used
				Rigidbody2D shotInstance;
				nextFire = Time.time + fireRate;
				shotInstance = Instantiate(shotPrefab, shotPoint.position, shotPoint.rotation) as Rigidbody2D;
				
				//Adds the force to the bullet based on the mouse position. This will move the bullet towards the location of the mouse
				//shotInstance.AddForce(shotPoint.up * mousey *.1f);
				shotInstance.AddForce(shotPoint.right * mouseLoc);
				shotInstance.AddForce(shotPoint.up * mousey);
				shotInstance.AddTorque(3f);
				//shotInstance.drag = 1.5f;
				//shotInstance.velocity(400, 400);
				
				
				
				//shotInstance.transform.Translate(h, speed, 0);
				//shotInstance.transform.Rotate(h, speed, 0);
				//shotInstance.AddForce(shotDir * speed);
				//Vector2.MoveTowards(shotPoint.position,mouse, 360);
				//shotInstance.rigidbody2D.fixedAngle = shotDir.x;
				//shotInstance.AddForce(shotDir);
				//transform.Translate(mouse);
				//shotInstance.transform.Equals(mouse);
				//print (h);
				//print (v);
				
			}
		}
	
	} 

	}