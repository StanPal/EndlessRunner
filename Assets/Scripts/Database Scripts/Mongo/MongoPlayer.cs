using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
public class MongoPlayer
{
    
    public ObjectId Id { get; set; }
    public Int32 playerID { get; set; }
    public string playername { get; set; }
    public int score { get; set; }
    public string logindate { get; set; }
}