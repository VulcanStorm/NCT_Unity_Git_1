using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public int spawnNumber;
	Vector3 spawnPos = Vector3.zero;
	GameObject newEnemyObj;
	public GameObject baseEnemy;
	Enemy newEnemy;
	// Use this for initialization
	void Start () {
		SpawnEnemies (spawnNumber);
	}
	
	void SpawnEnemies (int numOfEnemies){
		float colourNum = 0;
		for(int i=0;i<numOfEnemies;i++){
			colourNum = (1/numOfEnemies);
			spawnPos.x ++;
			newEnemyObj = (GameObject)Instantiate(baseEnemy,spawnPos,Quaternion.identity);
			newEnemy = newEnemyObj.GetComponent<Enemy>();
			newEnemy.enemyNum = colourNum;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
