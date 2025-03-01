using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    [SerializeField] float height; // -42

    private void Update()
    {

        if (transform.position.y <= - height)
        {
            UpdatePosition();
        }

    }

    private void UpdatePosition()
    {
        Vector2 pos = new Vector2(0, height * 2);
        transform.position = (Vector2)transform.position + pos;
    }
}
