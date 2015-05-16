using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingStar : MonoBehaviour {
	public GameObject shootingStar;
	public float lastForce;

	private float checkpointTime = 0, amplitude = 3.25f, omega = 6f, xScalar = 14;

    GameObject cloneStar;
	System.Random r = new System.Random();
	bool isUp = true;
    bool starAlive = false;

	void Update() {
		checkpointTime += Time.deltaTime;
		float x = -10 + xScalar * checkpointTime;
		float y = amplitude*Mathf.Sin (omega*checkpointTime);
		cloneStar.transform.localPosition= new Vector3(x,y,0);
	}
	public void starFactory() {
		cloneStar = Instantiate (shootingStar,new Vector3(-15,(float)(r.NextDouble () * 5 - 5),0), Quaternion.identity) as GameObject;
        starAlive = true;
		cloneStar.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "star";
		checkpointTime = 0;
	}
	public Vector3 destroyStar() {
		Vector3 lastPos = new Vector3 ();
		foreach (GameObject shape in GameObject.FindGameObjectsWithTag("ShootingStar"))
		{
			lastPos = shape.transform.position;
			Object.Destroy(shape);
            starAlive = false;
		}
		return lastPos;
	}
}