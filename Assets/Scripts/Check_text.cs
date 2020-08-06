using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Check_text : MonoBehaviour
{
    public string gettext;
    public char[] myChars;
    public int open_bracket, Close_bracket;
    void Start()
    {
        gettext = GetComponent<TextMesh>().text;
        myChars = gettext.ToCharArray();
       
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            search_Char();
        }
    }
    void search_Char()
    {
        //int asciiCode = System.Convert.ToInt32(')');
        //Debug.Log(asciiCode);
        for(int i = 0; i < myChars.Length; i++)
        {
            if (myChars[i] == '(')
            {
                open_bracket++;
            }else if (myChars[i] == ')')
            {
                Close_bracket++;
            }
        }
            if (open_bracket == Close_bracket)
            {
                print("equal");
            }
            else
            {
                print("Notequal");
            }
        }
    }
