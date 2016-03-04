using UnityEngine;
using System.Collections;



public class ShotDestroy : MonoBehaviour {

	public GameObject Explosion;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy")
			Instantiate(Explosion, transform.position, new Quaternion());
			Destroy(gameObject, .1f);
		
	}
}
