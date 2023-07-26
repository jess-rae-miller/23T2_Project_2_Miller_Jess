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
            W();
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
            DestroyHumanCrewmates(randomHumanHobby);

            crewmate.hobby = randomHumanHobby;
        }
        else
        {
            Debug.Log("Welcome aboard, " + crewmate.crewmateName + "!");
            ship.successfulCrewmates.Add(DeepCopyCrewmate(crewmate));
        }
        crewmate.GenerateCrewmateProperties();
    }

    private void W()
    {
        winnerText.text = "<b>YOU WIN</b>\n";
        foreach (Crewmate humanCrewmate in ship.successfulCrewmates.ToArray())
        {
            winnerText.text +=  humanCrewmate.crewmateName + " - " + humanCrewmate.hobby + "\n";
        }
        crewmateHobbyText.enabled = false;
        crewmateNameText.enabled = false;
        playing = false;
    }

    private Crewmate DeepCopyCrewmate(Crewmate crewmate)
    { 
        //Stolen from sam
        Crewmate newCrewmate = new Crewmate();

        newCrewmate.crewmateName = crewmate.crewmateName;
        newCrewmate.hobby = crewmate.hobby;
        newCrewmate.isAlien = crewmate.isAlien;

        return newCrewmate;
    }

    public void DenyCrewmateButton()
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

    // Update the UI Text elements when a crewmate applies to join the ship
    public void UpdateCrewmateUI()
    {
        crewmateNameText.text = "Crewmate Name: " + crewmate.crewmateName;
        crewmateHobbyText.text = "Applicant Hobby: " + crewmate.hobby;
        crewCounterText.text = "Crewmate Counter: " + ship.successfulCrewmates.Count;
    }

    public void DestroyHumanCrewmates(string randomHobby)
    {
        // Check if there are any human crewmates with the random hobby
        foreach (Crewmate humanCrewmate in ship.successfulCrewmates.ToArray())
        {
            if (humanCrewmate.hobby == randomHobby)
            {
                ship.successfulCrewmates.Remove(humanCrewmate);
            }
        }
    }
}
