using UnityEngine;

public class Card : MonoBehaviour, ICard
{
    public int CardEnergyCost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayArea")
        {
            PlayCard();
        }
    }
    void Update()
    {

    }
    public void PlayCard()
    {
        Energy energy = GetComponent<Energy>();

        if (energy != null && energy.currentEnergy >= CardEnergyCost)
        {

            energy.currentEnergy -= CardEnergyCost;
            Debug.Log("Card played! Remaining energy: " + energy.currentEnergy);
        }
        else
        {
            Debug.Log("Not enough energy to play the card!");
        }
    }
}
