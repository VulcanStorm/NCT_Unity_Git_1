using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public Material baseMat;
	public float enemyNum = 0;
	MeshRenderer thisRenderer;
	Material skin;
	// Use this for initialization
	void Start () {
	thisRenderer = (MeshRenderer)this.renderer;
	skin = new Material(baseMat);
	skin.color = new Color(enemyNum,enemyNum,enemyNum);
	thisRenderer.material = skin;
	
	}
	public void SetNum(float num){
		enemyNum = num;
	}
}
