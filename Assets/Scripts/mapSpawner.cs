using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapSpawner : MonoBehaviour {

    enum spawnerState {intro, robot};

    spawnerState currentState = spawnerState.intro;
    public int initNumberOfTiles;
    public int objectArrayRangeMin;
    public int objectArrayRangeMax;
    public Vector3[] tileInitPos;
    public Vector3[] tileLastPos;

    private ObjectPooler pooler;
    private Vector3 lastPosition;
    private GameObject[] currentTiles;
    private Vector3[] positions;
    
    //Use two lists
    //one to store gameobject array
    //one to store point array
    //add a new element to the end of the list
    //delete the first element in the list
    //use List.Clear() to delete vacant spaces (e.g. shift array along once to the left);

	// Use this for initialization
	void Awake () {
        tileInitPos = new Vector3[initNumberOfTiles];
        tileLastPos = new Vector3[initNumberOfTiles];
        pooler = GetComponent<ObjectPooler>();
        lastPosition = transform.position; 
        Debug.Log(pooler.pooledObjectsList.Capacity);
        GameObject currentTile;

        /*for(int j = 0; j < pooler.pooledObjectsList.Capacity; j++){
            
        }*/
        for(int i = 0; i < initNumberOfTiles; i++)
        {
            currentTile = pooler.GetPooledObject(0);
            currentTile.transform.position = lastPosition;
            currentTile.SetActive(true);
            lastPosition =  currentTile.GetComponent<tilePiece>().getLastPoint();
            tileInitPos[i] = currentTile.GetComponent<tilePiece>().getFirstPoint();
            tileLastPos[i] = lastPosition;
        }
        
		
    }

    public void generateTiles(int numberOfTilesToGenerate){
        GameObject currentTile;
        if(currentState == spawnerState.intro){
            for(int i = 0; i < numberOfTilesToGenerate; i++)
        {
            currentTile = pooler.GetPooledObject(0);
            currentTile.transform.position = lastPosition;
            currentTile.SetActive(true);
            lastPosition =  currentTile.GetComponent<tilePiece>().getLastPoint();
            tileInitPos[i] = currentTile.GetComponent<tilePiece>().getFirstPoint();
            tileLastPos[i] = lastPosition;
        }
        }
        if(currentState == spawnerState.robot){
            for(int i = 0; i < numberOfTilesToGenerate; i++)
        {
            currentTile = pooler.GetPooledObject((int)Random.Range(objectArrayRangeMin,objectArrayRangeMax));
            currentTile.transform.position = lastPosition;
            currentTile.SetActive(true);
            lastPosition =  currentTile.GetComponent<tilePiece>().getLastPoint();
            tileInitPos[i] = currentTile.GetComponent<tilePiece>().getFirstPoint();
            tileLastPos[i] = lastPosition;
        }
        }
        
        
    }
    private void LateUpdate() {
        if(Input.GetKeyDown(KeyCode.H)){
            generateTiles(getArrayLength());
        }
    }

    public int getArrayLength(){
        return tileLastPos.Length;
    }

    public void centerTransformArray(){

    }
    
}
