using UnityEngine;

public class Card : MonoBehaviour, ICard
{
    public int CardEnergyCost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has an ICard interface
        if (collision.TryGetComponent<ICard>(out ICard card))
        {
            PlayCard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Add any continuous update logic, if necessary
    }

    // This is the proper implementation of PlayCard as required by the ICard interface
    public void PlayCard()
    {

    }
}
