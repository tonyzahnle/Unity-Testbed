using UnityEngine;
using System.Collections;

public class AudioAnalyzer : MonoBehaviour {

	public AudioClip TestClip;

	// Use this for initialization
	void Start () {
		Debug.Log("AudioAnalyzer Start()");
		if(TestClip != null)
		{
			AnalyzeAudio(TestClip);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AnalyzeAudio(AudioClip clip)
	{
		System.DateTime startTime = System.DateTime.Now;
		Debug.Log("START Analyze Time == " + startTime.ToLongTimeString());
		Debug.Log("Frequency: " + clip.frequency + ", Samples: " + clip.samples 
		          + ", Channels: " + clip.channels + ", Length: " + clip.length);
		Debug.Log("Getting data from first second...");
		float[] samples = new float[clip.frequency * clip.channels]; // One second (f * channels)
		clip.GetData(samples, 0);
		Debug.Log("Data: \n" + LogAudioData(samples, clip.channels));
		System.DateTime endTime = System.DateTime.Now;
		Debug.Log("END Analyze Time == " + endTime.ToLongTimeString() + " - Total Seconds: " + endTime.Subtract(startTime).TotalSeconds);
	}

	void AnalyzeAudio(AudioSource source)
	{
		//source.
	}

	string LogAudioData(float[] arr, int channels, int length = 0)
	{
		string ret = "";
		for(int i = 0, imax = (length > 0 ? length : arr.Length); i < imax; ++i)
		{
			if(i % channels == 0)
			{
				ret += arr[i].ToString() + "  --  ";
			}
			else
			{
				ret += arr[i].ToString() + "\n";
			}
		}
		return ret;
	}
}
