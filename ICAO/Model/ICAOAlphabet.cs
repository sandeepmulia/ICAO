using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAO.Model
{
    public class ICAOAlphabet
    {
        private Dictionary<char, string> _icaoAlphabet = new Dictionary<char, string>();

        public ICAOAlphabet()
        {
            _icaoAlphabet.Add('A',"Alfa");
            _icaoAlphabet.Add('B',"Bravo");
            _icaoAlphabet.Add('C',"Charlie");
            _icaoAlphabet.Add('D',"Delta");
            _icaoAlphabet.Add('E',"Echo");
            _icaoAlphabet.Add('F',"Foxtrot");
            _icaoAlphabet.Add('G',"Golf");
            _icaoAlphabet.Add('H',"Hotel");
            _icaoAlphabet.Add('I',"India");
            _icaoAlphabet.Add('J',"Juliett");
            _icaoAlphabet.Add('K',"Kilo");
            _icaoAlphabet.Add('L',"Lima");
            _icaoAlphabet.Add('M',"Mike");
            _icaoAlphabet.Add('N',"November");
            _icaoAlphabet.Add('O',"Oscar");
            _icaoAlphabet.Add('P',"Papa");
            _icaoAlphabet.Add('Q',"Quebec");
            _icaoAlphabet.Add('R',"Romeo");
            _icaoAlphabet.Add('S',"Sierra");
            _icaoAlphabet.Add('T',"Tango");
            _icaoAlphabet.Add('U',"Uniform");
            _icaoAlphabet.Add('V',"Victor");
            _icaoAlphabet.Add('W',"Whiskey");
            _icaoAlphabet.Add('X',"X-ray");
            _icaoAlphabet.Add('Y',"Yankee");
            _icaoAlphabet.Add('Z',"Zulu");
        }

        public List<Tuple<char,string>> Translate(string text)
        {
            List<Tuple<char, string>> retList = new List<Tuple<char, string>>();

            text.ToCharArray().ToList().ForEach((c) =>
            {
                string str = String.Empty;
                _icaoAlphabet.TryGetValue(Char.ToUpper(c), out str);
                if (String.IsNullOrEmpty(str))
                    str = Char.ToUpper(c).ToString();
                 retList.Add(new Tuple<char, string>(c,str));
            });

            return retList;
        }
    }
}
