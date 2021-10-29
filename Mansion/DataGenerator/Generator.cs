using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mansion.DataGenerator
{
    class Generator
    {
        private List<string> SerialList { get; set; }
        private ICharacter[] CurrentValue { get; set; }

        public Generator(string template)
        {
            CurrentValue = new ICharacter[template.Length];
            SerialList = new();

            for (int i = 0; i < template.Length; i++)
            {
                switch (template[i])
                {
                    case '0':
                        CurrentValue[i] = new Number();
                        break;
                    case 'A':
                        CurrentValue[i] = new Letter();
                        break;
                }
            }
        }



        private string ICharacterArrayToString()
        {
            StringBuilder s = new();
            foreach (var character in CurrentValue)
            {
                s.Append(character);
            }
            return s.ToString();
        }


        public List<string> Build(bool randomized = false)
        {
            SerialList.Add(ICharacterArrayToString());
            for (var position = CurrentValue.Length - 1; position >= 0;)
            {
                if (CurrentValue[position].Increment())
                {
                    position--;
                }
                else
                {
                    SerialList.Add(ICharacterArrayToString());
                    position = CurrentValue.Length - 1;
                }
            }
            if (randomized)
            {
                return SerialList.OrderBy(o => Guid.NewGuid()).ToList();
            }
            else
            {
                return SerialList;
            }
        }

        public void WriteToCSVFile(List<string> list, string outFile = "testbank.csv")
        {
            using StreamWriter outputFile = new(outFile);
            foreach (var item in list)
            {
                outputFile.WriteLine(item);
            }
        }

        //public void RandomWriteToCSVFile(string outFile = "randommaster.csv")
        //{
        //    using (StreamWriter outputFile = new StreamWriter(outFile))
        //    {
        //        foreach (var item in RandomPatternMasterList)
        //        {
        //            outputFile.WriteLine(item);
        //        }
        //    }
        //}



    }
}
