using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Crewmate : MonoBehaviour
{
    [SerializeField] public new string name;
    [SerializeField] public string hobby;
    [SerializeField] public bool isAlien;

    public int maxCrew = 10;

    // Human hobbies
    private string[] humanHobbies = { "Reading", "Writing", "Painting", "Sport", "Cooking", "Film" };
    // Alien hobbies
    private string[] alienHobbies = { "Assimilating", "Synthesizing", "Breathing", "Smelling", "Taxidermy", "Fascism" };

    private System.Random rnd = new System.Random();
    // Human names
    private string[] humanFirstNames = { "Emma", "Liam", "Olivia", "Peter", "Ava", "Isabella", "Sophia", "Mia", "Charlotte", "Amelia", "Harper", "Michael", "Jacob", "Emily", "Elizabeth", "Mila", "Ella", "Avery", "Ron", "Camilla" };
    private string[] humanSurnames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White" };

    // Alien names
    private string[] alienFirstNames = { "Enma", "LiAm", "Oilvia", "peter", "Ava", "IsabeIIa", "Soophia", "Mia", "Sharlotte", "AmeIia", "Harper", "Michael", "Jacob", "EmiIy", "Elizabeth", "MiLa", "EIla", "avery", "R0n", "Chamilla" };
    private string[] alienSurnames = { "$mith", "jonson", "Milliams", "8rown", "J0nes", "Willer", "Davis", "6arcia", "Rodriguez", "Wilzon", "Martines", "Ander$on", "TayIor", "Thomas", "Hernanbez", "More", "Martin", "Jackson", "Thompson", "Whife" };

    public Image imageDisplay; // Reference to the Image component for displaying the random image

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        while (maxCrew < 10)
        {
            GenerateCrewmate();
        }
    }

    private void GenerateCrewmate()
    {
        name = GenerateRandomName();
        string hobby;
        // 1/4 chance of being an alien????
        isAlien = Random.value < 0.25f;

        if (isAlien)
        {
            hobby = GetRandomHobbyFrom(alienHobbies);
        }
        else
        {
            hobby = GetRandomHobbyFrom(humanHobbies);
        }

        // Display the name and hobby along with the random image
        DisplayCharacterInfo();
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
            string newName = alienFirstNames[rnd.Next(0, alienFirstNames.Length)] + alienSurnames[rnd.Next(0, alienSurnames.Length)];
            return newName;
        }
        else
        {
            string newName = humanFirstNames[rnd.Next(0, humanFirstNames.Length)] + humanSurnames[rnd.Next(0, humanSurnames.Length)];
            return newName;
        }
    }

    private void DisplayCharacterInfo()
    {
        // Load and display the random image
        string randomImagePath = GetRandomImagePath();
        Texture2D randomTexture = LoadTextureFromFile(randomImagePath);
        Sprite randomSprite = Sprite.Create(randomTexture, new Rect(0, 0, randomTexture.width, randomTexture.height), Vector2.zero);
        imageDisplay.sprite = randomSprite;

        // Output the name and hobby in the console
        Debug.Log("Name: " + name + ", Hobby: " + hobby);
    }

    private string GetRandomImagePath()
    {
        string spritesFolderPath = "Sprites/Crewmates"; // Modify this if necessary
        string[] imagePaths = Directory.GetFiles(spritesFolderPath, "*.png"); // Modify the file extension if using a different image format
        string randomImagePath = imagePaths[Random.Range(0, imagePaths.Length)];
        return randomImagePath;
    }

    private Texture2D LoadTextureFromFile(string filePath)
    {
        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);
        return texture;
    }
}
