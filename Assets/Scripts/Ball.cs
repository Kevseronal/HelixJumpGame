using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce =1.5f;
    public GameObject splashPrefab;
    public GameManager gm;
    private bool canJump = true;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = new Vector3(0, Time.deltaTime * jumpForce);

        canJump = false;
        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0f, -0.2f, 0f), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);

        string metarialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        Debug.Log("Metaryal adý : " + metarialName);

        if (metarialName == "Unsafecolor (Instance)")
        {
            gm.RestartGame();
        }
        else if (metarialName == "Last Ring (Instance)")
        {
            gm.RestartGame();
        }
    }
}
