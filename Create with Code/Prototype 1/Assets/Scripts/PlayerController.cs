using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horsePower = 200f;
    [SerializeField] float turnSpeed = 10f;
    float horizontalInput;
    float forwardInput;
    [SerializeField] GameObject centerOfMass;
    Rigidbody rig;
    [SerializeField] TextMeshProUGUI speedoMeterText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rmpText;
    [SerializeField] float rpm;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        rig.centerOfMass = centerOfMass.transform.position;
    }

    void Update()
    {
        speed = Mathf.Round(rig.velocity.magnitude * 2.237f);
        speedoMeterText.SetText("Speed:" + speed + "mph");
        rpm = Mathf.Round((speed % 30) * 40);
        rmpText.SetText("RPM: " + rpm);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        rig.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        //rig.AddForce(Vector3.forward * horsePower * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
