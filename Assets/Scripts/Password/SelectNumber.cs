using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectNumber : MonoBehaviour
{
    public Text numbertext;
    private int number;
    private int numberText;
    // Start is called before the first frame update
    void Start()
    {
        int.TryParse(numbertext.text, out number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestarNum()
    {
        
        if (number > 0)
        {
            number--;
            UpdateText();
        }
    }

    public void SumarNum()
    {

        if (number < 9)
        {
            number++;
            UpdateText();
        }

    }
    private void UpdateText()
    {
        numbertext.text = number.ToString();
    }
}
