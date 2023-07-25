using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crewmate : MonoBehaviour
{
    [SerializeField] public string crewmateName;
    [SerializeField] public string hobby;
    [SerializeField] public bool isAlien;

    // Human hobbies
    [SerializeField] public static string[] humanHobbies = { "Reading", "Writing", "Painting", "Sport", "Cooking", "Film" };
    // Alien hobbies
    public static string[] alienHobbies = { "Assimilating", "Synthesizing", "Breathing", "Being nice", "Taxidermy", "Fascism" };

    private System.Random rnd = new System.Random();
    // Human names
    private string[] humanFirstNames = { "Emma", "Liam", "Olivia", "Peter", "Ava", "Isabella", "Sophia", "Mia", "Charlotte", "Amelia", "Harper", "Michael", "Jacob", "Emily", "Elizabeth", "Mila", "Ella", "Avery", "Ron", "Camilla" };
    private string[] humanSurnames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White" };

    // Alien names
    private string[] alienFirstNames = { "Enna", "LiAm", "Oilvia", "peter", "Avva", "IsabeIIa", "Soophia", "MIa", "Sharlotte", "AmeIia", "Harber", "Micheal", "iacob", "EmiIy", "elizabeth", "MiLa", "EIla", "avery", "R0n", "Chamilla" };
    private string[] alienSurnames = { "$mith", "jonson", "Milliams", "8rown", "J0nes", "Willer", "D@vis", "6arcia", "Bodriguez", "Wilzon", "Mart1nes", "Ander$on", "TayIor", "Fhomas", "Hernanbez", "More", "M@rtin", "Jaokson", "Thowpson", "Whife" };


    void Start()
    {
        GenerateCrewmateProperties();
    }

    public void GenerateCrewmateProperties()
    {
        //Aliens have a 25% of spawning
        isAlien = Random.value < 0.25f;

        crewmateName = GenerateRandomName();
        

        if (isAlien)
        {
            hobby = GetRandomHobbyFrom(alienHobbies);
        }
        else
        {
            hobby = GetRandomHobbyFrom(humanHobbies);
        }

    }

    public static string GetRandomHobbyFrom(string[] hobbies)
    {
        int randomIndex = Random.Range(0, hobbies.Length);
        return hobbies[randomIndex];
    }

    public static string GetRandomHobbyFrom()
    {
        int randomIndex = Random.Range(0, humanHobbies.Length);
        return humanHobbies[randomIndex];
    }
    //Searches the list of random names and assigns either to a human or alien
    private string GenerateRandomName()
    {
        if (isAlien)
        {
            return alienFirstNames[rnd.Next(0, alienFirstNames.Length)] + " " + alienSurnames[rnd.Next(0, alienSurnames.Length)];
            
        }
        else
        {
            return humanFirstNames[rnd.Next(0, humanFirstNames.Length)] + " " +  humanSurnames[rnd.Next(0, humanSurnames.Length)];
        }
    }
    public static void DestroyHumanCrewmates(string randomHobby)
    {
        // Find all the human crewmates on the ship
        Crewmate[] allCrewmates = FindObjectsOfType<Crewmate>();
        List<Crewmate> humanCrewmates = new List<Crewmate>();

        foreach (Crewmate crewmate in allCrewmates)
        {
            if (!crewmate.isAlien)
            {
                humanCrewmates.Add(crewmate);
            }
        }

        // Check if there are any human crewmates with the random hobby
        List<Crewmate> crewmatesToDestroy = new List<Crewmate>();
        foreach (Crewmate humanCrewmate in humanCrewmates)
        {
            if (humanCrewmate.hobby == randomHobby)
            {
                crewmatesToDestroy.Add(humanCrewmate);
            }
        }

        // Destroy the human crewmates with the random hobby
        foreach (Crewmate crewmateToDestroy in crewmatesToDestroy)
        {
            Destroy(crewmateToDestroy.gameObject);
        }
    }
}
