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
            //Only adults are included
            string[] AllNames = GetNamesOfAdults(people);
            List<Person> AllPeople = GetAdults(people); 

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

            foreach (int i in RANGE)
            {
                string currentPerson = AllNames[i];

                //Can't buy for yourself
                solver.Add(santas[i] != i);

                //Can't buy for people in same family group
                foreach (string familyMember in GetFamilyGroupMembers(currentPerson, AllPeople))
                {
                    solver.Add(CantBuyFor(currentPerson, familyMember, AllNames, santas));
                }

                //Constraints based on history
                foreach (SecretSantaDraw previousDraw in previousDraws)
                {
                    if (previousDraw.Draw.ContainsKey(currentPerson))
                    {
                        string previousRecipient = previousDraw.Draw[currentPerson];
                        
                        //Can't buy for who you previously bought for
                        solver.Add(CantBuyFor(currentPerson, previousRecipient, AllNames, santas));

                        //Your partner(s) can't buy for previousRecipient
                        foreach (string partner in GetImmediateFamilyMembers(currentPerson, AllPeople))
                        {
                            solver.Add(CantBuyFor(partner, previousRecipient, AllNames, santas));
                        }

                        //Can't buy for previousRecipient's partner(s)
                        foreach (string partner in GetImmediateFamilyMembers(previousRecipient, AllPeople))
                        {
                            solver.Add(CantBuyFor(currentPerson, partner, AllNames, santas));
                        }


                    }

                }

                //Constraints based on potential solutions

                //TODO - Partners don't buy for other partners


            }

            solver.Add(solver.MakeCircuit(santas));

            ////Custom constraints
            //solver.Add(CantBuyFor("Homer", "Fred", AllNames, santas));
            //solver.Add(CantBuyFor("Homer", "Peter", AllNames, santas));

            //solver.Add(CantBuyFor("Peter", "Homer", AllNames, santas));
            //solver.Add(CantBuyFor("Peter", "Fred", AllNames, santas));

            //solver.Add(CantBuyFor("Fred", "Homer", AllNames, santas));
            //solver.Add(CantBuyFor("Fred", "Peter", AllNames, santas));

            //
            // Search
            //
            DecisionBuilder db = solver.MakePhase(santas,
                                                Solver.INT_VAR_SIMPLE,
                                                Solver.INT_VALUE_SIMPLE);

            solver.NewSearch(db);

            if (solver.NextSolution())
            {

                Dictionary<string, string> result = new Dictionary<string, string>();

                foreach (int i in RANGE)
                {
                    result[AllNames[i]] = AllNames[santas[i].Value()];
                }

                return new SecretSantaDraw("Result:" + DateTime.Now.Ticks, result);

            }
            else
            {
                return null;
            }
        }

        private static Constraint CantBuyFor(string giftGiver, string recipient, string[] allNames, IntVar[] decisionArray)
        {
            int giftGiverIndex = Array.IndexOf(allNames, giftGiver);
            int recipientIndex = Array.IndexOf(allNames, recipient);

            if (giftGiverIndex >= 0 && recipientIndex >= 0)
            {
                return decisionArray[giftGiverIndex] != recipientIndex;
            } else {
                //Ineffective constraint, as in this situation want to not apply a contstraint.
                //This constraint (first person cannot buy for themself) is ineffectual, as already added.
                return decisionArray[0] != 0;
            }
        }

        private static string[] GetNamesOfAdults(List<Person> people)
        {
            return people.Where(p => p.Tags["IsChild"] != "True").Select(x => x.Name).ToArray();
        }

        private static List<Person> GetAdults(List<Person> people)
        {
            return people.Where(p => p.Tags["IsChild"] != "True").ToList();
        }

        private static string[] GetImmediateFamilyMembers(Person subject, List<Person> allPeople)
        {

            return allPeople.Where(x => x.Name != subject.Name)
                            .Where(y => y.Tags["ImmediateFamily"] == subject.Tags["ImmediateFamily"])
                            .Select(z => z.Name)
                            .ToArray();
        }

        private static string[] GetImmediateFamilyMembers(string personName, List<Person> allPeople)
        {
            try {
                return GetImmediateFamilyMembers(allPeople.Where(x => x.Name == personName).Single(), allPeople);
            } catch
            {
                //Happens if a person in a previous draw has since been excluded
                return new string[0];
            }
        }

        private static string[] GetFamilyGroupMembers(Person subject, List<Person> allPeople)
        {
            return allPeople.Where(x => x.Name != subject.Name)
                .Where(y => y.Tags["FamilyGroup"] == subject.Tags["FamilyGroup"])
                .Select(z => z.Name)
                .ToArray();
        }

        private static string[] GetFamilyGroupMembers(string personName, List<Person> allPeople)
        {
            try {
                return GetFamilyGroupMembers(allPeople.Where(x => x.Name == personName).SingleOrDefault(), allPeople);
            } catch
            {
                //Happens if a person in a previous draw has since been excluded
                return new string[0];
            }
        }
    }
}
