﻿using _9.Hét_FK2KYX.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9.Hét_FK2KYX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");
        }

        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        Random rng = new Random(1234);

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }

        //ezeket az inconsistent accesibility hibákat nem értem

        public List<BirthProbability> GetBirthProbabilities(string csvpath)
        {
            List<BirthProbability> birthprob = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birthprob.Add(new BirthProbability()
                    {
                        age = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        pBirth = double.Parse(line[2])
                    });
                }
            }

            return birthprob;
        }
        //és itt is ugyan ez:
        public List<DeathProbability> GetDeathProbabilities(string csvpath)
        {
            List<DeathProbability> deathprob = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    deathprob.Add(new DeathProbability()
                    {
                        Gender = int.Parse(line[0]),
                        age = int.Parse(line[1]),
                        pDeath = double.Parse(line[2])
                    });
                }
            }

            return deathprob;
        }


    }
}
