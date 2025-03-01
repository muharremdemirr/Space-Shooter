using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("gameSetting")]
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minX = -4f;
    [SerializeField] float maxX = 4f;
    [SerializeField] float minY = -6.5f;
    [SerializeField] float maxY = 8f;

    [Header("Objects")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletTransform;
    private void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
            
    }



    private void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, v, 0);
        movement = movement.normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        Vector3 clamPosition = transform.position;
        clamPosition.x = Mathf.Clamp(clamPosition.x, minX, maxX);
        clamPosition.y = Mathf.Clamp(clamPosition.y, minY, maxY);
        transform.position = clamPosition;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletTransform.position, Quaternion.identity);
    }
}
