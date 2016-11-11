/// <summary>
/// Puzzle config. Take a array of string as input, which will be used to construct the puzzle
/// </summary>
using UnityEngine;
using System.Collections;


public class PuzzleConfig : MonoBehaviour {
	public string[] puzzleWords;
	public static int cellSize;
	public static string randString;
	public static string[] searchWords;//for accessing in searcher
	// Use this for initialization
	void Start () {
		searchWords = puzzleWords;

	
	}

	void Awake(){
		GetPuzzleSize ();
		RandomizeString (puzzleWords);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Sums up the letters of the puzzle words to calculate the size of the cells needed to
	//hold the puzzle
	void GetPuzzleSize()
	{
		//First calculate the total number of letters
		int letterCount = 0;
		foreach (string str in puzzleWords) {
			letterCount += str.Length;
		}

		Debug.Log ("Total letters : " + letterCount.ToString ());

		//For doing a square cell matrix we need to get the square that can hold these cells
		float sqRoot = Mathf.Sqrt((float)letterCount);
		//Extra one cell is added so we have enough room to move blocks around
		cellSize = Mathf.RoundToInt (sqRoot) + 1;

		Debug.Log ("Matrix size : " + cellSize.ToString ());


	}

	//This will shuffle the letters for the puzzle

	void RandomizeString(string[] puzzleStringArray)
	{
		//concatenate the string to make a big string of letters
		string bigstring = "";
		foreach (string str in puzzleStringArray) {
			bigstring += str;
		}

		Debug.Log ("Big string is : " + bigstring);

		//Randomize the string
		//make character array
		System.Random rnd = new System.Random();
		char [] strChars = bigstring.ToCharArray();
		Debug.Log (strChars.Length);
		int i = strChars.Length;
		while (i>1) {
			i--;
			int j = rnd.Next (i+1);
			char val = strChars [j];
			strChars [j] = strChars [i];
			strChars [i] = val;
		}

		randString = new string (strChars);

		Debug.Log ("Randomized String : " + randString);

	}


}
