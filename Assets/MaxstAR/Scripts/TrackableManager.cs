using UnityEngine;
using System.Collections;

public class TrackableManager : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		ARManager arManager = GameObject.FindObjectOfType<ARManager>();
		ImageTrackableBehaviour [] imageTrackables = GameObject.FindObjectsOfType<ImageTrackableBehaviour>();
		if (arManager != null)
		{
			arManager.SetTrackables(imageTrackables);
		}
	}
}
