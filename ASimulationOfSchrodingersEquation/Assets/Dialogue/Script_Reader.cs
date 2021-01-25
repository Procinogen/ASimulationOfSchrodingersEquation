using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Reader : MonoBehaviour
{

    public TextAsset scriptObject; //The text file containing the script
    private string[] script; //Initialize string array that has all the lines from the script
    private Text dialogue; //the text attribute

    // Start is called before the first frame update
    void Start()
    {
        dialogue = this.gameObject.GetComponent<Text>(); //Set the dialogue to be this gameobject's text
        script = scriptObject.text.Split("\n"[0]); //Split the script into lines
        dialogue.text = script[0]; //Start the dialogue on the first line
    }

    private int currentLine = 0; //Variable to count whatever line we're on
    private bool isDone = false;

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (Input.GetButtonUp("Advance") && !isDone) //Check if the player advances the script
            {
                currentLine += 2; //Increase the counter by 2 (skip the whitespace in between lines)
                dialogue.text = script[currentLine]; //Update the text
            }
        } 
        catch (System.IndexOutOfRangeException e)
        {
            dialogue.text = "finished!";
            isDone = true;
        }
    }
}
