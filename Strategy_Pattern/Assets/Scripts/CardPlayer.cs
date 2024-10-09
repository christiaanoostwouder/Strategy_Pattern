using UnityEngine;

public class CardPlayer : MonoBehaviour
{
    public int cardEnergyCost = 1;
    public Energy energy;

    // Start is called before the first frame update
    void Start()
    {
        energy = GetComponent<Energy>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic if needed
    }

    // Implementing the PlayCard method from ICard interface
    public void PlayCard()
    {
        energy.SpendEnergy(cardEnergyCost);
        Debug.Log("cardPlayerScript Fired");
    }


}
