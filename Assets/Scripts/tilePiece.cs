using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilePiece : MonoBehaviour {

	public Transform[] tilePoints;
	private Vector3 lastPoint;
	private Vector3 firstPoint;
	public bool playerIsInTile;

	void start(){
		lastPoint = transform.TransformPoint(tilePoints[tilePoints.Length - 1].position);
		playerHasBeenThrough = false;
	}

	private void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			other.GetComponent<locationPassthrough>().setNextLocation(lastPoint);
			playerHasBeenThrough = true;
		}
	}


	public Vector3 getLastPoint(){
		lastPoint = tilePoints[tilePoints.Length - 1].position;
		return lastPoint;
	}

	public Vector3 getFirstPoint(){
		firstPoint = tilePoints[0].position;
		return firstPoint;
	}
	


	
}
