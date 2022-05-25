using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleGenerator : MonoBehaviour {

	public float fireTime = 8f;//0.05f;
	public GameObject stone;

	public int pooledAmount = 1;
	List<GameObject> stones;
	GameObject p;
	Player pScript;

	//private float timeLeft = 7.0f;

	// Use this for initialization
	void Start () {
		p = GameObject.Find ("Player");
		pScript = p.GetComponent<Player> ();

		stones = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate (stone);
			obj.SetActive (false);

			stones.Add (obj);
		}
		InvokeRepeating ("Fire", fireTime, fireTime);
	}
//	void Update(){
//		
//		timeLeft -= Time.deltaTime;
//		if (timeLeft < 0) {
//			timeLeft = 8;
//			for (int i = 0; i < pooledAmount; i++) {
//				GameObject obj = (GameObject)Instantiate (stone);
//				obj.SetActive (false);
//				stones.Add (obj);
//			}
//
//		}
//	}
	
	void Fire(){
		if (pScript.holding != true) {
			for (int i = 0; i < stones.Count; i++) {
				if (!stones [i].activeInHierarchy) {
					stones [i].transform.position = transform.position;
					stones [i].SetActive (true);
					break;
				}
			}
		}
	}
}
