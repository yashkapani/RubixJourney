using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	GameObject door;
	public int count;

	public bool collided = false;
	public static string direction = "";
	Vector3 oldpos;
	int totalsteps = 0;
	bool clock = true;
	// Use this for initialization
	void Start () {
		count = 0;
		door = GameObject.Find ("Door");
		door.SetActive(false);
		Physics.gravity = new Vector3 (0, -6, 0);
		oldpos = transform.position;
	}
	bool rotating = false;
	float rotateValue = 0.0f;
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.frameCount % 120 == 0)
			GameObject.Destroy (GameObject.Find ("InstPlane"));


		GameObject h = GameObject.Find(CubeController.active);
		GameObject p = GameObject.Find(CubeController.active + "Plane");

		if (Input.GetKey (KeyCode.D)) {
						gameObject.rigidbody.AddForce (new Vector3 (100, 0, 0) * 5 * Time.deltaTime);
						oldpos = transform.position;
						direction = "r";
				} else if (Input.GetKey (KeyCode.A)) {
						gameObject.rigidbody.AddForce (new Vector3 (-100, 0, 0) * 4 * Time.deltaTime);
						oldpos = transform.position;
						direction = "l";
		} else if (oldpos.y - transform.position.y > 1)
						direction = "d";

		if(Input.GetKeyDown (KeyCode.E) && !rotating)
		{
			//Debug.Log("Space pressed");
			//gameObject.transform.Translate(0,1,0);
			audio.Play();
			rotating = true;
			clock = true;
			Debug.Log("Start time =" + Time.time);
			rotateValue = h.transform.eulerAngles.z;
			//Debug.Log("rotate value = " + rotateValue);
		}
		if(Input.GetKeyDown (KeyCode.Q) && !rotating)
		{
			//Debug.Log("Space pressed");
			//gameObject.transform.Translate(0,1,0);
			audio.Play();
			rotating = true;
			clock = false;
			Debug.Log("Start time =" + Time.time);
			rotateValue = h.transform.eulerAngles.z;
			//Debug.Log("rotate value = " + rotateValue);
		}
		if(Input.GetKeyDown(KeyCode.R))
			Application.LoadLevel("scene1_test");

		if(rotating) {
			if(clock)
				h.transform.RotateAround(p.transform.position , Vector3.forward , 1);
			else
				h.transform.RotateAround(p.transform.position , Vector3.back , 1);
			totalsteps++;
			//transform.rotation = Quaternion.Lerp(h.transform.eulerAngles, h.transform.rotation, Time.time * speed);
			//Debug.Log("current value = " + h.transform.eulerAngles.z );
			if(totalsteps == 90){
				rotating = false;
				totalsteps = 0;
				Debug.Log("End time =" + Time.time);
			}
		}
	
	}
}
