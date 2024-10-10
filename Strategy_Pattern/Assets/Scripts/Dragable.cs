using UnityEngine;

public class DragablePoint : MonoBehaviour
{
    public bool IsDragging = false;
    public BoxCollider2D boxCollider;  // Ensure using BoxCollider2D for 2D physics
    public SpriteRenderer spriteRenderer;
    private int initialSortingOrder;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();  // Using BoxCollider2D for 2D physics
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            initialSortingOrder = spriteRenderer.sortingOrder;
        }
    }

    private void OnMouseDown()
    {
        IsDragging = true;
    }

    private void OnMouseUp()
    {
        IsDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDragging)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);

            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = initialSortingOrder + 1;  // Bring the dragged object to the front
            }
        }
        else
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = initialSortingOrder;  // Restore original sorting order
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has an ICard interface
        if (collision.TryGetComponent<ICard>(out ICard card))
        {
            PlayCard();  // Call the PlayCard method when colliding with an ICard
        }
    }

    // Implement the PlayCard method from ICard interface
    public void PlayCard()
    {
        Debug.Log("Card played from DragablePoint!");
        // Add your logic here for what should happen when the card is played
    }
}
