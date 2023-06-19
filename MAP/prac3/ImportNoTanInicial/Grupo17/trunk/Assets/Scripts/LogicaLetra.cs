using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaLetra : MonoBehaviour
{
    public char fallingChar = 'a';
    int randomCharMaker = 0;
    bool charAssigned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //LETTER ASIGNATION
        //If the obj has already spawned, it assigns a random number to it
        if (charAssigned == false)                                                       
        {                                                                                
            randomCharMaker = Random.Range(0, 25);                                       
            charAssigned = true;                                                         
        }
        //Depending on the random number, it gives a letter or another
        fallingChar = (char)('a' + randomCharMaker);                                    
        GetComponent<TextMesh>().text = fallingChar.ToString();                          


        //LETTER ERASER BY KEYSTROKE
        //Executes the following code when a key is pressed, factoring what key was pressed              
        foreach (char keyInput in Input.inputString)
        {    //Looks if the key pressed is the same as the falling letter
            if (keyInput == fallingChar)                                                
            {
                //Destroys the letter if it's true
                Destroy(gameObject);                                                     
            }
        }
    }
    
    private void OnTriggerEnter(Collider letter)
    {
        Debug.Log("Letter has registered contact with: " + letter.gameObject.name);
        Destroy(gameObject);
    }
}
