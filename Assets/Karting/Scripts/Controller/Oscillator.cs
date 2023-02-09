using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
	public float amplitude = 1;
	public float speed = 1;

	public float rotationSpeed = 5;

	private Vector3 startingLocalPosition;

	void Start() {

		startingLocalPosition = transform.localPosition;
	}

	void Update() {

		transform.localPosition = startingLocalPosition + Vector3.up * Mathf.Sin(2.0f * Mathf.PI * Time.time * speed) * amplitude;

		transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime, Space.Self);
	}
		
}
