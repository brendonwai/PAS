using UnityEngine;
using System.Collections;

public class DeleteShape : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		Object.Destroy(other.gameObject);
	}
}
