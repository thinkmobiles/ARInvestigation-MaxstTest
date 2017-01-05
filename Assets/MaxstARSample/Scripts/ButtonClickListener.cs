using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonClickListener : MonoBehaviour
{
	private CameraBackgroundBehaviour cameraBackgroundBehaviour;

	void Start()
	{
		cameraBackgroundBehaviour = GameObject.FindObjectOfType<CameraBackgroundBehaviour>();
	}

	public void OnLeftButtonClicked()
	{
		Application.LoadLevelAsync("Sample1");
	}

	public void OnRightButtonClicked()
	{
		Application.LoadLevelAsync("Sample2");
	}

	public void OnBackButtonClicked()
	{
		Application.LoadLevelAsync("Home");
	}

	public void OnCameraOnOffClicked()
	{
		if (cameraBackgroundBehaviour.isActiveAndEnabled)
		{
			cameraBackgroundBehaviour.gameObject.SetActive(false);
		}
		else
		{
			cameraBackgroundBehaviour.gameObject.SetActive(true);
		}
	}
}
