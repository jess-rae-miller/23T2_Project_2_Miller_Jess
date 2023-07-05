using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crewmate : MonoBehaviour
{
    [SerializeField] public new string name;
    [SerializeField] public string hobby;
    [SerializeField] public bool isAlien;

    public int maxCrew = 10;

    //Human hobbies
    private string[] humanHobbies = { "Reading", "Writing", "Painting", "Sport", "Cooking", "Film" };
    //Alien hobbies
    private string[] alienHobbies = { "Assimilating", "Synthesizing", "Breathing", "Smelling", "Taxidermy", "Fascism" };

    private System.Random rnd = new System.Random();
    //Human names
    private string[] humanFirstNames = { "Emma", "Liam", "Olivia", "Noah", "Ava", "Isabella", "Sophia", "Mia", "Charlotte", "Amelia", "Harper", "Michael", "Jacob", "Emily", "Elizabeth", "Mila", "Ella", "Avery", "Sofia", "Camila" };
    private string[] humanLastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White" };

    // Start is called before the first frame update
    void Start() => StartGame();

    private void StartGame()
    {
        while (maxCrew < 10)
        {
            GenerateCrewmate();
        }
    }

    private void GenerateCrewmate()
    {
        _ = GenerateRandomName();
        string hobby;
        // 1/4 chance of being an alien????
        bool isAlien = Random.value < 0.25f; 

        if (isAlien)
        {
            hobby = GetRandomHobbyFrom(alienHobbies);
        }
        else
        {
            hobby = GetRandomHobbyFrom(humanHobbies);
        }
    }

    private string GetRandomHobbyFrom(string[] hobbies)
    {
        int randomIndex = Random.Range(0, hobbies.Length);
        return hobbies[randomIndex];
    }

    private string GenerateRandomName()
    {
        if (isAlien)
        {
            string newName = humanFirstNames[rnd.Next(0, humanFirstNames.Length)] + humanLastNames[rnd.Next(0, maxValue: humanLastNames.Length)];
            return newName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
