using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour {

	enum moveState {rail, manual}

	moveState state;

	private Vector3 target;
	public Vector3[] locations;
	public mapSpawner MapSpawner;
	public float speed;
	private int index = 0;
	private int initIndex = 0;
	private int lastIndex = 0;

   	 
	void Start(){

		state = moveState.rail;

		if(state == moveState.rail){
			if(target == null){
			target = MapSpawner.gameObject.transform.position;
		}
		}
		
	}

   	 void Update() {

			if(state == moveState.rail){
				if(target == null){
					target = MapSpawner.tileInitPos[initIndex];
					initIndex += 1;
				}
      			float step = speed * Time.deltaTime;
      			transform.position = Vector3.MoveTowards(transform.position, target, step);
			}
			if(state == moveState.manual){
				float step = speed * Time.deltaTime;
      			transform.position = Vector3.MoveTowards(transform.position, target, step);
			}		
   	 }

   	 private void LateUpdate() {

		if(state == moveState.rail){
			if(initIndex >= MapSpawner.getArrayLength() - 1){
				resetIndex();
				MapSpawner.generateTiles(MapSpawner.getArrayLength());
			}
			if(transform.position == target){
				if(initIndex > lastIndex){
					target = MapSpawner.tileLastPos[lastIndex];
					lastIndex += 1;
				}
				else if(initIndex == lastIndex){
					target = MapSpawner.tileInitPos[initIndex];
					initIndex += 1;
				}
			index += 1;
			target = MapSpawner.tileLastPos[index];
		}
		}
		}
	

	
	private void resetIndex(){
		initIndex = 0;
		lastIndex = 0;
	}


	}

