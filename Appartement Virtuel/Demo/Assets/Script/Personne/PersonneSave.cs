using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class PersonneSave : MonoBehaviour
{

    string path = "Assets\\Script\\Personne\\Log";
    public Transform body;
    string filename;
    public GameObject personne;
    public int nb = 1;

    // Use this for initialization
    void Awake()
    {
        if (!System.IO.File.Exists(path + "\\personne" + nb + ".txt"))
        {
            //save();
        }
        else
        {
           // load();
        }
    }

    void load()
    {
           // if(System.IO.File.Exists(filename))
            nb = PlayerPrefs.GetInt("nombre");
            //nb++;
            filename = path + "\\personne" + nb + ".txt";
            StreamWriter sw = new StreamWriter(filename);
            sw.Close();
            PlayerPrefs.SetInt("nombre", nb);
            print("save: " + nb);
    }

    void save()
    {
        PlayerPrefs.SetInt("nombre", nb);
        //nb = PlayerPrefs.GetInt("nombre");
        filename = path + "\\personne" + nb + ".txt";
        StreamWriter sw = new StreamWriter(filename);
        print("save: 1 " + PlayerPrefs.GetInt("nombre"));
        sw.Close();
        // PlayerPrefs.SetInt("nombre", nb);
        //nb = PlayerPrefs.GetInt("nombre");
        // log(filename);
    }




    /*void OnTriggerStay(Collider collider)
    {
        {
            if (collider.gameObject.tag == "cuisine")
            {

                filename = path + "\\personne" + nb + ".txt";
                //  print("count: " + save.count);

                StreamWriter writer = new StreamWriter(filename, true);

                writer.WriteLine("position dans cuisine, x:" + body.position.x + " y:" + body.position.y + " z:" + body.position.z + " Time: " + System.DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"));
                writer.Flush();
                writer.Close();

            }

            if (collider.gameObject.tag == "douche")
            {

                filename = path + "\\personne" + nb + ".txt";
                //  print("count: " + save.count);

                StreamWriter writer = new StreamWriter(filename, true);

                writer.WriteLine("position dans la salle de bain, x:" + body.position.x + " y:" + body.position.y + " z:" + body.position.z + " Time: " + System.DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"));
                writer.Flush();
                writer.Close();

            }
            if (collider.gameObject.tag == "chambre")
            {

                filename = path + "\\personne" + nb + ".txt";
                //  print("count: " + save.count);

                StreamWriter writer = new StreamWriter(filename, true);

                writer.WriteLine("position dans la chambre, x:" + body.position.x + " y:" + body.position.y + " z:" + body.position.z + " Time: " + System.DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"));
                writer.Flush();
                writer.Close();

            }
            if (collider.gameObject.tag == "sejour")
            {

                filename = path + "\\personne" + nb + ".txt";
                //  print("count: " + save.count);

                StreamWriter writer = new StreamWriter(filename, true);

                writer.WriteLine("position dans le sejour, x:" + body.position.x + " y:" + body.position.y + " z:" + body.position.z + " Time: " + System.DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"));
                writer.Flush();
                writer.Close();

            }
        }
    }

    void OnApplicationQuit()
    {
        nb++;
        PlayerPrefs.SetInt("nombre", nb);
        
        print(" personneSave: " + PlayerPrefs.GetInt("nombre"));
    }*/
}
    [Serializable]
    class Personne
    {
        public float x, y, z;
        public int nombre;
        public string date;
    }


