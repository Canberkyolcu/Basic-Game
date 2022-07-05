using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private int _characterSpeed;
    Rigidbody rb;
    [SerializeField] MeshRenderer mr;
    [SerializeField] Color colorPink, colorNormal;
    public bool isHackActive;
    



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        
    }


    void Update()
    {
        Move();

    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(y * _characterSpeed, 0, -x * _characterSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            if (mr.material.color == colorPink)
            {
                Destroy(other.gameObject);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }

        if (other.tag == "pink")
        {
            Destroy(other.gameObject);
            mr.material.color = colorPink;
        }
        if (other.tag == "next")
        {
            if (mr.material.color == colorPink)
            {
                Destroy(other.gameObject);

            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
        if (other.tag == "hack")
        {
            Destroy(other.gameObject);
            isHackActive = true;
        }
    }

    IEnumerator yieldReturn()
    {
        yield return new WaitForSeconds(2);
    }
}
