using UnityEngine;

public class CardPlayer : MonoBehaviour
{
    public int cardEnergyCost = 1;  // Default energy cost for a card
    public Energy energy;  // Reference to the player's energy component

    // Start is called before the first frame update
    void Start()
    {
        // Get the Energy component attached to the GameObject
        energy = GetComponent<Energy>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add any continuous update logic here, if necessary
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has an ICard interface
        if (collision.TryGetComponent<ICard>(out ICard card))
        {
            PlayCard(card);  // Pass the card to the PlayCard method when colliding with an ICard
        }
    }

    // Method to play a card
    public void PlayCard(ICard card)
    {
        if (energy != null && energy.currentEnergy >= cardEnergyCost)
        {
            // Deduct the card's energy cost from the player's energy
            energy.currentEnergy -= cardEnergyCost;
            Debug.Log("Card played! Remaining energy: " + energy.currentEnergy);

            // Play the card (call the card's PlayCard method)
            card.PlayCard();
        }
        else
        {
            Debug.Log("Not enough energy to play the card!");
        }
    }
}
