using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is to be attached to a GameObject called GameManager in the scene. It is to be used to manager the settings and overarching gameplay loop.
/// </summary>
public class GameManager : MonoBehaviour
{
    

    [Header("Playable Area")]
    public float levelConstraintTop = 15; //The maximum positive Y value of the playable space.
    public float levelConstraintBottom = -15; //The maximum negative Y value of the playable space.
    public float levelConstraintLeft = -5; //The maximum negative X value of the playable space.
    public float levelConstraintRight = 5; //The maximum positive X value of the playablle space.



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
