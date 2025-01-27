﻿using UnityEngine;
using System.Collections;

public class mainblue : Photon.MonoBehaviour {

	public ParticleSystem parred;
	public ParticleSystem paryellow;
	public ParticleSystem parblue;
	public ParticleSystem pargreen;
	public PhotonView myPV;
	public GameObject BlueHantei;
	public GameObject Onpu;
	public Camera cameran;
	bool HanabiFlag = false;
	public int score = 0;
	public GameObject pink;
	public GameObject blue;
	public GameObject yellow;
	public float ram;

	// Use this for initialization
	void Start () {

	}
	void OnTriggerStay(Collider other){

		if (Input.GetMouseButtonDown(0)) {
			Ray ray = cameran.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit)){
				GameObject obj = hit.collider.gameObject;

				if(obj == BlueHantei || obj == Onpu){
					//score++;
					Destroy(other.gameObject);
					myPV.RPC("hanabi",PhotonTargets.All);
					myPV.RPC("plus",PhotonTargets.All);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(score == 5){
			blue.SetActive (false);
			pink.SetActive (false);
			yellow.SetActive (true);
		}else if(score == 10){
			blue.SetActive (true);
			pink.SetActive (false);
			yellow.SetActive (false);
		}else if(score == 15){
			blue.SetActive (false);
			pink.SetActive (true);
			yellow.SetActive (false);
		}else if(score == 25){
			blue.SetActive (true);
			pink.SetActive (false);
			yellow.SetActive (true);
		}else if(score == 35){
			blue.SetActive (true);
			pink.SetActive (true);
			yellow.SetActive (true);
		}else if(score == 40){
			blue.SetActive (false);
			pink.SetActive (false);
			yellow.SetActive (false);
			score = 0;
		}
	}

	[RPC]

	void plus(){
		score++;
	}

	[RPC]
	void hanabi(){
		ram = Random.Range (7, 40);
		if(score % 3 == 0){
			paryellow.transform.position = new Vector3 (ram, 10f, -20f);
			paryellow.Play();
		}else if(score % 4 == 0 && score % 3 != 0){
			pargreen.transform.position = new Vector3 (ram, 10f, -20f);
			pargreen.Play();
		}else if(score % 5 == 0 && score % 4 != 0 && score % 3 != 0){
			parred.transform.position = new Vector3 (ram, 10f, -20f);
			parred.Play();
		} else {
			parblue.transform.position = new Vector3 (ram, 10f, -20f);
			parblue.Play();
		}
	}
}