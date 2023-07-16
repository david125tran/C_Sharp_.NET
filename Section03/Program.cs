using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Numerics;
using Microsoft.Extensions.Configuration;
using Section03.Data;
using Section03.Models;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AutoMapper;

namespace Section03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------------- Load the JSON SQL connection string (Microsoft Users) -------------------
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build(); 

            // #################################################################################
            // #                SQL Executions (Method 1): The Dapper Method                   #
            // #################################################################################

            // ------------------- Querying the SQL database -------------------
            Console.WriteLine("Dapper Method:\n");

            // ---(1)--- Access our DataContextDapper class and it's public methods by passing in our connection 
            // string to make a connection
            DataContextDapper dapper = new DataContextDapper(config);
            
            // ---(2)--- Form a SQL command as a string
            string sqlCommand = "SELECT GETDATE()";

            // ---(3)--- Execute the SQL command with our dapper class LoadDataSingle() method
            DateTime rightNow = dapper.LoadDataSingle<DateTime>(sqlCommand);
            Console.WriteLine(rightNow.ToString());


            // ------------------- Writing to the SQL database -------------------

            // ---(1)--- Create a variable of our Computer() class & assign values we want passed in
            Computer myComputer = new Computer()
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 260"
            };

            // ---(2)--- Create a string with an "@" symbol which allows us to write multiple lines in a single string
            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES ('" + myComputer.Motherboard
                    + "','" + myComputer.HasWifi
                    + "','" + myComputer.HasLTE
                    + "','" + myComputer.ReleaseDate
                    + "','" + myComputer.Price
                    + "','" + myComputer.VideoCard
            + "')";

            // ---(3)--- Execute the SQL command by accessing the .ExecuteSql() method of our DataContextDapper class
            bool result = dapper.ExecuteSql(sql);

            // ---(4)--- The result printed/returned will be the number of rows affected
            int rows_affected = dapper.ExecuteSqlWithRowCount(sql);
            Console.WriteLine(rows_affected);  // Returns 1 because 1 row was inserted

            // ------------------- Querying the SQL database -------------------

            // ---(1)--- Form a SQL statement as a string
            
            // It is best practice to start with the prefix of the table's name because it is less confusing when dealing 
            // with multiple tables.  For example: "Computer.Motherboard" instead of "Motherboard". In our schema in Azure, 
            // we named the table "Computer" however here in C#, we named the table "myComputer".  Here, we will query for 
            // "Computer", for example: "Computer.Motherboard" because our code is being passed into MS SQL & needs to match.  
            
            string sqlSelect = @"
            SELECT 
                Computer.ComputerId,
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
             FROM TutorialAppSchema.Computer";

            // ---(2)--- Make a query connection 
            
            // Make the connection as an IEnumerable data type because the data will come back as this data type.  If you 
            // make it come back as different data types, the code will error out unless you explicitly convert the data 
            // to a different type. Pass in the "sqlSelect" string as an argument to our LoadData() method of our 
            // DataContextDapper class.  

            IEnumerable <Computer> computers  = dapper.LoadData<Computer>(sqlSelect);
            
            // ---(3)--- Add headers for clarity in the Window's Powershell:
            Console.WriteLine("'ComputerId', 'Motherboard', 'HasWifi', 'HasLTE', 'ReleaseDate', 'Price', 'VideoCard'");
            
            // ---(4)--- Loop through each row of the Computer MS SQL table and write to the console:
            foreach(Computer singleComputer in computers)
            {
                Console.WriteLine("'" + singleComputer.ComputerId
                    + "','" + singleComputer.Motherboard
                    + "','" + singleComputer.HasWifi
                    + "','" + singleComputer.HasLTE
                    + "','" + singleComputer.ReleaseDate
                    + "','" + singleComputer.Price
                    + "','" + singleComputer.VideoCard + "'");
            }







            // #################################################################################
            // #       SQL Executions (Method 2): The MicroSoft Entity Framework Method        #
            // #################################################################################

            // The Microsoft Entity Framework Method is ideal for people that don't know SQL language.
            // It takes a little more work setting up in C# than the dapper method.  

            // ------------------- Writing to the SQL database -------------------
            Console.WriteLine("\nMicrosoft Entity Framework Method:\n");

            // ---(1)--- Access our DataContextEF class and it's public methods by passing in our connection 
            // string to make a connection
            DataContextEF entityFramework = new DataContextEF(config);     

            // ---(2)--- Add the table row
            entityFramework.Add(myComputer);

            // ---(3)--- Save the changes
            entityFramework.SaveChanges();

            IEnumerable <Computer>? computersEf  = entityFramework.Computer?.ToList<Computer>();
            
            // ---(4)--- Add headers for clarity in the Window's Powershell:
            Console.WriteLine("'ComputerId', 'Motherboard', 'HasWifi', 'HasLTE', 'ReleaseDate', 'Price', 'VideoCard'");
            
            // ---(5)--- Loop through each row of the Computer MS SQL table and write to the console:
            if (computersEf != null)
            {
                foreach(Computer singleComputer in computersEf)
                {
                    Console.WriteLine("'" + singleComputer.ComputerId
                        + "','" + singleComputer.Motherboard
                        + "','" + singleComputer.HasWifi
                        + "','" + singleComputer.HasLTE
                        + "','" + singleComputer.ReleaseDate
                        + "','" + singleComputer.Price
                        + "','" + singleComputer.VideoCard + "'");
                }
            }







            // #################################################################################
            // #                         Writing to a text (.txt) file                         #
            // #################################################################################

            // ------------------- Writing a new file (overides old files) -------------------
            // File.WriteAllText("log.txt", sql);                
            
            // ------------------- Writing a new file or apending to bottom of old file -------------------
            // ------------------- (Doesn't overide old file) -------------------
            using StreamWriter openFile = new("log.txt", append: true);     
            openFile.WriteLine(sql + "\n");    
            // Close the file so that another program can use it:
            openFile.Close(); 

            // ------------------- Reading a text file -------------------
            string FileText = File.ReadAllText("log.txt");
            // Console.WriteLine(FileText);








            // #################################################################################
            // #        Dealing w/JSON (.json) file (Method 1): Newtonsofts Json.NET           #
            // #################################################################################

            // ---(1)--- Read the file -------------------
            string computerJson = File.ReadAllText("Computers.json");

            // ---(2)--- Deserialize the file (Convert JSON string to object) 
            IEnumerable<Computer>? computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computerJson);

            // ---(3)--- Execute the SQL statement
            // We 1st build a helper function that escapes single quotes.  Because some of our SQL entries will have single quotes
            // that will break the code if they are not dealt with.
            static string EscapeSingleQuote(string input)
            {
                string output = input.Replace("'", "''");
                return output;
            }

            // We use the EscapeSingleQuote() helper function on our columns that are of string data type.
            if (computersNewtonSoft != null)
            {
                foreach (Computer computer in computersNewtonSoft)
                {
                    string computersSql = @"INSERT INTO TutorialAppSchema.Computer (
                    Motherboard,
                    HasWifi,
                    HasLTE,
                    ReleaseDate,
                    Price,
                    VideoCard
                    ) VALUES ('" + EscapeSingleQuote(computer.Motherboard)
                        + "','" + computer.HasWifi
                        + "','" + computer.HasLTE
                        + "','" + computer.ReleaseDate
                        + "','" + computer.Price
                        + "','" + EscapeSingleQuote(computer.VideoCard)
                    + "')";

                    dapper.ExecuteSql(computersSql);
                }
            }

            // ---(4)--- Serialize the object (Convert object to JSON string) 
            // Tap into our JsonSerializerSettings() to write in lowerCamelCase    
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            // Pass in our settings as an argument:
            string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtonSoft, settings);

            // ---(5)--- Write the JSON string to a text file (.txt) 
            File.WriteAllText("computersCopyNewtonsoft.txt", computersCopyNewtonsoft);
            








            // #################################################################################
            // #     Dealing w/JSON (.json) file (Method 2): Microsoft's System.Text.Json      #
            // #################################################################################

            // ---(1)--- Read the file -------------------
            // string computerJson = File.ReadAllText("Computers.json");        // We already did this step during the Newtonsoft method

            // ---(2)--- Deserialize the file (Convert JSON string to object) 
            // The default naming convention for JSON files is lowerCamelCase which doesn't match our naming convention
            // for our table column names.  We tap into our JsonSerializer options to alter the naming convention: 
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            // Pass in our options as an argument:
            IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computerJson, options);
            
            // ---(3)--- Serialize the object (Convert object to JSON string) 
            // Pass in our options as an argument:
            string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);
            
            // ---(4)--- Write the JSON string to a text file (.txt) 
            File.WriteAllText("computersCopySystem.txt", computersCopySystem);
            








            // #################################################################################
            // #      Reading a JSON file (.json) written in snakecase (Method 1): Mapper      #
            // #################################################################################
            Console.WriteLine("\nREADING A JSON FILE IN SNAKE CASE (Method 1: Mapper)\n");

            // ---(1)--- Read the file -------------------
            string computerStringMapper = File.ReadAllText("ComputersSnake.json");

            // ---(2)--- Map from source model to destination model and explicitly state which fields match to which fields: 
            Mapper mapper = new Mapper(new MapperConfiguration((cfg) => {
                cfg.CreateMap<ComputerSnake, Computer>()
                    .ForMember(destination => destination.ComputerId, options =>
                        options.MapFrom(source => source.computer_id))
                    .ForMember(destination => destination.CPUCores, options =>
                        options.MapFrom(source => source.cpu_cores))
                    .ForMember(destination => destination.HasLTE, options =>
                        options.MapFrom(source => source.has_lte))
                    .ForMember(destination => destination.HasWifi, options =>
                        options.MapFrom(source => source.has_wifi))
                    .ForMember(destination => destination.VideoCard, options =>
                        options.MapFrom(source => source.video_card))
                    .ForMember(destination => destination.ReleaseDate, options =>
                        options.MapFrom(source => source.release_date))
                    .ForMember(destination => destination.Price, options =>
                        options.MapFrom(source => source.price));
            }));

            // ---(3)--- Deserialize the file (Convert JSON string to object) 
            IEnumerable<ComputerSnake>? computersSystemMapperMethod = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computerStringMapper);

            // ---(4)--- Write the results (of the "ComputerSnake.json" motherboard column)
            if (computersSystemMapperMethod != null)
            {
                IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computersSystemMapperMethod);
                foreach (Computer computer in computerResult)
                {
                    Console.WriteLine(computer.Motherboard);
                }
            }
            








            // ##########################################################################################
            // #  Reading a JSON file (.json) written in snakecase (Method 2): JSON Property Attribute  #
            // ##########################################################################################
            Console.WriteLine("\nREADING A JSON FILE IN SNAKE CASE (Method 2: JSON Property Attribute)\n");

            // ---(1)--- Read the file -------------------
            string computerStringJsonPropertyAttribute = File.ReadAllText("ComputersSnake.json");     

            // ---(2)--- Add the JSON property attribute
            // Go into the "Computer.cs" file and add each attribute to each column name so that the column 
            // names of "Computer.cs" matches the column names of "ComputersSnake.json".
            // For example:
            // public int ComputerId {get; set;}
            // [JsonPropertyName("motherboard")]

            // ---(3)--- Deserialize the file (Convert JSON string to object) 
            IEnumerable<Computer>? computersSystemJsonPropertyAttribute = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computerStringJsonPropertyAttribute);
            
            // ---(4)--- Write the results (of the "ComputerSnake.json" motherboard column)
            if (computersSystemJsonPropertyAttribute != null)
            {
                foreach (Computer computer in computersSystemJsonPropertyAttribute)
                {
                    Console.WriteLine(computer.Motherboard);
                }
            }
        }

    }
}





