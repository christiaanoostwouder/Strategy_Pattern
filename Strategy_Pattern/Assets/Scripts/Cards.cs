using UnityEngine;

public class Cards : MonoBehaviour
{
    // Array to hold card prefabs (assign in the Unity Inspector)
    public GameObject[] cardPrefabs;

    // Reference to the main camera
    private Camera mainCamera;

    // Horizontal spacing between cards
    public float cardSpacing = 1.5f; // Adjust this to control spacing between cards

    // Number of cards to generate
    public int numberOfCards = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Get the main camera reference
        mainCamera = Camera.main;

        // Generate cards at the bottom center of the screen
        GenerateCardsInRow();
    }

    // Method to generate cards in a row at the bottom of the screen
    void GenerateCardsInRow()
    {
        if (cardPrefabs.Length == 0)
        {
            Debug.LogWarning("No card prefabs assigned!");
            return;
        }

        // Get the starting position for the first card
        Vector3 startPosition = GetBottomCenterPosition();

        // Calculate the total width for all cards to center them properly
        float totalWidth = (numberOfCards - 1) * cardSpacing;

        // Offset the first card to the left, so the row of cards is centered
        startPosition.x -= totalWidth / 2;

        // Loop through and generate cards
        for (int i = 0; i < numberOfCards; i++)
        {
            // Generate a random card
            int randomIndex = Random.Range(0, cardPrefabs.Length);

            // Calculate the position for this card
            Vector3 cardPosition = new Vector3(startPosition.x + i * cardSpacing, startPosition.y, 0);

            // Instantiate the card at the calculated position
            Instantiate(cardPrefabs[randomIndex], cardPosition, Quaternion.identity);

            Debug.Log("Generated a random card: " + cardPrefabs[randomIndex].name);
        }
    }

    // Method to get the bottom center position of the screen
    Vector3 GetBottomCenterPosition()
    {
        // Get the bottom center point in world space
        return mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0, mainCamera.nearClipPlane));
    }
}
