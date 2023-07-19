using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ship ship;
    [SerializeField] private Crewmate crewmate;
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
            //add crewmate to ship
            ship.successfulCrewmates.Add(crewmate);
        }
        crewmate.GenerateCrewmateProperties();

    }

    public void DenyCrewmateButton()
    {

        if (crewmate.isAlien)
        {
            //destroy alien character
        }
        else
        {
            Debug.Log(crewmate.crewmateName + " was rejected.");
        }
        crewmate.GenerateCrewmateProperties();

    }
}
