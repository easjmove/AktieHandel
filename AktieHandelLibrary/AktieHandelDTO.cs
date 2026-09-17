using System;
using System.Collections.Generic;
using System.Text;

namespace AktieHandelLibrary
{
    public record AktieHandelDTO(
        int Id,
        string Navn,
        double HandelsPris,
        int Antal
    );
}
