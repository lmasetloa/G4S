using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Teams.Controllers.Models;

namespace Teams.Tools
{
    public class ReadExcel
    {
        public List<TeamStats> readExcel()
        {
           
            List<TeamStats> classlist = new List<TeamStats>();

            try
            {
                string[] lines = File.ReadAllLines(@"C:\Users\eva\source\repos\Teams\Teams\Doc\input.csv");
                var l = (from line in lines.Skip(1)
                         select line).ToList();
                foreach (var row in l)
                {

                    int k = 0;
                    var vline = "";
                    var resutls = "";
                    var values = row.Split(',');
                    var totalpoints = 0;
                    var totalGoalScored = 0;
                    var totalGoalAgainst = 0;
                    var totalGameplayed = 0;
                    var totalGamewin = 0;
                    var totalGamelost = 0;
                    var totalGameDraw = 0;
                    for (int i = 1; i < values.Length; i++)
                    {
                        if (values[i].Contains("Jan"))
                        {
                            values[i] = values[i].Replace("Jan", "1");
                            string newval = values[i];

                        }
                        else if (values[i].Contains("Feb"))
                        {
                            values[i] = values[i].Replace("Feb", "2");

                        }
                        else if (values[i].Contains("Mar"))
                        {
                            values[i] = values[i].Replace("Mar", "3");

                        }
                        else if (values[i].Contains("Apr"))
                        {
                            values[i] = values[i].Replace("Apr", "4");

                        }
                        else if (values[i].Contains("May"))
                        {
                            values[i] = values[i].Replace("May", "5");

                        }
                        else if (values[i].Contains("Jun"))
                        {
                            values[i] = values[i].Replace("Jun", "6");

                        }
                        else if (values[i].Contains("Jul"))
                        {
                            values[i] = values[i].Replace("Jul", "7");

                        }
                        else if (values[i].Contains("Aug"))
                        {
                            values[i] = values[i].Replace("Aug", "8");

                        }
                        else if (values[i].Contains("Sep"))
                        {
                            values[i] = values[i].Replace("Sep", "9");

                        }
                        else if (values[i].Contains("Oct"))
                        {
                            values[i] = values[i].Replace("Oct", "10");

                        }
                        else if (values[i].Contains("Nov"))
                        {
                            values[i] = values[i].Replace("Nov", "11");

                        }
                        else if (values[i].Contains("Dec"))
                        {
                            values[i] = values[i].Replace("Dec", "12");

                        }
                        values[i] = values[i].Replace(" - ", "-");
                        totalGameplayed += 1;
                        if (values[i].Contains("-"))
                        {
                            string kk = values[i];
                            int b = int.Parse(values[i].Substring(values[i].IndexOf("-")).Replace("-", ""));
                            int a = int.Parse(values[i].Remove(values[i].IndexOf("-")));
                            totalGoalScored += a;
                            totalGoalAgainst += b;

                            if (a > b)
                            {
                                resutls = "win";
                                totalpoints += 3;
                                totalGamewin += 1;

                            }
                            else if (a < b)
                            {
                                resutls = "loose";
                                totalGamelost += 1;
                            }
                            else
                            {

                                resutls = "draw";
                                totalpoints += 1;
                                totalGameDraw += 1;

                            }

                        }



                        if (vline == "")
                            vline = values[i];
                        else
                            vline += "," + values[i];
                    }



                    classlist.Add(new TeamStats() { Team = values[0], MP = totalGameplayed, W = totalGamewin, L = totalGamelost, D = totalGameDraw, GF = totalGoalScored, GA = totalGoalAgainst, GD = (totalGoalScored - totalGoalAgainst), P = totalpoints });
                }

            }
            catch (Exception ex)
            {

                Log.Error($"error ex{ex}");
            }            
       

            return classlist;

        }
        
    }
}
