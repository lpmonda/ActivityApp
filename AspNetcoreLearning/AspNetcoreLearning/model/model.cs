namespace AspNetcore1.model
{
    public class MFC
    {
       
            private ModelContext context;

            public int MFCId { get; set; }

            public string Name { get; set; }            

            public int Setpoint { get; set; }

            public int Measure { get; set; }

            public string GasId { get; set; }
        
    }


}
