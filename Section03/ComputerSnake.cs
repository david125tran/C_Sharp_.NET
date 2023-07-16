namespace Section03.Models
{
    public class ComputerSnake
    {
        public int computer_id {get; set;}
        public string motherboard {get; set;} = "";
        public int? cpu_cores {get; set;} = 0;       // Add a "?" to make the cpu_cores nullable.
        public bool has_wifi {get; set;}
        public bool has_lte {get; set;}
        public DateTime? release_date {get; set;}    // Add a "?" to make the DateTime nullable.
        public decimal price {get; set;}
        public string video_card {get; set;} = "";

        // We give default values of "" to classes that we want nullable or else the code will 
        // show an error.  

    }
}
