using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

	enum spawnerState {intro, robot};
	spawnerState currentState = spawnerState.intro;

	private ObjectPooler pooler;

	private List<GameObject> tiles = new List<GameObject>();
	private List<Vector3> positions = new List<Vector3>();
	private Vector3 lastPosition;
	private tilePiece currentTile;
	public int numberOfTiles;
	private int numberOfPositions;
	private int nextTileIndex; 



	// Use this for initialization
	void Start () {
		numberOfPositions = numberOfTiles * 2;
		pooler = GetComponent<ObjectPooler>();
		int i = 0;
		lastPosition = Vector3.zero;

		while(i < numberOfTiles){
			tiles.Add(pooler.GetPooledObject(0));
			currentTile = tiles[i].GetComponent<tilePiece>();
			positions.Add(currentTile.getFirstPoint());
			positions.Add(currentTile.getLastPoint());
			lastPosition = currentTile.getLastPoint();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void getPositionInRail(){
		tilePiece currentTile;
		for(int i = 0; i < numberOfTiles; i++){
			currentTile = tiles[i].GetComponent<tilePiece>();
			if(currentTile.playerHasBeenThrough == true){
				i++;
			}
			else if(currentTile.playerHasBeenThrough == false){
				return i;
			}
		}
	}
}
