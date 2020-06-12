using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    Vector2 movement;
    public float moveSpeed = 5f;

    public float health;

    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        //Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        healthBar.transform.localScale = new Vector3(health / 100, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        if (health <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void Die()
    {
        print("Enemy " + this.gameObject.name + " has died!");
        Destroy(this.gameObject);
    }
}
