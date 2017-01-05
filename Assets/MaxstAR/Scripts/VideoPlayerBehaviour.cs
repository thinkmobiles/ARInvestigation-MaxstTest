using UnityEngine;
using System.Collections;

public class VideoPlayerBehaviour : MaxstAR.IVideoPlayerBehaviour
{
	public void ResumeVideo(bool onOff)
	{
		base.Resume(onOff);
	}
}
