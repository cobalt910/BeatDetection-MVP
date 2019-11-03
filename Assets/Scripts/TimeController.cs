using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour 
{
	[Range(0, 1)]
	public float m_TimeScale;

	AudioSource _audio;

	void Update () {
		Time.timeScale = m_TimeScale;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}
}
