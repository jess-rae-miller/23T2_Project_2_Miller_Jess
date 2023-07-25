using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ship ship;
    [SerializeField] private Crewmate crewmate;
    [SerializeField] private TMP_Text crewmateNameText;
    [SerializeField] private TMP_Text crewmateHobbyText;

    public void AcceptCrewmateButton()
    {
        if (crewmate.isAlien)
        {
            // Get a random human hobby
            string randomHumanHobby = Crewmate.GetRandomHobbyFrom(humanHobbies);

            // Destroy any human crewmates with the same hobby
            Crewmate.DestroyHumanCrewmates(randomHumanHobby);

            crewmate.hobby = randomHumanHobby;
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

    // Update the UI Text elements when a crewmate applies to join the ship
    public void UpdateCrewmateUI(Crewmate crewmate)
    {
        string v = "Crewmate Name: " + crewmate.crewmateName;
        crewmateNameText.text = v;
    }
}
