﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Author: Aiden Cran
/// Date: 9/10/2020
/// 
/// This script is applied on the start button in the menu scene. It's purpose is to check for a player name before proceeding.
/// If the name or file directory is not found, a new save file will be created and an input field will be opened.
/// This Input field will save the set name to a save file and will allow the user to proceed to the stage selection scene.
/// </summary>
public class StartButton : MonoBehaviour
{
    //Directly references PlayerData
    public PlayerData pd;

    //References the different UI elements
    public GameObject StartMenu;
    public GameObject StageSelection;
    public GameObject InputField;

    ////Used to check whether the path exists
    public static string directory = "/SaveData/";
    public static string fileName = "playerData.txt";

    public void Start()
    {
        //On start will load the data from the file
        pd = SaveManager.Load();
    }

    public void PlayerNameCheck()
    {
        //States the path to the data file
        string fullPath = Application.persistentDataPath + directory + fileName;


        //Checks if the file read anything, and if the file exists
        //If player equals something and the file exists then the scene continues
        //If there's no player name is read, or the path doesn't exist then it creates a path and sets the input field active

        //PROBLEM:
        //Pd.playername != "" - Should prevent the player from continuing if the string is empty
        //However this doesn't prevent the player from continuing....
        //I also tried this - string.IsNullOrEmpty(pd.playerName)
        //However it still allows the player to continue on, as if they had a built string.
        if (pd.playerName != "" && File.Exists(fullPath))
        {
            //Change Scene
            StageSelection.SetActive(true);
            StartMenu.SetActive(false);
        }
        else
        {
            //Rebuilds file directory incase
            SaveManager.Save(pd);
            //Allows user to input data
            InputField.SetActive(true);
        }
    }
}
