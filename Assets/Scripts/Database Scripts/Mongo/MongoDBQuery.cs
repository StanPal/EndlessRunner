using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;


public class MongoDBQuery : MonoBehaviour
{

    public InputField playerNameField;
    public InputField firstnameField;
    public InputField lastnameField;
    public InputField nicknameField;
    public InputField Dobfield;
    public InputField emailField;
    public Toggle optinToggle;

    public InputField scoreField;

    public static string loggedin { get; set; }
    private string connectionString;
    private MongoCollection<MongoPlayer> playercollection;
    private MongoCollection<MongoAccount> accountcollection;
    MongoPlayer findplayer = new MongoPlayer();
    void Start()
    {
        connectionString = "mongodb://localhost:27017";
        //Need this line to work with c# code 
        BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
        var client = new MongoClient(connectionString);
        var server = client.GetServer();
        var database = server.GetDatabase("Final_ProjectDB");
        playercollection = database.GetCollection<MongoPlayer>("Player");
        accountcollection = database.GetCollection<MongoAccount>("Account");

    }

    public void LogIn()
    {
        loggedin = playerNameField.text;
        var query = Query<MongoPlayer>.EQ(e => e.playername, loggedin);
        var update = Update<MongoPlayer>.Set(o => o.logindate, DateTime.Now.ToShortDateString());
        playercollection.Update(query, update);
        SceneManager.LoadScene(4);
    }

    public void FindAccount()
    {
        var findaccount = new MongoAccount();
        var query = Query<MongoAccount>.EQ(e => e.firstname, playerNameField.text);
        findaccount = accountcollection.FindOne(query);
        if (findaccount != null)
        {
            Debug.Log("Firstname: " + findaccount.firstname + " Lastname: " + findaccount.lastname + " Nickname: " + findaccount.nickname
                + " DOB: " + findaccount.DOB + " OptIn: " + findaccount.optin);

        }
        else
        {
            Debug.Log("Cannot find account");
        }
    }

    public void FindMax()
    {
        var max = playercollection.FindAll().SetSortOrder(SortBy.Descending("score")).SetLimit(1).ToJson();   
        Debug.Log(max);
    }

    public void FindScoreRange()
    {
        var rangequery = Query<MongoPlayer>.GT(e => e.score, int.Parse(scoreField.text));
        var playerrange = playercollection.Find(rangequery).SetLimit(10).ToJson();
        Debug.Log(playerrange);
    }

    public void FindPlayer()
    {
        var query = Query<MongoPlayer>.EQ(e => e.playername, playerNameField.text);
        findplayer = playercollection.FindOne(query);
        if (findplayer != null)
        {
            Debug.Log("playername: " + findplayer.playername + " score: " + findplayer.score + " login date: " + findplayer.logindate);
        }
        else
        {
            Debug.Log("Cannot find player");
        }
    }

    public void RemovePlayer()
    {
        Debug.Log("Collection count before remove: " + playercollection.Count());
        var query = Query<MongoPlayer>.EQ(e => e.playername, playerNameField.text);
        playercollection.Remove(query);
        Debug.Log(playerNameField.text + " removed");
        Debug.Log("Collection count after remove: " + playercollection.Count());
    }

    public void RemoveAccount()
    {
        Debug.Log("Collection count before remove: " + accountcollection.Count());
        var query = Query<MongoAccount>.EQ(e => e.firstname, playerNameField.text);
        accountcollection.Remove(query);
        Debug.Log(playerNameField.text + " removed");
        Debug.Log("Collection count after remove: " + accountcollection.Count());
    }

    public void InsertPlayer()
    {
        int iOptin = optinToggle ? 1 : 0;
        var newaccount = new MongoAccount
        {
            playerID = (int)playercollection.Count(),
            firstname = firstnameField.text,
            lastname = lastnameField.text,
            nickname = nicknameField.text,
            DOB = Dobfield.text,
            email = emailField.text,
            optin = iOptin
        };
        var newplayer = new MongoPlayer
        {
            playerID = (int)playercollection.Count(),
            playername = playerNameField.text,
            logindate = DateTime.Now.ToShortDateString(),
            score = 0
        };
        playercollection.Insert(newplayer);
        Debug.Log("\n Mongo DB Player Inserted \n");
        accountcollection.Insert(newaccount);
        Debug.Log("\n Mongo DB Account Inserted \n");
    }
}