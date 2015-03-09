using UnityEngine;
using System.Collections;
using System;

public class EulerManager : MonoBehaviour {

	DateTime start;

	// Use this for initialization
	void Start () {
		//ProblemOne();
		//ProblemTwo();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ProblemOne()
	{
		BeginFrame();
		int num = 0;
		for(int i = 1; i < 1000; ++i)
		{
			if(i % 3 == 0 || i % 5 == 0)
			{
				num += i;
			}
		}
		Debug.Log("Problem 1 solution: " + num);
		TimeSpan ts = DateTime.Now.Subtract(start);
		Debug.Log("Time: " + ts.TotalSeconds);
		EndFrame();
	}

	void ProblemTwo()
	{
		BeginFrame();
		int prev = 0, a = 1, b = 2, sum = 2;
		while((a + b) < 4000000)
		{
			if((a + b) % 2 == 0)
			{
				sum += (a + b);
			}
			prev = a;
			a = b;
			b = prev + a;
		}
		Debug.Log("Problem 2 solution: " + sum);
		EndFrame();
	}

	void ProblemThree()
	{
		BeginFrame();

		EndFrame();
	}

	void BeginFrame()
	{
		start = DateTime.Now;
	}

	void EndFrame()
	{
		Debug.Log("Seconds for frame: " + DateTime.Now.Subtract(start).TotalSeconds);
	}
}
