using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ship ship;
    [SerializeField] private Crewmate crewmate;
    [SerializeField] private Text crewmateNameText;
    [SerializeField] private Text crewmateHobbyText;
    // Start is called before the first frame update
    void Start()

    {

    }
    
    public void AcceptCrewmateButton()
    {
        if (crewmate.isAlien)
        {
            crewmate.hobby = Crewmate.GetRandomHobbyFrom();
            //destroy any human crewmates with the same hobby
        }
        else
        {
            Debug.Log("Welcome aboard, " + crewmate.crewmateName + "!");
   
            ship.successfulCrewmates.Add(crewmate);
        }
        crewmate.GenerateCrewmateProperties();

    }

    public void DenyCrewmateButton()
    {

        if (crewmate.isAlien)
        {
            Debug.Log(crewmate.crewmateName + " was rejected.");
        }
        else
        {
            Debug.Log(crewmate.crewmateName + " was rejected.");
        }
        crewmate.GenerateCrewmateProperties();

    }

    private void UpdateCrewmateUI(Crewmate crewmate)
    {
        crewmateNameText.text = "Crewmate Name: " + crewmate.crewmateName;

        if (crewmate.isAlien)
        {
            string alienHobby = Crewmate.alienHobbies[Random.Range(0, Crewmate.alienHobbies.Length)];
            crewmateHobbyText.text = "Crewmate Hobby: " + alienHobby;
        }
        else
        {
            string humanHobby = Crewmate.humanHobbies[Random.Range(0, Crewmate.humanHobbies.Length)];
            crewmateHobbyText.text = "Crewmate Hobby: " + humanHobby;
        }
    }
}
