using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomText : MonoBehaviour
{
    // Start is called before the first frame update
    private Text thisText;
    int i = 0;
    int RandomP = 0;
    string Str = "";

    void Start()
    {
        thisText = GetComponent<Text>();
    }


    public void CreateRandomStr(int decider)
    {

        string randomStr = "";
        string[] letters = new string[] { "x", "g", "5" };
        int stringLength = Random.Range(9, 15);
        for (int i = 0; i <= stringLength; i++)
        {
            randomStr = randomStr + letters[Random.Range(0, letters.Length)];

        }

    //   print( randomStr);

       

        if (decider == 2)
        {

            var value = randomStr;
            var firstHalf = (int)(value.Length / 2);
            var secondHalf = value.Length - firstHalf;
            var splitPhone = new[]
            {
                value.Substring(0, firstHalf),
                value.Substring(firstHalf, secondHalf)
        };


            string FirstHalfString = splitPhone[0];// Storing first half string into variable string
            

            string inverse = "";
            int Length = 0;

            Length = FirstHalfString.Length - 1;
            while (Length >= 0)
            {
                inverse = inverse + FirstHalfString[Length];
                Length--;
            }

            Str = FirstHalfString + inverse; // concatinating first half string with inverse of first half string to making palndrom
        }
        else
        {
            Str = 
                randomStr;
        }

        thisText.text = Str;
        print(Str);


    }

    void Update()
    {


        RandomP = Random.Range(1, 4);
        if (i == 0)
        {
            CreateRandomStr(RandomP);
            i = 1;
        }
    }




}
