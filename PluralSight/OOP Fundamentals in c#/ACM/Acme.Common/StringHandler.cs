using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    //this is a static class now, so never have to instanciate it, can just reference the methos direct
    public static class StringHandler
    { //typ 3 /// to generate a comment for our extended method

        /// <summary>
        /// Insert spaces before each capital letter in a string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string InsertSpaces(this String source)

        //in a static class all methods must also me static
        //this keyword adds our extension method InsertSpaces to the string class, to do this methos and class must be static
        //this then allows us to do _productName.InsertSpaces()


        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(source))
            {
                foreach(Char letter in source)
                {
                    if (char.IsUpper(letter))
                    {
                        result = result.Trim();
                        result += " ";
                    }
                    result += letter;
                }

            }
            result = result.Trim();
            return result;
        }

        
        
    }
}
