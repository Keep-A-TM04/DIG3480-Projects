using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour {

    public float speed = 2.5f;
    public float min = 2f;
    public float max = 3f;

    // Use this for initialization
    void Start () {
        min = transform.position.z;
        max = transform.position.z + 4;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3 (transform.position.x, transform.position.y, Mathf.PingPong(Time.time * 2, max - min) + min);
	}
}
