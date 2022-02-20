using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwap : MonoBehaviour
{
	public GameObject spiral;
	public GameObject think;

	public Vector2 tempPosition;

	//private void Awake()
	//{
	//	Invoke("SwapTransforms", 0.5f);
	//}

	//public void SwapTransforms()
	//{
	//	float randomTime = Random.Range(0.2f, 1f);

	//	Vector2 tempPosition = spiral.transform.position;
	//	spiral.transform.position = think.transform.position;
	//	think.transform.position = tempPosition;

	//	Invoke("SwapTransforms", randomTime);
	//}
}
