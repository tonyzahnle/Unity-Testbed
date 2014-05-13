using UnityEngine;
using System.Collections;

public class DebugManager : MonoBehaviour {
	
	bool bDebugMenu = false;
	string version = "v0.1.10q";
	int textHeight = 20;
	int width;
	int height;
	string randomSeed = "";
	int randomSeedInt = -1;
	double fps = 0.0f;
	
	
	
	// List of all the toggles (Coins, Materials, Arrows)
	bool bCoinsToggle, bKatnissToggle, bArrowsToggle;
	
	// List of all the label text for the toggles
	string coinStr = "COINS";
	string arrowStr = "ARROWS";
	string katnissStr = "KATNISS";
	string currentStr = "CHOOSE...";
	
	// List of all the values for each toggle
	int coins = 100;
	int arrows = 3;
	int katniss = 5;
	int current = -1;
	
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 30;
	}
	
	// Update is called once per frame
	void Update () {
		fps = (0.9 * (1.0/Time.deltaTime)) + (0.1 * fps);
	}
	
	void OnGUI () 
	{
		// Declared used variables for GUI
		width = Screen.width - 20; // Give some buffer
		height = Screen.height - 20;
		
		GUI.Label(new Rect(5, height, width, textHeight), version);
		GUI.Label(new Rect(width - 40, height, width, textHeight), fps.ToString());
		
		if(bDebugMenu)
		{
			GUI.Box(new Rect(10, 110, 200, 90), "Test GUI");
			DebugMenu();
		}
		
		if(GUI.Button(new Rect(width - width/4, height - height/10, width/4, height/10), "Open\nDebug"))
		{
			// Toggle the menu
			bDebugMenu = !bDebugMenu;
			// Initialize the seed
			randomSeed = randomSeedInt.ToString();
			Random.seed = randomSeedInt;
		}
	}
	
	void DebugMenu()
	{
		if(bDebugMenu)
		{
			// Toggle logic for adding coins
			bool prev = bCoinsToggle;
			bCoinsToggle = GUI.Toggle(new Rect(0, 0, 100, textHeight), bCoinsToggle, "Coins");
			if(!prev && bCoinsToggle)
			{
				bArrowsToggle = false;
				bKatnissToggle = false;
			}
			
			prev = bArrowsToggle;
			bArrowsToggle = GUI.Toggle(new Rect(0, 20, 100, textHeight), bArrowsToggle, "Arrows");
			if(!prev && bArrowsToggle)
			{
				bCoinsToggle = false;
				bKatnissToggle = false;
			}
			
			prev = bKatnissToggle;
			bKatnissToggle = GUI.Toggle(new Rect(0, 40, 100, textHeight), bKatnissToggle, "Katniss");
			if(!prev && bKatnissToggle)
			{
				bCoinsToggle = false;
				bArrowsToggle = false;
			}
			
			if(bCoinsToggle) { currentStr = coinStr; current = coins; }
			else if(bArrowsToggle) { currentStr = arrowStr; current = arrows; }
			else if(bKatnissToggle) { currentStr = katnissStr; current = katniss; }
			
			GUI.Label(new Rect(100, 0, 100, textHeight), currentStr);
			GUI.Label(new Rect(100, textHeight, 100, textHeight), current.ToString());
			
			if(GUI.Button(new Rect(200, 0, 100, textHeight), "Add 1"))
			{
				DebugAddAmount(1);
			}
			
			if(GUI.Button(new Rect(200, 20, 100, textHeight), "Add 5"))
			{
				DebugAddAmount(5);
			}
			
			if(GUI.Button(new Rect(200, 40, 100, textHeight), "Add 1000"))
			{
				DebugAddAmount(1000);
			}
			
			// Add materials
			
			// Set random seed
			randomSeed = GUI.TextArea(new Rect(20, height/2, width, height/4), randomSeed);
			if(!int.TryParse(randomSeed, out randomSeedInt))
			{
				GUI.Label(new Rect(0, 0, width, textHeight), "Not a valid seed");
				randomSeedInt = 0;
			}
		}
	}
	
	void DebugAddAmount(int amt)
	{
		if(bCoinsToggle) { coins += amt; current = coins; }
		else if(bArrowsToggle) { current = arrows += amt; current = arrows; }
		else if(bKatnissToggle) { current = katniss += amt; current = katniss; }
	}
	
	void LoadVersion()
	{
		
	}
	
	void Log(string str)
	{
		
	}
}
