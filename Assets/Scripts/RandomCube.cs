using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class RandomCube : MonoBehaviour
{
   GameObject randomCube;

    Vector3 position;
    static string[] validandnotvalids = new string[100];
    static public System.Random rdom = new System.Random();
    public static Random rdm = new Random();
    private static System.Random newrandom = new System.Random();


    void Start()
    {
        randomCube = GameObject.FindGameObjectWithTag("PickUp");
        string balanced_bracket, not_balanced_bracket;
        int balanced_PickUp = 0;
        int not_balanced_PickUp = 0;
        while (not_balanced_PickUp <= 36)
        {


            not_balanced_bracket = RandomText(rdom.Next(9, 15));
            if (!IsBalanced(not_balanced_bracket))
            {
                
                position = new Vector3(Random.Range(-10, 10f), 0.40f, Random.Range(-10, 10));
                GameObject newobject;
                newobject = Instantiate(randomCube, position, Quaternion.identity);
                newobject.GetComponent<CubeText>().nameLable.text = not_balanced_bracket;
                not_balanced_PickUp++;

            }
        }
        while (balanced_PickUp <= 14)
        {


            balanced_bracket = RandomText(rdom.Next(9, 15));
            if (IsBalanced(balanced_bracket))
            {

                 position = new Vector3(Random.Range(-20, 200f), 0.40f, Random.Range(30, 150));
                GameObject newobject;
                newobject = Instantiate(randomCube, position, Quaternion.identity);
                newobject.GetComponent<CubeText>().nameLable.text = balanced_bracket;
                balanced_PickUp++;

            }
        }
        randomCube.active = false;
    }

    public static string RandomText(int length)
    {
        const string chars = "(XA6)";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[newrandom.Next(s.Length)]).ToArray());
    }

    public static bool IsBalanced(string input)
    {
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>() {
            { '(', ')' },
        };

        Stack<char> brackets = new Stack<char>();

        try
        {
            
            foreach (char c in input)
            {
               
                if (bracketPairs.Keys.Contains(c))
                {
                    
                    brackets.Push(c);
                }
                else
                    
                    if (bracketPairs.Values.Contains(c))
                {
                    
                    if (c == bracketPairs[brackets.First()])
                    {
                        brackets.Pop();
                    }
                    else
                        
                        return false;
                }
                else
                   
                    continue;
            }
        }
        catch
        {
           
            return false;
        }

        
        return brackets.Count() == 0 ? true : false;
    }
}
