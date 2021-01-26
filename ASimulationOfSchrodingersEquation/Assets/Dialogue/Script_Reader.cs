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
        script = scriptObject.text.Split(new string[] { "|NEXT|" }, System.StringSplitOptions.None); //Split the script into lines
        string[] tempSubScript = script[currentLine].Split(new string[] { "|PAUSE|" }, System.StringSplitOptions.None);
        dialogue.text = tempSubScript[0]; //Start the dialogue on the first line
    }

    private int currentLine = 0; //Variable to count whatever line we're on
    private int currentSubLine = 1;
    private bool subIsDone = false;
    private bool isDone = false;

    // Update is called once per frame
    void Update()
    {
        try
        {
            string[] subScript = script[currentLine].Split(new string[] { "|PAUSE|" }, System.StringSplitOptions.None);
            if (Input.GetButtonUp("Advance") && !isDone) //Check if the player advances the script
            {

                try
                {
                    dialogue.text += subScript[currentSubLine];
                    currentSubLine++;
                }
                catch (System.IndexOutOfRangeException exception)
                {
                    dialogue.text = "";
                    currentLine++;
                    currentSubLine = 1;
                    subScript = script[currentLine].Split(new string[] { "|PAUSE|" }, System.StringSplitOptions.None);
                    dialogue.text = subScript[0];
                }
            }
        } 
        catch (System.IndexOutOfRangeException e)
        {
            dialogue.text = "finished!";
            isDone = true;
        }
    }
}
