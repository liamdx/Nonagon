using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemies;
	public GameObject player;
	public int numberOfEnemies;

	private ObjectPooler pooler;
	
	private void Awake() {
		pooler = GetComponent<ObjectPooler>();
		enemies = new GameObject[numberOfEnemies];
	}

	private void Start() {
		Vector3 randomOffset = new Vector3(0,0,0);
		EnemyMovement currentMovementProperties;
		for(int i = 0; i < numberOfEnemies; i++){
			enemies[i] = pooler.GetPooledObject(0);
			randomOffset.x = 1+ Random.Range(0,100);
			randomOffset.y = 1+ Random.Range(0,10);
			randomOffset.z = 1+ Random.Range(0,100);
			enemies[i].transform.position = player.transform.position + randomOffset;
			enemies[i].SetActive(true);
			currentMovementProperties = enemies[i].GetComponent<EnemyMovement>();
			currentMovementProperties.SetTarget(player.transform);
			currentMovementProperties.SetRotationalDamp(1f + Random.Range(0f,4f));
			currentMovementProperties.SetMovementSpeed(40f + Random.Range(5f,8f));
			currentMovementProperties.SetRaycastOffset(2.5f + Random.Range(1,4));
		}
	}
}
