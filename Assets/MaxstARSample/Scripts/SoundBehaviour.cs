using UnityEngine;
using System.Collections;

public class SoundBehaviour : MonoBehaviour {
	[SerializeField]
	GameObject particlObj = null;

	AudioSource audioSource;
	Animator animator;

	bool childEnabled;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Renderer render in GetComponentsInChildren<Renderer>()) {
			childEnabled = render.enabled;
		}

		if (childEnabled) {
			if (!animator.GetBool("Open")) {
				animator.SetBool("Open", true);
			}

			if (!audioSource.isPlaying) {
				audioSource.Play();
			}

			particlObj.SetActive(true);
		} else {
			if (animator.GetBool("Open")) {
				animator.SetBool("Open", false);
			}

			if (audioSource.isPlaying) {
				audioSource.Pause();
			}

			particlObj.SetActive(false);
		}
	}

	IEnumerator StartSound() {

		yield return null;
	}
}
