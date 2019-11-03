using UnityEngine;

namespace AudioAnalyzer.FrequencyBeatDetection
{
	public class FreqDeclarateVariables : MonoBehaviour
	{
		#region constants
		[Header("Array Size")]
		public int SAMPLES_SIZE = 1024;
		public int FREQUENCY_SIZE = 64;
		public int HISTORY_FREQUENCY_SIZE = 43;  // 6
		public int EQ_HISTORY_SIZE = 5;
		#endregion

		#region public variables
		[Header("FFT Setting")]
		public int m_ChannelRight;
		public int m_ChannelLeft;
		public FFTWindow m_FFTWindow;
		public AudioSource m_Audio;

		[HideInInspector]public float[] m_SamplesLeft;
		[HideInInspector]public float[] m_SamplesRight;

		[Header("Frequency Data")]
		public float[] m_Frequency;
		public float[,] m_HistoryFrequency;
		public float[] m_AverageHistoryFrequency;

		[Header("Graphic EQ")]
		public float[] m_FrequencyEq;
		#endregion

		public void InitializeArryas()
		{
			m_SamplesLeft = new float[SAMPLES_SIZE];
			m_SamplesRight = new float[SAMPLES_SIZE];

			m_Frequency = new float[FREQUENCY_SIZE];
			m_HistoryFrequency = new float[FREQUENCY_SIZE, HISTORY_FREQUENCY_SIZE];
			m_AverageHistoryFrequency = new float[FREQUENCY_SIZE];

			m_FrequencyEq = new float[FREQUENCY_SIZE];
		}
	}
}