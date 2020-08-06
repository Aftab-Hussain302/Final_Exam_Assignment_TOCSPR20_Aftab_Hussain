using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class SpawnCube : MonoBehaviour
{
    public GameObject IcyCube;
    public Vector3 SpawnAxis;
    public int LengthOfPalindrome;
    public int LengthOfString;
    public string RandomString;

    // Start is called before the first frame update
    void Start()
    {
        LengthOfPalindrome = Random.Range(3, 10);
        GetSetValue = LengthOfPalindrome;
        SpawnCubes();
    }

    public void SpawnCubes()
    {
        List<int> listOfPalindrome = new List<int>();
        int randomNumber;
        Text CubeText;
        for (int i = 0; i < LengthOfPalindrome; i++)
        {
            randomNumber = Random.Range(0, 9);
            if (!listOfPalindrome.Contains(randomNumber) || listOfPalindrome.Count == 0)
            {
                listOfPalindrome.Add(randomNumber);
            }
            else
            {
                LengthOfPalindrome = LengthOfPalindrome + 1;
            }
        }

        for (int i = 0; i < 10; i++)
        {
            RandomString = "";
            //Assign Random position
            var spawnLocation = new Vector3(Random.Range(-SpawnAxis.x, SpawnAxis.x), SpawnAxis.y, Random.Range(-SpawnAxis.z, SpawnAxis.z));

            GameObject cube = Instantiate(IcyCube);

            cube.tag = "IcyCube";
            cube.name = "IcyCube" + i;
            cube.transform.position = spawnLocation;

            CubeText = GameObject.Find("IcyCube" + i + "/Canvas/CubeText").GetComponent<Text>();
            string[] characters = new string[] { "x", "H", "8" };
            LengthOfString = Random.Range(9, 15);
            if (listOfPalindrome.Contains(i))
            {
                for (int j = 0; j < LengthOfString / 2; j++)
                {
                    RandomString = RandomString + characters[Random.Range(0, characters.Length)];
                }
                RandomString = RandomString + new string(RandomString.Reverse().ToArray());
            }
            else
            {
                for (int j = 0; j < LengthOfString; j++)
                {
                    RandomString = RandomString + characters[Random.Range(0, characters.Length)];
                }
            }
            CubeText.text = RandomString;
        }
    }
    public static int getSetValue;
    public static int GetSetValue
    {
        get
        {
            return getSetValue;
        }
        set
        {
            getSetValue = value;
        }
    }

}