using System.Text.Json.Serialization;

namespace Section03.Models
{
    public class Computer
    {
        // Make variables public so that they are accessible outside of the Computer class scope.
        // We make the variables Pascal case without a semicolon, ";" to make them a property of 
        // the Computer class instead of a field of the Computer class.

        // To make them a field of the computer class, we would start the variable with an underscore
        // and make the variable all lower case.  We would also make the variables private .
        // For example:
        // 
        // private string _motherboard;                                                                 <-- Field
        // private string Motherboard {get{return _motherboard;} set{_motherboard = value;}}            <-- Property
        //
        // The property that would be used to get our field or change the value of our field, 
        // which would stay private. This is best practice for managing a field of a model in C#.
        //
        // C# has evolved where you don't have to declare the field because it is done automatically
        // in the background.  So we can get away with declaring only the property.
        // For example:
        //
        // public string Motherboard {get; set;} = "";                                                        <-- Property
        
        [JsonPropertyName("computer_id")]
        public int ComputerId {get; set;}
        [JsonPropertyName("motherboard")]
        public string Motherboard {get; set;} = "";
        [JsonPropertyName("cpu_cores")]
        public int? CPUCores {get; set;} = 0;       // Add a "?" to make the CPUCores nullable.
        [JsonPropertyName("has_wifi")]
        public bool HasWifi {get; set;}
        [JsonPropertyName("has_lte")]
        public bool HasLTE {get; set;}
        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate {get; set;}    // Add a "?" to make the DateTime nullable.
        [JsonPropertyName("price")]
        public decimal Price {get; set;}
        [JsonPropertyName("video_card")]
        public string VideoCard {get; set;} = "";

        // Next we give default values of "" to classes that we want nullable or else the code will 
        // show an error.  

    }
}
