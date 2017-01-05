using UnityEngine;
using System.Collections;

public class ARManager : MaxstAR.IARManager
{
	private bool arStarted = false;

	void Update()
	{
		if (!arStarted)
		{
			base.StartAR();
			arStarted = true;
		}

		base.UpdateTrackerInfo();
	}

	void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			base.StopAR();
			arStarted = false;
		}
	}

	void OnDisable()
	{
		base.StopAR();
	}

	void OnGUI()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
