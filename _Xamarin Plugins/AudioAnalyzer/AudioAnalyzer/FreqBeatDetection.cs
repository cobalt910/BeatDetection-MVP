using UnityEngine;

namespace AudioAnalyzer.FrequencyBeatDetection
{
	[RequireComponent(typeof(AudioSource))]
	public class FreqBeatDetection : FreqDeclarateMethods
	{
		public virtual void Awake()
		{
			InitializeArryas();
		}

		public virtual void Update()
		{
			Spectrum();
			FragmentEnergy();
			AverageFrequencyEnergy();
			GraphicEq();
		}
	}
}