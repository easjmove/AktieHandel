using System;
using System.Collections.Generic;
using System.Text;

namespace AktieHandelLibrary
{
    public static class AktieHandelDTOHelper
    {
        public static AktieHandel ToClass(AktieHandelDTO aktieHandel)
        {
            return new AktieHandel()
            {
                Id = aktieHandel.Id,
                Navn = aktieHandel.Navn,
                HandelsPris = aktieHandel.HandelsPris,
                Antal = aktieHandel.Antal
            };
        }
    }
}
