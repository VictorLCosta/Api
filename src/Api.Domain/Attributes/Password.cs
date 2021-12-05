using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Api.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
    sealed public class Password : ValidationAttribute
    {
        public int MinLength { get; set; }
        public int MaxLenght { get; set; }
        public bool RequireLower { get; set; }
        public bool RequireUpper { get; set; }
        public bool RequireNum { get; set; }
        public bool RequireDigit { get; set; }

        private const string _defaultErrorMessage = "Senha incorreta";

        public Password(int minLength, int maxLenght, bool requireLower, bool requireUpper, bool requireNum, bool requireDigit)
            : base(_defaultErrorMessage)
        {
            MinLength = minLength;
            MaxLenght = maxLenght;
            RequireLower = requireLower;
            RequireUpper = requireUpper;
            RequireNum = requireNum;
            RequireDigit = requireDigit;
        }

        public override bool IsValid(object value)
        {
            var password = value.ToString();

            if(string.IsNullOrWhiteSpace(password))
                return false;

            if(password.Length < MinLength || password.Length > MaxLenght)
                return false;

            int counter = 0;

            List<string> patterns = new();

            if(RequireLower)
                patterns.Add(@"[a-z]");
            if(RequireUpper)
                patterns.Add(@"[A-Z]");
            if(RequireNum)
                patterns.Add(@"[0-9]");
            if(RequireDigit)
                patterns.Add(@"[!@#$%^&*\(\)_\+\-\={}<>,\.\|""'~`:;\\?\/\[\] ]");

            foreach(string p in patterns)
            {
                if(Regex.IsMatch(password, p)) 
                {
                    counter++;
                }
            }

            if(counter < 2)
                return false;

            return true;
        }
    }
}