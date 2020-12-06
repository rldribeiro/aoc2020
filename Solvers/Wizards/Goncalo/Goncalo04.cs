using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solvers
{
    public class Goncalo04 : Wizard
    {
        private string[] requiredFields;
        private string[] eyeColor;
        public Goncalo04(string name) : base(name)
        {
            requiredFields = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            eyeColor = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        }

        public override long SolvePartOne(string[] input)
        {
            string inputRaw = string.Concat(input); // you are fucking my performance with this type of input :D

            string[] passports = inputRaw.Split(new[] { "\r\r" }, StringSplitOptions.None);
            int result = 0;

            foreach (var item in passports)
            {
                if (requiredFields.All(x => item.Contains(x)))
                    result++;

            }

            return result;
        }

        public override long SolvePartTwo(string[] input)
        {
            string inputRaw = string.Concat(input); //GRrrrrrr

            string[] passports = inputRaw.Split(new[] { "\r\r" }, StringSplitOptions.None);
            int result = 0;

            bool fieldIsValid = false;
            bool passportIsValid = true;
            string valueToBeAnalized;

            foreach (var passport in passports)
            {
                passportIsValid = true;

                foreach (var requiredField in requiredFields)
                {
                    var matchResult = Regex.Match(passport, $@"{requiredField}:(.*?)(\s|$)");
                    if (!matchResult.Success)
                    {
                        passportIsValid = false;
                        break;
                    }

                    valueToBeAnalized = matchResult.Groups[1].Value;

                    switch (requiredField)
                    {
                        case "byr":
                            fieldIsValid = isbyrValid(valueToBeAnalized);
                            break;
                        case "iyr":
                            fieldIsValid = isiyrValid(valueToBeAnalized);
                            break;
                        case "eyr":
                            fieldIsValid = iseyrValid(valueToBeAnalized);
                            break;
                        case "hgt":
                            fieldIsValid = ishgtValid(valueToBeAnalized);
                            break;
                        case "hcl":
                            fieldIsValid = ishclValid(valueToBeAnalized);
                            break;
                        case "ecl":
                            fieldIsValid = iseclValid(valueToBeAnalized);
                            break;
                        case "pid":
                            fieldIsValid = ispidValid(valueToBeAnalized);
                            break;
                        default:
                            fieldIsValid = false;
                            break;
                    }
                    passportIsValid = passportIsValid && fieldIsValid;

                    if (!passportIsValid) //if one field is invalid, we do not need to continue the loop
                        break;
                }

                if (passportIsValid)
                    result++;

            }

            return result;
        }

        public bool isbyrValid(string year)
        {
            if (Int32.TryParse(year, out int convertedYear))
            {
                return convertedYear >= 1920 && convertedYear <= 2002;
            }
            return false;
        }
        public bool isiyrValid(string year)
        {
            if (Int32.TryParse(year, out int convertedYear))
            {
                return convertedYear >= 2010 && convertedYear <= 2020;
            }
            return false;
        }
        public bool iseyrValid(string year)
        {
            if (Int32.TryParse(year, out int convertedYear))
            {
                return convertedYear >= 2020 && convertedYear <= 2030;
            }
            return false;
        }
        public bool ishgtValid(string heightWithUnit)
        {
            var match = Regex.Match(heightWithUnit, @"(\d+)([a-z]+)");

            Int32.TryParse(match.Groups[1].Value, out int height);
            string unit = match.Groups[2].Value;

            return (unit == "cm" && height >= 150 && height <= 193) || (unit == "in" && height >= 59 && height <= 76);
        }

        public bool ishclValid(string color)
        {
            return Regex.IsMatch(color, @"#[A-Za-z0-9]{6}");
        }
        public bool iseclValid(string color)
        {
            return eyeColor.Any(x => x == color);
        }
        public bool ispidValid(string id)
        {
            return Regex.IsMatch(id, @"^\d{9}$");
        }

    }
}
