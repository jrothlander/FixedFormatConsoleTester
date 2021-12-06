using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Extensions
{
    public static class FixedFormatExtensions
    {

        private static List<SymbolTable> SymbolTable = new List<SymbolTable>();

        public static string Format(this decimal dec, string var)
        {
            if (SymbolTable.Count == 0) BuildSymbolTable(); //TODO: Find a way to softcode Add

            var objDec = GetSymbolTable(SymbolTable, var);
            return new string('0', objDec.Length - objDec.Decimals);
        }

        public static string Fixed(this decimal number, string variable)
        {
            if (SymbolTable.Count == 0) BuildSymbolTable(); //TODO: Find a way to softcode Add

            var objNumber = GetSymbolTable(SymbolTable, variable);

            if (objNumber.Decimals > 0)
                return number.ToString($"{new string('0', objNumber.Length - objNumber.Decimals)}.{new string('0', objNumber.Decimals)}");
            return number.ToString(new string('0', objNumber.Length - objNumber.Decimals));
        }

        /// <summary>
        /// Move operation for decimal to decimal.
        /// </summary>
        /// <param name="dec"></param>
        /// <param name="replace"></param>
        /// <param name="factor1"></param>
        /// <param name="factor2"></param>
        /// <returns></returns>
        public static decimal Move(this decimal dec, decimal replace, string factor1, string factor2)
        {
            if (SymbolTable.Count == 0) BuildSymbolTable(); //TODO: Find a way to softcode Add

            var objDec = GetSymbolTable(SymbolTable, factor1);
            var sDec = dec.ToString(new string('0', objDec.Length - objDec.Decimals));
            
            var objReplace = GetSymbolTable(SymbolTable, factor2);
            var sReplace = replace.ToString(new string('0', objReplace.Length - objReplace.Decimals));

            string value;
            if (sDec.Length > sReplace.Length)
                value = $"{sDec.Substring(0, sReplace.Length)}{sReplace}";
            else
                value = sReplace.Substring(sDec.Length);

            return Convert.ToDecimal(value);
        }

        //private static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        //{
        //    MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
        //    return expressionBody.Member.Name;
        //}

        private static SymbolTable GetSymbolTable(List<SymbolTable> syt, string name)
        {
            return syt.Where(X => X.Name == name).FirstOrDefault();
        }

        private static void BuildSymbolTable()
        {

            var test = GetEnumerableOfType<IFixedFormat>();

            foreach (var obj in test)
            {
                var fields = obj.GetType().GetFields();

                foreach (var field in fields)
                {
                    var attrs = field.GetCustomAttributes(true);
                    var name = field.Name;
                    var len = 0;
                    var dec = 0;

                    foreach (object attr in attrs)
                    {
                        if (attr is LengthAttribute lenAttr)
                            len = lenAttr.Value;
                        if (attr is DecimalsAttribute decAttr)
                            dec = decAttr.Value;
                    }

                    SymbolTable.Add(new SymbolTable() { Name = name, Length = len, Decimals = dec });
                }
            }

            return;
        }

        private static List<T> GetEnumerableOfType<T>() where T : class
        {
            var objects = new List<T>();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes()
                .Where(mytype => mytype.GetInterfaces().Contains(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type));
            }
            return objects;
        }

    }

    public class SymbolTable
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public int Decimals { get; set; }
    }

}