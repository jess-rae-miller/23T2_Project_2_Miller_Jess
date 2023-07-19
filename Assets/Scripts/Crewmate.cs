using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Crewmate : MonoBehaviour
{
    [SerializeField] public string crewmateName;
    [SerializeField] public string hobby;
    [SerializeField] public bool isAlien;

    public int maxCrew = 10;

    // Human hobbies
    private static string[] humanHobbies = { "Reading", "Writing", "Painting", "Sport", "Cooking", "Film" };
    // Alien hobbies
    private string[] alienHobbies = { "Assimilating", "Synthesizing", "Breathing", "Smelling", "Taxidermy", "Fascism" };

    private System.Random rnd = new System.Random();
    // Human names
    private string[] humanFirstNames = { "Emma", "Liam", "Olivia", "Peter", "Ava", "Isabella", "Sophia", "Mia", "Charlotte", "Amelia", "Harper", "Michael", "Jacob", "Emily", "Elizabeth", "Mila", "Ella", "Avery", "Ron", "Camilla" };
    private string[] humanSurnames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White" };

    // Alien names
    private string[] alienFirstNames = { "Enna", "LiAm", "Oilvia", "peter", "Avva", "IsabeIIa", "Soophia", "MIa", "Sharlotte", "AmeIia", "Harber", "Micheal", "iacob", "EmiIy", "elizabeth", "MiLa", "EIla", "avery", "R0n", "Chamilla" };
    private string[] alienSurnames = { "$mith", "jonson", "Milliams", "8rown", "J0nes", "Willer", "D@vis", "6arcia", "Bodriguez", "Wilzon", "Martines", "Ander$on", "TayIor", "Fhomas", "Hernanbez", "More", "Martin", "Jackson", "Thompson", "Whife" };


    // Start is called before the first frame update
    void Start()
    {
        GenerateCrewmateProperties();
    }

    public void GenerateCrewmateProperties()
    {
        
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
}
