using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAroundSelf : MonoBehaviour {

	public float speed;
	// Update is called once per frame
	void Update () {
		transform.Rotate(this.transform.up * speed * Time.deltaTime );
	}
}
