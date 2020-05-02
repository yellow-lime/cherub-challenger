using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    public bool facingRight;
    public float speed = 5f;
    public float jumpForce = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 up = Vector3.up;
    Vector3 right = Vector3.right;

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPos = this.gameObject.transform.position;
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        // float y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(x * right, ForceMode2D.Impulse);

        if(Input.GetButtonDown("Jump")){
            Jump();
        }

        if ((facingRight && x < 0) || (!facingRight && x > 0))
        {
            ChangeSpriteFacing(x);
        }
    }

    private void ChangeSpriteFacing(float x)
    {
        facingRight = !facingRight;
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.flipX = !sr.flipX;
        }
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(up * jumpForce, ForceMode2D.Impulse);
    }
}
