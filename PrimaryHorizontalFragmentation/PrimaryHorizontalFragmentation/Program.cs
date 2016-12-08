using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PrimaryHorizontalFragmentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        static List<Models.attribute> relation;
        static List<Models.predicate> pr;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //initializeSampleInput();
            //Services services = new Services();
            //List<Models.predicate> pr_prime = services.getCompleteMininalPredicates(relation, pr);
            //List<string> mintermStrings = services.getMintermPredicates(pr_prime);
            //foreach (string minterm in mintermStrings)
            //    System.Diagnostics.Trace.WriteLine(minterm);
        }

        static void initializeSampleInput()
        {
            relation = new List<Models.attribute>();
            relation.Add(new Models.attribute("PNO", "int", true));
            relation.Add(new Models.attribute("BUDGET", "int", true));
            relation.Add(new Models.attribute("LOC", "string", true));

            pr = new List<Models.predicate>();
            pr.Add(new Models.predicate("LOC", "=", "Paris"));
            pr.Add(new Models.predicate("LOC", "=", "Montreal"));
            pr.Add(new Models.predicate("LOC", "=", "New York"));
            pr.Add(new Models.predicate("BUDGET", "<=", "200000"));
            //pr.Add(new Models.predicate("BUDGET", ">", "200000"));
            //pr.Add(new Models.predicate("PNO", "=", "1"));
        }
    }
}
