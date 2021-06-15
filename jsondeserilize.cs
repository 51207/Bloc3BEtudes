using System;
using System.Collections.Generic;
using System.Text;
//using Newtonsoft.Json;
using System.IO;
using System.Text.Json;

namespace astroroad99 {
    
    public class jsondeserialize { 

       
    //[JsonObject(MemberSerialization.OptIn)]
    
    public class Example
    {
          
            public double timestamp { get; set; }
        //[JsonProperty]
    
        public Data data { get; set; }
        // [JsonProperty]
       
        public string version { get; set; }
        //  [JsonProperty]
        
        public string tagId { get; set; }
        // [JsonProperty]
        
        public bool success { get; set; }
    }
     
        public jsondeserialize() { }

             


      
        public class Sensor
        {
            public string name { get; set; }
            public string value { get; set; }
        }
       
        public class TagData
        {
            public IList<Sensor> sensors { get; set; }
            public int blinkIndex { get; set; }
        }


        public class Coordinates
        {
          

           public int y { get; set; }
            public int x { get; set; }
            public int z { get; set; }
        }
      
        public class AnchorData
        {
            public string anchorId { get; set; }
            public string tagId { get; set; }
            public double rss { get; set; }
        }
       
        public class Rates
        {
            public double update { get; set; }
            public double success { get; set; }
            public double packetLoss { get; set; }
        }
        
        public class Metrics
        {
            public Rates rates { get; set; }
            public int latency { get; set; }
        }
      
        public class Extras
        {
            public string version { get; set; }
            public IList<object> zones { get; set; }
        }
     
        public class Data
        {

            

            public int coordinatesType { get; set; }
            public TagData tagData { get; set; }
            public Coordinates coordinates { get; set; }
            public IList<AnchorData> anchorData { get; set; }
            public Metrics metrics { get; set; }
            public Extras extras { get; set; }
        }
      

    }

}
    

