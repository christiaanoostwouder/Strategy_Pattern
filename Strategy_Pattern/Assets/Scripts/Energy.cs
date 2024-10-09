using TMPro;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] public bool cardEnergyExpense;
    [SerializeField] public float cardEnergyCost;
    [SerializeField] public TextMeshProUGUI energyText;  // UI Text element to display energy
    [SerializeField] private int currentEnergy = 0;  // Current energy the player has
    [SerializeField] public int startEnergy = 3;     // Starting energy at the beginning of the game/turn

    void Start()
    {

        currentEnergy = startEnergy;
        UpdateEnergyUI();
    }

    void Update()
    {
        // Check if spacebar is pressed and try to spend energy (e.g., cost of 1)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpendEnergy(1);
            Debug.Log("Pressed spacebar");
        }

    }

    // Update the energy UI
    void UpdateEnergyUI()
    {
        energyText.text = "Energy: " + currentEnergy;
        Debug.Log("Current Energy: " + currentEnergy);
    }

    // Method to spend energy
    public void SpendEnergy(int energyCost)
    {
        if (energyCost > currentEnergy)
        {
            Debug.Log("Not enough energy");
        }
        else
        {
            currentEnergy -= energyCost;  // Deduct the energy cost from currentEnergy
            Debug.Log("Spent " + energyCost + " energy.");
            UpdateEnergyUI();  // Update the UI to reflect new energy value
        }
    }
}
