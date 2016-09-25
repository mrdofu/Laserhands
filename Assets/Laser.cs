using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Leap;


public class Laser : MonoBehaviour {


	LineRenderer laserRenderer;

	void Start () {
		laserRenderer = gameObject.GetComponent<LineRenderer> ();
		laserRenderer.enabled = true;
	}
	
	void Update () {
		
		if (isActiveAndEnabled) {

			// update LaserStart position and direction


			StopCoroutine ("FireLaser");
			StartCoroutine ("FireLaser");
		}
	}

	IEnumerator FireLaser() {
		while (isActiveAndEnabled) {
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;

			laserRenderer.SetPosition (0, ray.origin);
			if (Physics.Raycast (ray, out hit, 100)) {
				laserRenderer.SetPosition (1, hit.point);
				if (hit.rigidbody) {
					hit.rigidbody.AddForceAtPosition (transform.forward * 50, hit.point);
				}
			} else {
				laserRenderer.SetPosition (1, ray.GetPoint (100));
			}
			yield return null;
		}
	}
}
