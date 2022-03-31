using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rig;
    private GameObject focalPoint;
    private bool hasPowerup;
    public float powerupStreth = 15f;
    public GameObject powerupIndicator;
    private Coroutine powerupCountDownCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        rig.AddForce(focalPoint.transform.forward * speed * verticalInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            if(powerupCountDownCoroutine != null)
                StopCoroutine(powerupCountDownCoroutine);
            powerupCountDownCoroutine = StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.SetActive(true);
        }
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRig = other.gameObject.GetComponent<Rigidbody>();
            Vector3 flyDirection = (other.transform.position - transform.position).normalized;

            Debug.Log("Player collision With" + other.gameObject.name + "With power up set to" + hasPowerup);
            enemyRig.AddForce(flyDirection * powerupStreth, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7f);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}
