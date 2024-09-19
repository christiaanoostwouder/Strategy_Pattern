using UnityEngine;

public class DragablePoint : MonoBehaviour
{
    public bool IsDraging = false;
    public BoxCollider collider;
    void Start()
    {

    }
    private void OnMouseDown()
    {
        IsDraging = true;
    }
    private void OnMouseUp()
    {
        IsDraging = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousPost = Input.mousePosition;
        MousPost = Camera.main.ScreenToWorldPoint(MousPost);
        if (IsDraging)
        {
            this.transform.position = new Vector3(MousPost.x, MousPost.y, 0);
        }
    }
}
