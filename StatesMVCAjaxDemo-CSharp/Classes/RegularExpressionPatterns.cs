using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatesMVCAjaxDemo_CSharp.Classes
{
    public static class RegularExpressionPatterns
    {
        public const string StateRegPattern = "^[A-Z]{2}$";

        // the following patterns are used to help prevent the web page blowing up with an
        // "A potentially dangerous Request.Form value was detected from the client" error
        //
        // alpha characters only
        public const string AlphaRegPattern = "^[A-Za-z]*$";

        // numberic only
        public const string NumericRegPattern = "^[0-9]*$";

        // minimal allowable characters - alpha and numeric and space only
        public const string ASCIIMinRegPattern = "^[A-Za-z0-9 ]*$";

        // slightly larger character set - alpha, numeric, space, apostrophe, hypen, period, comma, pound sign, slash, parentheses, and the ampersand sign.
        public const string ASCIIBasicRegPattern = "^[A-Za-z0-9\\. '/(/)/,#\\&\\-]*$";

        //multi-line version of ASCIIBasicRegPattern with the addition of the colon, asterisk and at sign
        public const string ASCIIMultiBasicRegPattern = "^[A-Za-z0-9\\s\\. \\:\\*\\@'/,#\\&\\-]*$";
    }
}