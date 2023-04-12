using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using ProjFormula1Mongo;

internal class Program
{
    private static void Main(string[] args)
    {
        MongoClient mongo = new MongoClient("mongodb://localhost:27017");

        var database = mongo.GetDatabase("Formula1");
        var collection = database.GetCollection<BsonDocument> ("Pilotos");
        var documents = collection.Find(new BsonDocument()).ToList();

        #region Exemplos
        ////Show all drivers
        //Console.WriteLine(documents.Count());
        //foreach (var driver in documents )
        //{
        //    Console.WriteLine(driver.ToString());
        //    Console.ReadLine();
        //}

        //// Show the drivers of a inserted team
        //Console.WriteLine("Informe o nome da equipe: ");
        //var t = Console.ReadLine();

        //var filter = Builders<BsonDocument>.Filter.Regex("Team", t);
        //var team = collection.Find(filter).ToList();

        //foreach (var driver in team) 
        //{
        //    Console.WriteLine(driver);
        //}
        #endregion

        #region Find
        ////Show the ToString of a inserted driver
        //Console.WriteLine("Informe o nome do piloto: ");
        //var i = Console.ReadLine();

        //var filter = Builders<BsonDocument>.Filter.Regex("Driver", i);
        //var driverBson = collection.Find(filter).FirstOrDefault();

        //var driver = BsonSerializer.Deserialize<Driver>(driverBson);

        //Console.WriteLine(driver.ToString());
        #endregion

        #region Insert
        //Console.WriteLine("Insira o nome:");
        //string n = Console.ReadLine();

        //Console.WriteLine("\nInsira a abreviação:");
        //string a = Console.ReadLine();

        //Console.WriteLine("\nInsira o número:");
        //int m = int.Parse(Console.ReadLine());

        //Console.WriteLine("\nInsira o time:");
        //string t = Console.ReadLine();

        //Console.WriteLine("\nInsira o país:");
        //string c = Console.ReadLine();

        //Console.WriteLine("\nInsira a data de nascimento:");
        //string d = Console.ReadLine();

        //Driver insertDriver = new(n, a, m, t, c, d);

        //Console.WriteLine(insertDriver.ToString());

        //var dr = new BsonDocument
        //{
        //    {"Driver", insertDriver.Name},
        //    {"Abbreviation", insertDriver.Abbreviation},
        //    {"No", insertDriver.Number},
        //    {"Team", insertDriver.Team},
        //    {"Country", insertDriver.Country},
        //    {"Date of Birth", insertDriver.BirthDate}
        //};

        //Console.WriteLine(dr);
        //collection.InsertOne(dr);
        #endregion

        #region Update
        //Console.WriteLine("Informe o nome do piloto para atualizar: ");
        //var i = Console.ReadLine();

        //var filter = Builders<BsonDocument>.Filter.Regex("Driver", i);
        //var driverBson = collection.Find(filter).FirstOrDefault();

        //var driver = BsonSerializer.Deserialize<Driver>(driverBson);

        //Console.WriteLine("Informe o novo número: ");
        //int num = int.Parse(Console.ReadLine());
        //driver.Number = num;

        //var update = Builders<BsonDocument>.Update.Set("No", driver.Number);

        //collection.UpdateOne(filter, update);
        #endregion

        #region Delete
        Console.WriteLine("Informe o nome do piloto para apagar: ");
        var i = Console.ReadLine();

        var filter = Builders<BsonDocument>.Filter.Eq("Driver", i);
        var driverBson = collection.Find(filter).FirstOrDefault();

        collection.FindOneAndDelete(filter);
        //collection.DeleteOne(filter);
        #endregion
    }
}