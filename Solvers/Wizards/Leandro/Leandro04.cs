using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solvers
{
    public class Leandro04 : Wizard
    {
        private string[] requiredFields = new string[] {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid",
        };

        public Leandro04(string name) : base(name)
        {
        }

        #region Do Wizardy stuff

        public override long SolvePartOne(string[] input)
        {
            long solution = 0;
            StringBuilder currPass = new StringBuilder();

            for (int i = 0; i < input.Count(); i++)
            {
                if (!string.IsNullOrEmpty(input[i].Trim()))
                {
                    currPass.Append(input[i].Trim() + " ");
                }

                if (string.IsNullOrEmpty(input[i].Trim()) || i == input.Count() - 1)
                {
                    if (ValidatePassportFields(currPass.ToString().Trim()))
                        solution++;

                    currPass.Clear();
                }                
            }
            return solution;
        }

        public override long SolvePartTwo(string[] input)
        {
            long solution = 0;
            StringBuilder currPass = new StringBuilder();

            for (int i = 0; i < input.Count(); i++)
            {
                if (!string.IsNullOrEmpty(input[i].Trim()))
                {
                    currPass.Append(input[i].Trim() + " ");
                }

                if (string.IsNullOrEmpty(input[i].Trim()) || i == input.Count() - 1)
                {
                    if (ValidateFullPassport(currPass.ToString().Trim()))
                        solution++;

                    currPass.Clear();
                }
            }
            return solution;
        }

        #endregion

        #region Auxiliary Methods

        private bool ValidatePassportFields(string input)
        {
            string[] fields = input.Split(' ');
            int validFields = 0;

            for (int i = 0; i < fields.Count(); i++)
            {
                var key = fields[i].Trim().Split(':')[0];
                if (requiredFields.Contains(key))
                    validFields++;
            }

            return validFields == 7;
        }

        private bool ValidateFullPassport(string input)
        {
            string[] fields = input.Split(' ');
            int validFields = 0;

            for (int i = 0; i < fields.Count(); i++)
            {
                var key = fields[i].Trim().Split(':')[0];
                var value = fields[i].Split(':')[1];

                if (requiredFields.Contains(key) && ValidateValue(key, value))
                    validFields++;
            }

            return validFields == 7;
        }

        private bool ValidateValue(string key, string value)
        {
            switch (key)
            {
                case "byr":
                    return ValidateNumber(value, 1920, 2002);
                case "iyr":
                    return ValidateNumber(value, 2010, 2020);
                case "eyr":
                    return ValidateNumber(value, 2020, 2030);
                case "hgt":
                    return ValidateHeight(value);
                case "hcl":
                    return ValidateStringWithRegex(value, @"^#([A-Fa-f0-9]{6})$");
                case "ecl":
                    return ValidateEyeColor(value);
                case "pid":
                    return ValidateStringWithRegex(value, @"^\d{9}$");
                default:
                    return false;
            }
        }

        // Individual validators

        private bool ValidateEyeColor(string value)
        {
            string[] accepted = new string[]
            {
                    "amb",
                    "blu",
                    "brn",
                    "gry",
                    "grn",
                    "hzl",
                    "oth"
            };
            return accepted.Contains(value);
        }

        private bool ValidateStringWithRegex(string value, string pattern)
        {
            Regex reg = new Regex(pattern);
            return reg.IsMatch(value);
        }

        private bool ValidateHeight(string value)
        {
            string units = value.Substring(value.Length - 2);
            string height = value.Substring(0, value.Length - 2);

            if (units.Equals("in"))
                return ValidateNumber(height, 59, 76);

            if (units.Equals("cm"))
                return ValidateNumber(height, 150, 193);

            return false;
        }

        private bool ValidateNumber(string value, int min = int.MinValue, int max = int.MaxValue)
        {
            int number = 0;

            if (int.TryParse(value, out number))
                return (number >= min && number <= max);

            return false;
        }        

        #endregion
    }
}
