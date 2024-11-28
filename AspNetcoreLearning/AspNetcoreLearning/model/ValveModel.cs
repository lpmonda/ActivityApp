namespace AspNetcore1.model
{
   
        public class Valve
        { 
            public required string SerialNumber { get; set; }
            public required string Name { get; set; }
            public required int Type { get; set; }
            public required string units{ get; set; }
            public float minVolt { get; set; }
            public float maxVolt { get; set; }
            public virtual required Manufacturer Manufacturer { get; set; }
        }

        public class Manufacturer
        {
            public int ID { get; set; }
            public required string Name { get; set; }
           
        }
    
}
