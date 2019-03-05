using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class LogFile : MonoBehaviour
{
    public static LogFile sharedInstance;

    //Variables for output to log file
    public static string preamble = "";
    public static string filename = "";
    public static string logfile = "";

    void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        //initialize log file name based on current date and time
        DateTime dt = DateTime.Now;
        preamble = "Assets/Resources/";
        filename = "log_" + dt.ToString("yyyy-MM-dd_HH-mm-ss");
        logfile = preamble + filename + ".txt";
    }

    // write an entry to the log file
    public static void WriteBioLog(string entry)
    {
        if (!File.Exists(logfile))
        {
            StreamWriter testing = File.CreateText(logfile);
            testing.Close();
        }
        //Write some text to the test.txt file
        StreamWriter writer = File.AppendText(logfile);
        writer.WriteLine(entry);
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(logfile);
        TextAsset asset = Resources.Load(filename) as TextAsset;

        //Print the text from the file
        Debug.Log(asset.text);
    }
}
