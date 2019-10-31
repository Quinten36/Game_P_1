using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(AudioSource))]
public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private Gamemanager gameManager;
    private PauseMenu pauseMenu;
    private float minSpeed = 12;
    private float maxSpeed = 15;
    private float maxTorque = 15;
    private float xRange = 6;
    private float ySpawnPos = -2;

    public ParticleSystem explosionParticle;
    public int pointValue;

    //public AudioClip Swiping;

    public float doubleTimer = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<Gamemanager>();
        pauseMenu = GameObject.Find("PauseMenuController").GetComponent<PauseMenu>();


        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();

         //AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnMouseOver()
    {
      if (gameManager.isGameActive)
      {
        if (!pauseMenu.isPaused) 
        {
          if (gameObject.CompareTag("double")) {
            gameManager.doubleScore = true;
          }
          //audio.Play();
          //yield return new WaitForSeconds(audio.clip.length);
          //audio.clip = Swiping;
          //audio.Play();
          Destroy(gameObject);
          Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
          gameManager.UpdateScore(pointValue);
        }
      }
    }
  
    private void OnTriggerEnter(Collider other)
    { 
         if (gameManager.isGameActive)
         {
            //if (gameObject.CompareTag("double"))
            //{
            //    ActivatePowerup();
            //    Debug.Log("hh");
            //}
               
                Destroy(gameObject);
        if (!gameObject.CompareTag("Bad")) {
          if (!gameObject.CompareTag("double")) {
            //gameManager.GameOver();
          }
        }
      //}
    }
    }

    public IEnumerator Slowmo()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(5);
        Time.timeScale = 1f;
    }

    public void ActivatePowerup()
    {
        StartCoroutine("DubbelScore");
    }

    public IEnumerator DubbelScore()
    {
        gameManager.multiplier = 2;
        yield return new WaitForSeconds(5);
        gameManager.multiplier = 1;
        Debug.Log(gameManager.multiplier);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }
}




//if (gameObject.CompareTag("Slow"))
//{
//    StartCoroutine("Slowmo");
//}

//   if (!gameObject.CompareTag("line")) {

// while (doubleTimer != 0.0f) {
//   doubleScore = false;
// }
//Debug.Log(doubleScore);


//if (gameManager.doubleScore == true) {
//  doubleTimer -= Time.deltaTime;
//     if(doubleTimer < 0.0f)
//     {
//         gameManager.doubleScore = false;
//         Debug.Log("timer off");
//     }
//}