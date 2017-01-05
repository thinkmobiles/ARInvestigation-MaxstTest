using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntroSceneManager : MonoBehaviour {

	[SerializeField]
	private List<GameObject> dontDestroyObjects = null;

	void Start()
	{
		foreach (GameObject _object in dontDestroyObjects)
		{
			DontDestroyOnLoad(_object);
		}

		StartCoroutine(LoadHomeScene());
	}

	private IEnumerator LoadHomeScene()
	{
		yield return new WaitForSeconds(0.5f);

		Application.LoadLevelAsync("Home");
	}
}
