namespace AktieHandelLibrary
{
    public interface IAktieHandelRepository
    {
        AktieHandel Add(AktieHandel nyAktie);
        AktieHandel? Delete(int id);
        IEnumerable<AktieHandel> GetAll(string? navn = null, 
            double? maxPris = null, 
            int? maxAntal = null, 
            string? sorterEfter = null,
            bool? sorterStigende = false);
        AktieHandel? GetById(int id);
        AktieHandel? Update(int id, AktieHandel updatedAktie);
    }
}