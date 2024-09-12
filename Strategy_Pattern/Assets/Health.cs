using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public void Update()
    {
        if (health <= 0)
        {

            gameObject.SetActive(false);




        }
    }

}
