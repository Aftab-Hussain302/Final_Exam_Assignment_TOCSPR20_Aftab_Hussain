using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BracketPlayerController : MonoBehaviour
{
    //movement speed in units per second
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        string getText = other.gameObject.GetComponent<CubeText>().nameLable.text.ToString();
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (IsBalanced(getText) == true)
            {
                other.gameObject.SetActive(false);
                count++;
                SetCountText();
            }

        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count == 15)
        {
            winText.text = "Player hits all the balanced bracket strings";
        }
       

    }

    static public bool IsBalanced(string getText)
    {
        /*******************************************************************
         * The easiest way to check for balanced bracketing is to start    *
         * counting left to right adding one for each opening bracket, '(' *
         * and subtracting 1 for every closing bracket, ')'.  At the end   *
         * the sum total should be zero and at no time should the count    *
         * fall below zero.                                                *
         *                                                                 *
         *  The bracket counting variable is an unsigned   *
         * integer and we trap an overflow exception.  This happens if the *
         * unsigned variable ever goes negative.  This allows us to abort  *
         * at the very first imbalance rather than wasting time checking   *
         * the rest of the characters in the string.                       *
         *                                                                 *
         * At the end all we have to do is check to see if the count       *
         * is equal to zero for a "balanced" result.                       *
         *                                                                 *
         *******************************************************************/
        const char L_Parenthesis = '(';
        const char R_Parenthesis = ')';
        uint Count = 0;

        try
        {
            checked  // Turns on overflow checking.
            {
                for (int Index = 0; Index < getText.Length; Index++)
                {
                    switch (getText[Index])
                    {
                        case L_Parenthesis:
                            Count++;
                            continue;
                        case R_Parenthesis:
                            Count--;
                            continue;
                        default:
                            continue;
                    }  // end of switch()

                }
            }
        }

        catch (OverflowException)
        {
            return false;
        }
        if (Count == 0)
        {
            return true;
        }
        return false;
    }
}