using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Energy : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI energyText;  // UI Text element to display energy
    [SerializeField] private int currentEnergy = 0;  // Current energy the player has
    [SerializeField] public int startEnergy = 3;     // Starting energy at the beginning of the game/turn


    void Start()
    {
        currentEnergy = startEnergy;
        UpdateEnergyUI();
    }

    // Update the energy UI
    void UpdateEnergyUI()
    {
        energyText.text = "Energy: " + currentEnergy;
        Debug.Log("Current Energy: " + currentEnergy);
    }
    UnityEvent SpendEnergy(int energy)
    {
        currentEnergy = energy;
        if (energy >= currentEnergy)
        {
            Debug.Log("dont have enough energy")
        };
        energy--;
        currentEnergy = energy;
    }
}