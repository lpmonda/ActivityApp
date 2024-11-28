namespace AspNetcore1.Dto
{
    /* public record class Dto(
     string Name,
     string Description,
     int NoOfChapters,
     string InstructorId
 );*/

   public record class Dto(   
   int heartbeat     
    );

    public record class MFC(
        int MFCId,
        string Name,
        int Setpoint,
        int Measure,
        string GasId
      );
}
