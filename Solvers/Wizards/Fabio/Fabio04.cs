using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Solvers
{
    public class Fabio04 : Wizard
    {
        private readonly char[] _fieldSeparator;
        private readonly int _fieldsNumber;
        private readonly Dictionary<string, Validator> _requiredFields;

        public Fabio04(string name) : base(name)
        {
            _requiredFields = new Dictionary<string, Validator>
            {
                {"byr", new IntValidator(1920, 2002)},
                {"iyr", new IntValidator(2010, 2020)},
                {"eyr", new IntValidator(2020, 2030)},
                {"hgt", new HeightValidator()},
                {"hcl", new HexColorValidator()},
                {"ecl", new StringColorValidator()},
                {"pid", new IntCountValidator(9)}
            };
            _fieldsNumber = _requiredFields.Count;
            _fieldSeparator = new[] {' '};
        }

        public override long SolvePartOne(string[] input)
        {
            return ValidPassports(input, false);
        }

        public override long SolvePartTwo(string[] input)
        {
            return ValidPassports(input, true);
        }

        private long ValidPassports(string[] input, bool validateValue)
        {
            var validPassports = 0;
            var lineToProcess = string.Empty;
            foreach (var line in input)
                if (string.IsNullOrWhiteSpace(line))
                {
                    validPassports += ProcessLine(lineToProcess, validateValue) ? 1 : 0;
                    lineToProcess = string.Empty;
                }
                else
                {
                    lineToProcess += $" {line}";
                }

            if (!string.IsNullOrWhiteSpace(lineToProcess))
                validPassports += ProcessLine(lineToProcess, validateValue) ? 1 : 0;

            return validPassports;
        }

        private bool ProcessLine(string lineToProcess, bool validateValue = false)
        {
            var requiredFieldsCount = 0;

            var fields = lineToProcess.Split(_fieldSeparator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in fields)
            {
                var parsedField = ParseField(field);
                var hasField = _requiredFields.TryGetValue(parsedField.Name, out var validator);
                if (hasField && (!validateValue || validator.IsValid(parsedField.Value)))
                    requiredFieldsCount++;
            }

            return requiredFieldsCount >= _fieldsNumber;
        }

        private (string Name, string Value) ParseField(string field)
        {
            var separatorIndex = field.IndexOf(":");
            return (field.Substring(0, separatorIndex), field.Substring(separatorIndex + 1));
        }


        private abstract class Validator
        {
            public abstract bool IsValid(string fieldValue);
        }

        private sealed class BypassValidator : Validator
        {
            public override bool IsValid(string fieldValue)
            {
                return true;
            }
        }

        private sealed class IntValidator : Validator
        {
            private readonly int _max;
            private readonly int _min;

            public IntValidator(int min, int max)
            {
                _min = min;
                _max = max;
            }


            public override bool IsValid(string fieldValue)
            {
                if (!int.TryParse(fieldValue, out var value))
                    return false;

                return value <= _max && value >= _min;
            }
        }

        private sealed class HeightValidator : Validator
        {
            public override bool IsValid(string fieldValue)
            {
                var unit = fieldValue.Substring(fieldValue.Length - 2);
                var intLength = fieldValue.IndexOf(unit[0]);
                string value = string.Empty;
                if(intLength > 0)
                    value = fieldValue.Substring(0, intLength);
                switch (unit)
                {
                    case "in":
                        return new IntValidator(59, 76).IsValid(value);
                    case "cm":
                        return new IntValidator(150, 193).IsValid(value);
                    default:
                        return false;
                }
            }
        }

        private sealed class HexColorValidator : Validator
        {
            private static readonly Regex ColorRegex = new Regex("^#[0-9a-f]{6}$", RegexOptions.Compiled);

            public override bool IsValid(string fieldValue)
            {
                return ColorRegex.IsMatch(fieldValue);
            }
        }
        
        private sealed class StringColorValidator : Validator
        {
            

            public override bool IsValid(string fieldValue)
            {
                switch (fieldValue)
                {
                    case "amb":
                    case "blu":
                    case "brn":
                    case "gry":
                    case "grn":
                    case "hzl":
                    case "oth":
                        return true;
                    default:
                        return false;
                }
            }
        }
        
        private sealed class IntCountValidator : Validator
        {
            private readonly int length;
            public IntCountValidator(int length)
            {
                this.length = length;
            }

            public override bool IsValid(string fieldValue)
            {
                return fieldValue.Length == length && long.TryParse(fieldValue, out _);
            }
        }
    }
}