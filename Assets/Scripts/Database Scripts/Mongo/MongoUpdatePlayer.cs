using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

public class MongoUpdatePlayer : MonoBehaviour
{
    public InputField playerNameField;
    public InputField newPlayerNameField;
    private MongoCollection<MongoPlayer> playercollection;
    private string connectionString;
    void Start()
    {
        connectionString = "mongodb://localhost:27017";
        //Need this line to work with c# code 
        BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
        var client = new MongoClient(connectionString);
        var server = client.GetServer();
        var database = server.GetDatabase("Final_ProjectDB");
        playercollection = database.GetCollection<MongoPlayer>("Player");

    }

   public void UpdatePlayerName()
    {
        var query = Query<MongoPlayer>.EQ(e => e.playername, playerNameField.text);
        var update = Update<MongoPlayer>.Set(o => o.playername, newPlayerNameField.text);
        playercollection.Update(query, update);
        Debug.Log("Update complete");
    }
}
