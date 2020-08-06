using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringMaker : MonoBehaviour
{
	public float rotate = 5f;
	public float maxPos = 0f;
	public float minPos = 30f;
	private Vector3 theNewPos;
	public GameObject blockPrfb;
	private string gettext;
	private char[] myChars;
	private int open_bracket, Close_bracket;
	private bool equal;
	public string[] characters = new string[] { "(", "X", "A", "6", ")" };
    public string[] storeString;
	private int counter,endcount;
	[System.Obsolete]
    void Start()
    {
		tempObject_Store = new int[36];
		CalculateRandomObject(36);

		/// <summary>
		/// generate string.
		/// </summary>
		counter = 0;
		endcount = Random.RandomRange(9, 12);
		storeString = new string[36];
        for (int i = 0; i <= 35; i++)
        {
			equal = false;
			while (equal == false)
			{
				for (int j = 0; j <= Random.RandomRange(9, 15); j++)
				{
					storeString[i] = storeString[i] + characters[Random.RandomRange(0, characters.Length)];
				}
				/// <summary>
				/// generate 12 to 14 string which have pair.In else generate random string.
				/// </summary>
				if (counter != endcount)
				{
					gettext = storeString[i];
					myChars = gettext.ToCharArray();
					for (int n = 0; n < myChars.Length; n++)
					{
						if (myChars[n] == '(')
						{
							open_bracket++;
						}
						else if (myChars[n] == ')')
						{
							Close_bracket++;
						}
						if (n == myChars.Length - 1)
						{
							if (open_bracket == Close_bracket)
							{
								equal = true;
								gettext = "";
								myChars = gettext.ToCharArray();
								Close_bracket = 0;
								open_bracket = 0;
								counter++;
							}
							else
							{
								storeString[i] = "";
								gettext = "";
								myChars = gettext.ToCharArray();
								Close_bracket = 0;
								open_bracket = 0;
							}
						}
					}
				}
				else
				{
					equal = true;
				}
			}
        }

		/// <summary>
		/// spwan block and assign string which already generate.
		/// </summary>
		for (int i = 0; i < storeString.Length; i++)
		{
			float theXPosition = Random.Range(minPos, maxPos);
			float theZPosition = Random.Range(minPos, maxPos);
			theNewPos = new Vector3(theXPosition, 0.5f, theZPosition);
			GameObject tempObj=Instantiate(blockPrfb);
			blockPrfb.transform.position = new Vector3(theXPosition, 1.1f, theZPosition);
			tempObj.transform.GetChild(0).GetComponent<TextMesh>().text = storeString[tempObject_Store[i]];

			// Here you can assign random position of "tempObj"
		}
	}

	/// <summary>
	/// For Generate random number which never repeat.
	/// </summary>
	int temp;
	public int[] tempObject_Store;
	public int[] CalculateRandomObject(int limit)
	{

		int[] result = new int[limit];
		for (int i = 0; i < limit; i++)
		{
			result[i] = -1;
		}
		for (int i = 0; i < limit; i++)
		{

			temp = Random.Range(0, limit);
			if (ContainsObject(result, temp))
			{
				i--;
				continue;
			}
			else
			{
				result[i] = temp;
				tempObject_Store[i] = temp;
			}
		}
		return result;
	}
	public bool ContainsObject(int[] arr, int number)
	{

		for (int i = 0; i < arr.Length; i++)
		{
			if (arr[i] == number)
			{
				return true;
			}
		}
		return false;
	}
}
