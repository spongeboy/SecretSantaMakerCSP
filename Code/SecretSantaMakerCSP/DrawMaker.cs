using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecretSantaMakerCSP.DomainObjects;
using Google.OrTools.ConstraintSolver;

namespace SecretSantaMakerCSP
{
    public class DrawMaker
    {

        public SecretSantaDraw MakeNextDraw(List<Person> people, List<SecretSantaDraw> previousDraws)
        {
            string[] AllNames = people.Select(x => x.Name).ToArray();

            Solver solver = new Solver("XmasDraw");

            int n = AllNames.Count();
            IEnumerable<int> RANGE = Enumerable.Range(0, n);

            //
            // Decision variables
            //
            IntVar[] santas = solver.MakeIntVarArray(n, 0, n - 1, "santas");

            //
            // Constraints
            //
            solver.Add(santas.AllDifferent());

            solver.MakeCircuit(santas);

            //
            // Search
            //
            DecisionBuilder db = solver.MakePhase(santas,
                                                  Solver.INT_VAR_SIMPLE,
                                                  Solver.INT_VALUE_SIMPLE);

            solver.NewSearch(db);

            if (solver.NextSolution()) {

                Dictionary<string, string> result = new Dictionary<string, string>();

                foreach (int i in RANGE)
                {
                    result[AllNames[i]] = AllNames[santas[i].Value()];
                }

                return new SecretSantaDraw("Result:" + DateTime.Now.Ticks, result);

            } else
            {
                return null;
            }
        }




    }
}
