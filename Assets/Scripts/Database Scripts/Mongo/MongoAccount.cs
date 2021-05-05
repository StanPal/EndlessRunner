using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

using System;

public class MongoAccount
{
    public ObjectId Id { get; set; }
    public Int32 playerID { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string nickname { get; set; }
    public string email { get; set; }
    public string DOB { get; set; }
    public Int32 optin { get; set; }
}
