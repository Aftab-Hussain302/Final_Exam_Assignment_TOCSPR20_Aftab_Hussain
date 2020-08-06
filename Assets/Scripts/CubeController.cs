using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
public class CubeController : MonoBehaviour
{
    public GameObject theCube;
    public GameObject theSphere;
    public float maxPos= 0f;
    public float minPos = 30f;
    private string createdRandomString;
    private int thestringlength;
    private static int totalPalindromesLength;
    private Vector3 theNewPos;
    public void spawn()
    {
        List<int> palindromeIndexes = new List<int>();
        
        
        setPalindromeIndexes(palindromeIndexes);
        createCubes(palindromeIndexes);
    }

    private void setPalindromeIndexes(List<int> palindromeIndexes)
    {
        int palindromeIndex;
        int i = 0;
        while (i<totalPalindromesLength)
        {
            palindromeIndex = Random.Range(0, 9);
            if (!palindromeIndexes.Contains(palindromeIndex) || palindromeIndexes.Count == 0)
            {
                palindromeIndexes.Add(palindromeIndex);
                i++;
            }
        }
    }
    private void createCubes(List<int> palindromeIndexes)
    {
        Text randomString;
        int cubeNumber = 0;
        while (cubeNumber<10)
        {
            createdRandomString = "";
            float theXPosition = Random.Range(minPos, maxPos);
            float theZPosition = Random.Range(minPos, maxPos);
            theNewPos= new Vector3 (theXPosition,0.5f,theZPosition);
            if (Physics.CheckSphere(theNewPos, 0.36f))
            {
                continue;
            }
            else
            {
                GameObject sphere = Instantiate(theSphere);
                GameObject cube = Instantiate(theCube);
                sphere.name = "Sphere" + cubeNumber;
                cube.name = "Cube" + cubeNumber;
                sphere.transform.position = new Vector3(theXPosition,1.1f,theZPosition);
                cube.transform.position = theNewPos;
                randomString = GameObject.Find("Sphere"+cubeNumber+"/Canvas/Text").GetComponent<Text>();
                string[] characters = new string[] { "X", "A", "6"};
                thestringlength = Random.Range(9, 15);
                if (palindromeIndexes.Contains(cubeNumber))
                {
                    if (thestringlength % 2==0)
                    {
                        for (int j = 0; j < (thestringlength/2); j++)
                        {
                            createdRandomString = createdRandomString + characters[Random.Range(0, characters.Length)];
                        }   
                        createdRandomString = createdRandomString + new string(createdRandomString.Reverse().ToArray());
                       
                    }
                    else
                    {
                        for (int j = 0; j < (thestringlength/2)+1; j++)
                        {
                            createdRandomString = createdRandomString + characters[Random.Range(0, characters.Length)];
                        }

                        for (int i = (createdRandomString.Length - 2);i>=0 ; i--)
                        {
                            createdRandomString += createdRandomString[i].ToString();
                        }
                       
                    }
                }
                else
                {
                    for (int j = 0; j < thestringlength; j++) 
                    {
                        createdRandomString = createdRandomString + characters[Random.Range(0, characters.Length)]; 
                    }   
                }

                randomString.text = createdRandomString;
                cubeNumber++;
            }
        }
    }
    
    public static int _totalPalindromes;
    public static int totalPalindromes
    {
        get
        {
            return _totalPalindromes;
        }
        set
        {
            _totalPalindromes = value;
        }

    }
    
    void Start()
    {
        totalPalindromesLength = Random.Range(3, 10);
        CubeController.totalPalindromes = totalPalindromesLength;
        spawn();
    }
}