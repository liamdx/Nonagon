using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class fire : MonoBehaviour {
	[FMODUnity.EventRef]
	public string inputSound;

	public float cameraShakeFactor;
	public float cameraShakeRough;
	public float cameraFadeout;
	public Camera cam;
	public ParticleSystem lightning;
	public float distance;

	public int currentDamage = 2;

	private FMOD_StudioEventEmitter emitter;
	// Update is called once per frame

	void FixedUpdate () {
		if(Input.GetButtonDown("Fire1")){
			lightning.Play();
			shoot();
			FMODUnity.RuntimeManager.PlayOneShot(inputSound,transform.position);
			
		}
		else if(Input.GetButton("Fire1")){
			shoot();
			FMODUnity.RuntimeManager.PlayOneShot(inputSound,transform.position);
			}
		else if(Input.GetButtonUp("Fire1")){
		 	lightning.Stop();
		}
		
	}

	void shoot(){
		RaycastHit hit;
		if(Physics.Raycast(cam.transform.position, cam.transform.forward,out hit, distance)){
			Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.blue, 100f);
			if(hit.collider.tag == "Enemy"){
				hit.collider.GetComponent<health>().doDamage(currentDamage);
				Debug.Log("Did Damage!");
			}
		}
	}
}
