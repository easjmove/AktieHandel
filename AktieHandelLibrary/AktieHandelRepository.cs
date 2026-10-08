using System;
using System.Collections.Generic;
using System.Text;

namespace AktieHandelLibrary
{
    public class AktieHandelRepository : IAktieHandelRepository
    {
        private int _nextId = 1;
        private List<AktieHandel> handler = new List<AktieHandel>();

        public AktieHandelRepository()
        {
            Add(new AktieHandel() { Navn = "Aktie1", HandelsPris = 5, Antal = 1 });
            Add(new AktieHandel() { Navn = "Aktie2", HandelsPris = 4.7, Antal = 3 });
            Add(new AktieHandel() { Navn = "Aktie3", HandelsPris = 1, Antal = 5 });
            Add(new AktieHandel() { Navn = "Aktie4", HandelsPris = 566, Antal = 2 });
        }

        public AktieHandel Add(AktieHandel nyAktie)
        {
            nyAktie.Id = _nextId++;
            handler.Add(nyAktie);
            return nyAktie;
        }

        public IEnumerable<AktieHandel> GetAll(string? navn = null,
            double? maxPris = null, int? maxAntal = null,
            string? sorterEfter = null,
            bool? sorterStigende = false)
        {
            IEnumerable<AktieHandel> result = handler.AsQueryable();
            if (!string.IsNullOrEmpty(navn))
            {
                result = result.Where(x => x.Navn.Contains(navn, StringComparison.OrdinalIgnoreCase));
            }
            if (maxPris.HasValue)
            {
                result = result.Where(x => x.HandelsPris <= maxPris.Value);
            }
            if (maxAntal.HasValue)
            {
                result = result.Where(x => x.Antal <= maxAntal.Value);
            }

            if (sorterEfter != null)
            {
                //result = sorterEfter.ToLower() switch
                //{
                //    "navn" => sorterStigende ? result.OrderBy(x => x.Navn) : result.OrderByDescending(x => x.Navn),
                //    "handelspris" => sorterStigende ? result.OrderBy(x => x.HandelsPris) : result.OrderByDescending(x => x.HandelsPris),
                //    "antal" => sorterStigende ? result.OrderBy(x => x.Antal) : result.OrderByDescending(x => x.Antal),
                //    _ => throw new ArgumentException($"Ugyldigt sorteringsfelt: {sorterEfter}"),
                //};
            }
            return result;
        }

        public AktieHandel? GetById(int id)
        {
            return handler.FirstOrDefault(x => x.Id == id);
        }

        public AktieHandel? Delete(int id)
        {
            AktieHandel? aktie = GetById(id);
            if (aktie != null)
            {
                handler.Remove(aktie);
            }
            return aktie;
        }

        public AktieHandel? Update(int id, AktieHandel updatedAktie)
        {
            AktieHandel? aktie = GetById(id);
            if (aktie != null)
            {
                aktie.Navn = updatedAktie.Navn;
                aktie.HandelsPris = updatedAktie.HandelsPris;
                aktie.Antal = updatedAktie.Antal;
            }
            return aktie;
        }
    }
}
