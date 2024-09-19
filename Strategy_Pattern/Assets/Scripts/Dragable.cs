using UnityEngine;

public class DragablePoint : MonoBehaviour
{
    public bool IsDragging = false;
    public BoxCollider collider;
    public SpriteRenderer spriteRenderer;
    private int initialSortingOrder;

    void Start()
    {
        collider = GetComponent<BoxCollider>();
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
            this.transform.position = new Vector3(worldPos.x, worldPos.y, this.transform.position.z);
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = initialSortingOrder + 1;
            }
        }
        else
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = initialSortingOrder;
            }
        }
    }
}
