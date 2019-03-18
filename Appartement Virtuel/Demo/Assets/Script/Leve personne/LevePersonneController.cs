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

		if (Input.GetKeyDown (deplacer) || Input.GetKeyDown("t")) {

			plDirector.Play ();
		}
		}
	/*
    public void play()
    {
        foreach (PlayableDirector playableDirector in playableDirectors)
        {
            playableDirector.Play();
        }
    }

    public void playAnimTimeline(int index)
    {
        TimelineAsset selectedAsset;
        if (timelines.Count <= index)
        {
            selectedAsset = timelines[timelines.Count - 1];
        }
        else
        {
            selectedAsset = timelines[index];
        }
        playableDirectors[0].Play(selectedAsset);

    }*/
}
