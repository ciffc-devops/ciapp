using System.Collections.Generic;
using System.Linq;

namespace WF_ICS_ClassLibrary.Models
{
    public static class AircraftTools
    {
        public static List<string> GetFixedWingTypes(bool includeBlank = false)
        {
            List<string> types = new List<string>();
            types.Add("C177B");
            types.Add("C206");
            types.Add("C208");
            types.Add("BE 1900D");
            types.Add("C 210 T");
            types.Add("C185");
            types.Add("C215");
            types.Add("C215T");
            types.Add("C415T");
            types.Add("C210");
            types.Add("BAE31");
            types.Add("BE100");
            types.Add("BE99");
            types.Add("BN2");
            types.Add("C185");
            types.Add("C207");
            types.Add("DHC2");
            types.Add("PA31");
            types.Add("PA31-300");
            types.Add("B26");
            types.Add("C310");
            types.Add("C130");
            types.Add("C172");
            types.Add("C182");
            types.Add("C180");
            types.Add("C205");
            types.Add("C208");
            types.Add("C207");
            types.Add("C560");
            types.Add("C501");
            types.Add("C414");
            types.Add("C177");
            types.Add("C 210 T");
            types.Add("C500");
            types.Add("CL-215");
            types.Add("L-188");
            types.Add("TC690A");
            types.Add("TS600");
            types.Add("BE20");
            types.Add("BE99");
            types.Add("C185");
            types.Add("C208B");
            types.Add("DCH8-300");
            types.Add("DC8");
            types.Add("DHC3T");
            types.Add("DCHC6");
            types.Add("DHC7");
            types.Add("BE 1900D");
            types.Add("BE100");
            types.Add("BE35");
            types.Add("C441");
            types.Add("DC3");
            types.Add("DC10");
            types.Add("DC4");
            types.Add("TC690B");
            types.Add("340");
            types.Add("A320");
            types.Add("737");
            types.Add("AT401");
            types.Add("AT402");
            types.Add("228-202");
            types.Add("BE20");
            types.Add("AT502B");
            types.Add("AT502A");
            types.Add("AT802");
            types.Add("CL-215T");
            types.Add("TC690A");
            types.Add("DHC5");
            types.Add("C550");
            types.Add("CV58T");
            types.Add("L100");
            types.Add("TC695A");
            types.Add("TC695B");
            types.Add("TC600");
            types.Add("PA35");
            types.Add("P68");
            types.Add("PA18");
            types.Add("PA28");
            types.Add("PA30");
            types.Add("PA34");
            types.Add("PA31");
            types.Add("ATR42");
            types.Add("ATR72");
            types.Add("ATR72CARGO");
            types.Add("DC3T");
            types.Add("SRS60");
            types.Add("S2R");
            types.Add("Q400MR");
            types.Add("RJ100");
            types.Add("RJ85AT");
            types.Add("E-175");
            types.Add("F-CAT");
            types.Add("HS748");
            types.Add("LR55");
            types.Add("PA46");
            types.Add("PA60");
            types.Add("PBY-5A");
            types.Add("PC-12");
            types.Add("BN-2A");
            types.Add("JRM 3");
            types.Add("CV44");
            types.Add("CV58T");

            types = types.OrderBy(o => o).ToList();
            types.Insert(0, string.Empty);

            return types;
        }


        public static List<string> GetHelicopterTypes(bool includeBlank)
        {
            return GetHelicopterTypes(null, includeBlank);
        }

        public static List<string> GetHelicopterTypes(string size = null, bool includeBlank = false)
        {
            List<string> types = new List<string>();
            if (size == null || size.Equals("Light"))
            {

                types.Add("Bell 206B (I-III)");
                types.Add("Bell 206L (C20B)");
                types.Add("Bell 206L (C20R)");
                types.Add("Bell 206L1 (C28)");
                types.Add("Bell 206L1 (C30)");
                types.Add("Bell 206 L3");
                types.Add("EC 120 Colibri");
                types.Add("Hughes 500 D");
                types.Add("MD 520 N");
                types.Add("Robinson R-44 II (RH44)");
                types.Add("Robinson R-66");
                types.Add("SA 341 Gazelle");
            }
            if (size == null || size.Equals("Intermediate"))
            {
                types.Add("A119 Koala");
                types.Add("AS350B");
                types.Add("AS350BA");
                types.Add("AS350 B1");
                types.Add("AS350 B2");
                types.Add("AS350B3");
                types.Add("AS350B3DH");
                types.Add("AS350D");
                types.Add("AS350SD2");
                types.Add("AS350 FX2");
                types.Add("AS355Twin Star");
                types.Add("AS355N");
                types.Add("AS355NP");
                types.Add("Bell 206 L4");
                types.Add("Bell 222");
                types.Add("Bell 407");
                types.Add("Bell 427");
                types.Add("Bell 429");
                types.Add("EC130 B4");
                types.Add("SA315B Lama");
            }
            if (size == null || size.Equals("Medium"))
            {
                types.Add("Bell 204C");
                types.Add("Bell204C (BLR)");
                types.Add("Bell 205A1-17++");
                types.Add("Bell 205B");
                types.Add("Bell 205B (BLR)");
                types.Add("Bell 212HP (BLR)");
                types.Add("Bell 212S");
                types.Add("Bell 412C");
                types.Add("Bell 412C (BLR)");
                types.Add("Bell 412SP");
                types.Add("Bell 412EP");
                types.Add("BK117B");
                types.Add("BK117C");
                types.Add("BK117");
                types.Add("EC135");
                types.Add("EC 135 P2+/T2+, DP, IFR, NVIS");
                types.Add("MD 900");
                types.Add("MD 902");
            }
            if (size == null || size.Equals("Heavy"))
            {
                types.Add("Bell 214B");
                types.Add("Bell 214ST");
                types.Add("Kaman KMax");
                types.Add("Vertol 107");
                types.Add("Sikorsky S-61");
                types.Add("Kamov Ka-32");
                types.Add("Sikorsky S-64E");
            }



            types = types.OrderBy(o => o).ToList();
            types.Insert(0, string.Empty);
            return types;
        }
    }
}
