using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_BGScroller : MonoBehaviour {
	public float scrollSpeed = 0.5F;
	public Renderer rend;
	public bool stopBg = false;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (stopBg == false) {
			float offset = Time.time * scrollSpeed;
			rend.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
		}
	}

}
