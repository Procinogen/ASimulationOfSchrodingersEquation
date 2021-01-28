using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Reader : actions
{

    public TextAsset scriptObject; //The text file containing the script
    public TextAsset actionScenesObject;
    public ElecStates actor;
    private string[] script; //Initialize string array that has all the lines from the script
    private string[] actingLines;
    private Text dialogue; //the text attribute

    // Start is called before the first frame update
    void Start()
    {
        dialogue = this.gameObject.GetComponent<Text>(); //Set the dialogue to be this gameobject's text
        script = scriptObject.text.Split(new string[] { "|NEXT|" }, System.StringSplitOptions.None); //Split the script into lines
        actingLines = actionScenesObject.text.Split(","[0]); //Split the actions into lines
        string[] tempSubScript = script[currentLine].Split(new string[] { "|PAUSE|" }, System.StringSplitOptions.None);
        dialogue.text = tempSubScript[0]; //Start the dialogue on the first line
    }

    private int currentLine = 0; //Variable to count whatever line we're on
    private int currentSubLine = 1;
    //private bool subIsDone = false;
    private bool isDone = false;
    //private bool acting = false;

    private bool inArray(string needle, string[] haystack)
    {
        bool wasFound = false;
        for (int i = 0; i < haystack.Length; i++)
        {
            if (needle == haystack[i])
            {
                wasFound = true;
            }
        }
        return wasFound;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            string[] subScript = script[currentLine].Split(new string[] { "|PAUSE|" }, System.StringSplitOptions.None);
            if (Input.GetButtonUp("Advance") && !isDone && !acting) //Check if the player advances the script
            {
                try
                {
                    dialogue.text += subScript[currentSubLine];
                    currentSubLine++;
                }
                catch (System.IndexOutOfRangeException exception)
                {

                    if (inArray(currentLine.ToString(), actingLines) && !acting)
                    {
                        acting = true;
                        switch (currentLine)
                        {
                            case 0:
                                StartCoroutine(AnimateMove(actor.gameObject.transform.position, new Vector3(-3.28f, 3.17f, -5.00f), 2.5f, actor, true));
                                break;
                            case 9:
                                StartCoroutine(TeleportObject(new Vector3(-4.0f, 3.22f, -4.4f), GameObject.FindGameObjectsWithTag("equation")[0], false));
                                StartCoroutine(AnimateMove(actor.gameObject.transform.position, new Vector3(2f, 2.2f, -4f), 2f, actor, true));
                                break;
                            case 10:
                                StartCoroutine(AnimateMove(actor.gameObject.transform.position, GameObject.FindGameObjectsWithTag("equationVariable")[0].transform.position, 0.8f, actor, true));
                                break;
                            case 11:
                                StartCoroutine(AnimateMove(actor.gameObject.transform.position, GameObject.FindGameObjectsWithTag("equationVariable")[1].transform.position, 0.8f, actor, true));
                                break;
                            default:
                                acting = false;
                                break;
                        }
                    }

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
