using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ship ship;
    [SerializeField] private Crewmate crewmate;
    [SerializeField] private TextMeshProUGUI crewmateNameText;
    [SerializeField] private TextMeshProUGUI crewmateHobbyText;
    [SerializeField] private TextMeshProUGUI crewCounterText;
    [SerializeField] private TextMeshProUGUI winnerText;

    private bool playing = true;

    private void Update()
    {
        UpdateCrewmateUI();
        if (ship.successfulCrewmates.Count == ship.maxCrew)
        {
            PlayerWins();
        }
        
    }
    public void AcceptCrewmateButton()
    {
        if (!playing)
        {
            return;
        }
        if (crewmate.isAlien)
        {
            // Get a random human hobby
            string randomHumanHobby = ship.GetRandomHobbyFromCrew();

            // Destroy any human crewmates with the same hobby
            int humansKilled = DestroyHumanCrewmates(randomHumanHobby);

            Debug.Log(crewmate.crewmateName + " was an Alien and killed " + humansKilled + " Crewmate(s)!");

            crewmate.hobby = randomHumanHobby;
        }
        else
        {
            Debug.Log("Welcome aboard, " + crewmate.crewmateName + "!");
            ship.successfulCrewmates.Add(DeepCopyCrewmate(crewmate));
        }
        crewmate.GenerateCrewmateProperties();
    }
    public void DenyCrewmateButton()
    // Prints any denied crewmate's name in the console
    {
        if (!playing)
        {
            return;
        }
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

    public int DestroyHumanCrewmates(string randomHobby)
    {
        int humansKilled = 0;
        // Check if there are any human crewmates with a random human hobby
        // Deletes them
        foreach (Crewmate humanCrewmate in ship.successfulCrewmates.ToArray())
        {
            if (humanCrewmate.hobby == randomHobby)
            {
                ship.successfulCrewmates.Remove(humanCrewmate);
                humansKilled++;
            }
        }

        return humansKilled;
    }
    private Crewmate DeepCopyCrewmate(Crewmate crewmate)
    { 
        // Classmate Sam helped with this part
        // Original script made a 'shallow copy'of crewmates
        // This version will create an independent copy called 'deep copy'
        Crewmate newCrewmate = new Crewmate();

        newCrewmate.crewmateName = crewmate.crewmateName;
        newCrewmate.hobby = crewmate.hobby;
        newCrewmate.isAlien = crewmate.isAlien;

        return newCrewmate;
    }

    // Update the UI Text elements when a crewmate applies to join the ship
    public void UpdateCrewmateUI()
    {
        crewmateNameText.text = "Crewmate Name: " + crewmate.crewmateName;
        crewmateHobbyText.text = "Applicant Hobby: " + crewmate.hobby;
        crewCounterText.text = "Crewmate Counter: " + ship.successfulCrewmates.Count;
    }

    private void PlayerWins()
    {
        // When the ship is full of human crewmates, the list of current crew is displayed and other UI text will not be on-scren
        winnerText.text = "<b>YOU WIN \n Current Crew:</b>\n";
        foreach (Crewmate humanCrewmate in ship.successfulCrewmates.ToArray())
        {
            winnerText.text += humanCrewmate.crewmateName + " - " + humanCrewmate.hobby + "\n";
        }
        crewmateHobbyText.enabled = false;
        crewmateNameText.enabled = false;
        playing = false;
    }
}
