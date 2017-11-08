using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {
	static bool rotate = false;
	public GameObject GameCube;
	string colliderhit = "0";
	Collider spawnpos;
	static public int drotcount = 0;
	static public int lrotcount = 0;
	static public int rrotcount = 0;
	static public int urotcount = 0;

	static public string active = "front";
	static public string rotdir = "";
	static public string dir = "";
	Collider oldcollider;
	int totalsteps = 0;
	// Use this for initialization
	void Start () {
		rotate = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (rotate)
		{
			if(totalsteps == 0)
				rotdir = PlayerScript.direction;
			if(string.Compare(rotdir, "d") == 0)
			{
				GameCube.transform.RotateAround (GameObject.Find ("Center").transform.position, Vector3.right, 1);
				totalsteps++;
				if(totalsteps == 90)
				{
					dir = "";
					rotate = false;
					totalsteps = 0;
					active = spawnpos.transform.parent.gameObject.name;
					transform.parent = GameObject.Find(active).transform;
					renderer.enabled = true;
					rigidbody.useGravity = true;
					transform.position = new Vector3(spawnpos.transform.position.x, spawnpos.transform.position.y - 1, spawnpos.transform.position.z);
				}
			}
			else if(string.Compare(rotdir, "l") == 0)
			{
				GameCube.transform.RotateAround (GameObject.Find ("Center").transform.position, Vector3.down, 1);
				totalsteps++;
				if(totalsteps == 90)
				{
					rotate = false;
					totalsteps = 0;
					rotdir = "";
					active = spawnpos.transform.parent.gameObject.name;
					transform.parent = GameObject.Find(active).transform;
					renderer.enabled = true;
					rigidbody.useGravity = true;
					transform.position = new Vector3(spawnpos.transform.position.x - 1, spawnpos.transform.position.y, spawnpos.transform.position.z);
				}

			}
			else if(string.Compare(rotdir, "r") == 0)
			{
				GameCube.transform.RotateAround (GameObject.Find ("Center").transform.position, Vector3.up, 1);
				totalsteps++;
				if(totalsteps == 90)
				{
					rotate = false;
					rotdir = "";
					totalsteps = 0;
					active = spawnpos.transform.parent.gameObject.name;
					transform.parent = GameObject.Find(active).transform;
					renderer.enabled = true;
					rigidbody.useGravity = true;
					transform.position = new Vector3(spawnpos.transform.position.x + 1, spawnpos.transform.position.y, spawnpos.transform.position.z);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (string.Compare (other.tag.Substring (6, 1), colliderhit) == 0 && colliderhit.Length != 0 && string.Compare (other.tag.Substring (0, 6), "Portal") == 0) 
		{
			rotate = true;
			spawnpos = other;
			string firstparent = oldcollider.transform.parent.gameObject.name;
			string secondparent = other.transform.parent.gameObject.name;
			SetRotationDirection(other, oldcollider);
			print (other.transform.position + "   " + other.transform.localPosition);
			colliderhit = "";
			renderer.enabled = false;
			rigidbody.useGravity = false;
		}
		else 
		{
			oldcollider = other;
			colliderhit = other.tag.Substring (6, 1);
		}
	}

	void SetRotationDirection(Collider p1, Collider p2)
	{
		if (p1.transform.localPosition.y < p2.transform.localPosition.y)
						PlayerScript.direction = "d";
		else if (p1.transform.localPosition.x < p2.transform.localPosition.x)
			PlayerScript.direction = "l";
		else if (p1.transform.localPosition.x > p2.transform.localPosition.x)
			PlayerScript.direction = "r";
	}
}
