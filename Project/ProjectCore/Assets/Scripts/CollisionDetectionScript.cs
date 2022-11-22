using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CollisionDetectionScript : MonoBehaviour
{
    public GameObject cube;
    private GameObject characterModel;
    private GameObject trail;
    private AudioSource audio;
    private AudioSource[] audios;
    public int num_of_cubes = 1;

    void Start() {
        
        audios = GetComponents<AudioSource>();
        characterModel = GameObject.Find("CharacterModel");
        trail = GameObject.Find("Trail");
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Finish") {
            GameObject.Find("LevelCompleteCanvas").GetComponent<Canvas>().enabled = true;
            StartCoroutine(NextLevelAfterDelay(2f));
            
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "GreenCube" && (collision.gameObject.GetComponent<initScript>().isCollide == false))
        {

            audios[0].Play();
            collision.gameObject.GetComponent<initScript>().isCollide = true;
            Destroy(collision.gameObject);
            var new_cube = Instantiate(cube, this.gameObject.transform, false);
            new_cube.transform.localPosition = new Vector3(0, 0.04f * num_of_cubes , 0);
            
            trail.transform.SetParent(new_cube.transform);
            //camera.transform.SetParent(new_cube.transform);
            
            characterModel.transform.localPosition = new Vector3(0, 0.04f * num_of_cubes + 0.0215f, 0);
            num_of_cubes += 1;
        }
        if (collision.gameObject.tag == "Enemy") {
            audios[1].Play();
            

            var last_child = collision.GetContact(0).thisCollider; 
            // Debug.Log(last_child.gameObject.name);
            last_child.gameObject.transform.SetParent(null);
            try {
                var lastChild = gameObject.transform.GetChild(1);
                trail.transform.SetParent(lastChild.transform);
                trail.transform.localPosition = new Vector3(0, -0.004f, 0);
            }
            catch (UnityException e) {
                StartCoroutine(RestartLevelAfterDelay(0.1f));
                // GetComponent<PlayerMovement>().enabled = false;
            }
            //Debug.Log(lastChild);
            //camera.transform.SetParent(lastChild.transform);
            //var old_pose = camera.transform.localPosition;
            //camera.transform.localPosition = new Vector3(old_pose.x, 0.035f, old_pose.z);

            
        }
    }
    IEnumerator NextLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 4);
    }

    IEnumerator RestartLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // SceneManager.LoadScene(0);
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<CheckFalling>().enabled = false;
        GameObject.Find("Directional Light").GetComponent<Light>().intensity = 0.0f;
        GameObject.Find("GameOverCanvas").GetComponent<Canvas>().enabled = true;
    }
}
