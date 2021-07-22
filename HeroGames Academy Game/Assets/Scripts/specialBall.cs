using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialBall : MonoBehaviour
{
    public SwipeInputs swipeInputs;
    public Score score;

    public Rigidbody rb;
    public GameObject Pota;

    public static bool move = false;
    public static bool isShooted, isDisabled;
    Vector3 pota;

    public bool isMoving;

    private void Awake()
    {
        score = GameObject.Find("GameManagement").GetComponent<Score>();
        swipeInputs = GameObject.Find("GameManagement").GetComponent<SwipeInputs>();
    }

    void Start()
    {
        Pota = GameObject.Find("Pota");
        pota = Pota.transform.position;
    }

    void Update()
    {
        if (!isMoving && swipeInputs.check)
        {
            rb.AddForce(swipeInputs.checkVector * Time.deltaTime);
        }

        if (rb.transform.position.z > pota.z + 3f || rb.transform.position.y < pota.y - 5f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isShooted = false;
        isDisabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ballGround")
        {
            isMoving = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ballGround")
        {
            Debug.Log("trigger");
            isShooted = true;
            isMoving = true;
            score.specialBallCount--;
            score.ballCounter--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "point")
        {
            score.score +=2;
            SoundManager.PlaySound("swishSound");
        }
    }

    public void TransformPos(Vector3 direction)
    {
        rb.transform.position = direction;
    }
}
