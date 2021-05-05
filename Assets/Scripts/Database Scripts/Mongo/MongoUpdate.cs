using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

public class MongoUpdate : MonoBehaviour
{
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

        Debug.Log(MongoDBQuery.loggedin);
        if (GetName.usingMongoDB)
        {
            var query = Query<MongoPlayer>.EQ(e => e.playername, MongoDBQuery.loggedin);
            var update = Update<MongoPlayer>.Set(o => o.score, PlayerData.gethighscore);
            playercollection.Update(query, update);
            Debug.Log("Update complete");
        }
    }
}
