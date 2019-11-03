using UnityEngine;

namespace AudioAnalyzer.FrequencyBeatDetection
{
	public class FreqDeclarateMethods : FreqDeclarateVariables
	{
		public void Spectrum()
		{
			m_Audio.GetSpectrumData(m_SamplesLeft, m_ChannelLeft, m_FFTWindow);
			m_Audio.GetSpectrumData(m_SamplesRight, m_ChannelRight, m_FFTWindow);
		}

		#region fragment energy
		public void FragmentEnergy() 
		{
			float[] buffer = new float[SAMPLES_SIZE];

			for (int i = 0; i < SAMPLES_SIZE; i++) {
				float a = (m_SamplesLeft[i] + m_SamplesRight[i]) / 2;
				buffer[i] = Mathf.Abs(Mathf.Pow(a, 2));
			}

			for (int i = 0; i < FREQUENCY_SIZE; i++) {
				float b = 0;
				for (int j = i * FREQUENCY_SIZE; j < (i + 1) * FREQUENCY_SIZE; j++) {
					b += buffer[i];
				}
				m_Frequency[i] = b / FREQUENCY_SIZE;
			}
		}
		#endregion

		#region fragment energy per second
		void ShiftFragmentEnergy()
		{
			float[,] shift = new float[FREQUENCY_SIZE, HISTORY_FREQUENCY_SIZE];

			for (int i = 0; i < FREQUENCY_SIZE; i++) {
				for (int j = 0; j < HISTORY_FREQUENCY_SIZE - 1; j++) {
					shift[i, j + 1] = m_HistoryFrequency[i, j];
				}
			}
			for (int i = 0; i < FREQUENCY_SIZE; i++) {
				shift[i, 0] = m_Frequency[i];
			}
			for (int i = 0; i < FREQUENCY_SIZE; i++) {
				for (int j = 0; j < HISTORY_FREQUENCY_SIZE; j++) {
					m_HistoryFrequency[i, j] = shift[i, j];
				}
			}
		}

		public void AverageFrequencyEnergy() 
		{
			ShiftFragmentEnergy();
			for (int i = 0; i < FREQUENCY_SIZE; i++) {
				float e = 0;
				for (int j = 0; j < HISTORY_FREQUENCY_SIZE; j++) {
					e += m_HistoryFrequency[i, j];
				}
				m_AverageHistoryFrequency[i] = e / HISTORY_FREQUENCY_SIZE;
			}
		}
		#endregion

		#region beat detection
		public bool BeatDetector(int i)
		{
			bool isBeat = false || m_Frequency[i] > 1.3f * m_AverageHistoryFrequency[i];
			return isBeat;
		}
		#endregion

		#region eq
		public void GraphicEq()
		{
			for (int i = 0; i < FREQUENCY_SIZE; i++) {
				float e = 0;
				for (int j = 0; j < EQ_HISTORY_SIZE; j++) {
					e += m_HistoryFrequency[i, j];
				}
				m_FrequencyEq[i] = e / EQ_HISTORY_SIZE;
			}
		}
		#endregion
	}
}