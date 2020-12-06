using Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static class Hogwarts
    {
        public const string FABIO = "Fábio";
        public const string GONCALO = "Gonçalo";
        public const string LEANDRO = "Leandro";

        public static List<string> CurrentWizards = new List<string>
        {
            FABIO,
            GONCALO,
            LEANDRO
        };        

        public static Wizard SummonWizard(string wizardName, int day)
        {
            Wizard wizard = null;
            switch (day)
            {
                case 1:
                    if (wizardName.Equals(FABIO)) return new Fabio01(FABIO);
                    if (wizardName.Equals(GONCALO)) return new Goncalo01(GONCALO);
                    if (wizardName.Equals(LEANDRO)) return new Leandro01(LEANDRO);
                    break;
                case 2:
                    if (wizardName.Equals(FABIO)) return new Fabio02(FABIO);
                    if (wizardName.Equals(GONCALO)) return new Goncalo02(GONCALO);
                    if (wizardName.Equals(LEANDRO)) return new Leandro02(LEANDRO);
                    break;
                case 3:
                    if (wizardName.Equals(FABIO)) return new Fabio03(FABIO);
                    if (wizardName.Equals(GONCALO)) return new Goncalo03(GONCALO);
                    if (wizardName.Equals(LEANDRO)) return new Leandro03(LEANDRO);
                    break;
                case 4:
                    if (wizardName.Equals(FABIO)) return new Fabio04(FABIO);
                    if (wizardName.Equals(GONCALO)) return new Goncalo04(GONCALO);
                    if (wizardName.Equals(LEANDRO)) return new Leandro04(LEANDRO);
                    break;
            }

            return wizard;
        }
    }
}
