using UnityEngine;
using System.Collections;

public class Kunai : MonoBehaviour {

	Rigidbody2D _rigidbody;
	float _speed = 25f;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_rigidbody.velocity = new Vector2 (_speed, _rigidbody.velocity.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixUpdate()
	{
	}
}
