using UnityEngine;
using System.Collections;

public class TrackerEventHandler : MaxstAR.ITrackableEventHandler {

	private ImageTrackableBehaviour imageTrackableBehaviour;

	void Awake()
	{
		imageTrackableBehaviour = GetComponent<ImageTrackableBehaviour>();
		if (imageTrackableBehaviour)
		{
			imageTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	public override void OnTrackSuccess(Vector3 translation, Quaternion orientation, Vector2 size)
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		VideoPlayerBehaviour videoPlayer = GetComponentInChildren<VideoPlayerBehaviour>();

		// Enable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = true;
		}

		// Enable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = true;
		}

		if (videoPlayer != null)
		{
			videoPlayer.ResumeVideo(true);
		}

		transform.position = translation;
		transform.rotation = orientation;
	}

	public override void OnTrackFail()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		VideoPlayerBehaviour videoPlayer = GetComponentInChildren<VideoPlayerBehaviour>();

		// Enable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = false;
		}

		// Enable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = false;
		}

		if (videoPlayer != null)
		{
			videoPlayer.ResumeVideo(false);
		}
	}
}
