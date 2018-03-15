using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locationPassthrough : MonoBehaviour {

	public Vector3 nextLocation;
	private Vector3 prevLocation;

	private void Awake(){
		nextLocation = Vector3.zero;
		prevLocation = Vector3.zero;
	}
	public void setNextLocation(Vector3 nextPosition){
		prevLocation = nextLocation;
		nextLocation = nextPosition;
	}

	public Vector3 getNextLocation(){
		return nextLocation;
	}

	public Vector3 getPreviousLocation(){
		return prevLocation;
	}

}
