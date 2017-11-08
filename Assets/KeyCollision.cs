using UnityEngine;
using System.Collections;


public class KeyCollision: MonoBehaviour {
	PlayerScript playerComp;
	GameObject door;
	//@script RequireComponent(AudioSource)
	//public var otherClip: AudioClip;
	//public AudioClip Myclip;
	void Start()
	{
		
		playerComp = GameObject.Find("Player").GetComponent<PlayerScript>();
		door = GameObject.Find ("Door");
	}
	
	void OnTriggerEnter(Collider col) {
		//GameObject.Find("Door").SetActive(false);
		
		if(col.collider.name == "Player")
		{
			//var myclip = GameObject.Find("Keysound");
			//AudioSource.PlayClipAtPoint
			//audio.PlayOneShot();
			AudioSource.PlayClipAtPoint(audio.clip, col.transform.position);
			Destroy(gameObject);

			// It is Player
			playerComp.count++;
			if(playerComp.count == 9)
			{	
				
				Debug.Log(door);
				door.SetActive(true);
			}
			
			
		}
	}
}
