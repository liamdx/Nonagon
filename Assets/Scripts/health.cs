using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {

	public int startHealth;
	public int currentHealth;

	private void Start(){
		currentHealth = startHealth;
	}
	private void LateUpdate() {
		if (currentHealth <= 0){
			this.gameObject.SetActive(false);
		}
	}

	public void doDamage(int dmg){
		currentHealth -= dmg;
	}

	public int getHealth(){
		return currentHealth;
	}

	public void addHealth(int add){
		currentHealth += add;
	}

	public void setHealth(int newHealth){
		currentHealth = newHealth;
	}
}
