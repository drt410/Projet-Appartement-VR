using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class LevePersonneController : MonoBehaviour {

	public PlayableDirector plDirector;
	public KeyCode deplacer;

	void OnTriggerStay(Collider other)
	{
		//print ("test");

		if (Input.GetKeyDown (deplacer) || Input.GetKeyDown("t")) 
		{

			plDirector.Play ();
		}
	}
}
