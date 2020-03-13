// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class mouse_follow : MonoBehaviour
// {

//     private Vector3 mousePosition;
//     private Gamemanager gameManager;
//     public int pointValue;
//     private Rigidbody rb;
//     private Vector3 direction;
//     private float moveSpeed = 200f;

//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         gameManager = GameObject.Find("Game Manager").GetComponent<Gamemanager>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//       if (true) {//Input.GetMouseButton(0)
//         mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         direction = (mousePosition - transform.position).normalized;
//         rb.velocity = new Vector3(direction.x * moveSpeed, direction.y * moveSpeed, direction.z = 0);
//     }
//     else {
//         rb.velocity = Vector3.zero;
//     }
//     }

//     private void OnTriggerEnter (Collider col) {
//       //if(col.gameObject.CompareTag("line"))
//        //{
//        Debug.Log ("MyTag");
//        //}
//        if (gameManager.isGameActive)
//        {
//          if (!gameObject.CompareTag("line")) {
//            //if (gameManager.isGameActive)
//            //{
//              Destroy(gameObject);
//              //Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
//              gameManager.UpdateScore(pointValue);
//          //}
//        }
//      }
//     }
// }
