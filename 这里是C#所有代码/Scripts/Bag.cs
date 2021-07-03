using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{

    public Text one;
    public Text two;
    public Text three;
    public Text four;
    public Text five;
    public Text six;
    public Text seven;
    public Text eight;
    public Text nine;

    void Start()
    {
        //Text sets your text to say this message
        one.text = NewBehaviourScript.one.ToString();
        two.text = NewBehaviourScript.two.ToString();
        three.text = NewBehaviourScript.three.ToString();
        four.text = NewBehaviourScript.four.ToString();
        five.text = NewBehaviourScript.five.ToString();
        six.text = NewBehaviourScript.six.ToString();
        seven.text = NewBehaviourScript.seven.ToString();
        eight.text = NewBehaviourScript.eight.ToString();
        nine.text = NewBehaviourScript.nine.ToString();
    }

    void Update()
    {

    }
}
