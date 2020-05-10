using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Columnar
{
    class MainClass
     
    {
        public static void Main(string[] args)
        {

            /* List<int> key = new List<int>()
         {
             1,4,3,2
         }; */


            // List<int> key = new List<int>() { 3, 2, 6, 4, 1, 5 };


            //List<int> key = new List<int>() { 4, 3, 1, 2, 5, 6, 7 };



            //dec trial
            //1 m3 main key

            //   string cipherText = "ttnaaptmtsuoaodwcoiknlpet";

            //2 m3 main key
            // string cipherText = "ttnaaptmtsuoaodwcoixknlxpetx"; 

           
            // string cipherText = "ctipscoeemrnuce";
            //List<int> key = new List<int>() { 1, 3, 4, 2, 5 };

            // 4 m3 2
           // string cipherText = "cusnpremeieotcc";
            //List<int> key = new List<int>() { 1, 4, 3, 2 };
            //5 m3 2
           // string cipherText = "cusnprexmeieotcc";

            string cipherText = "nalceehwttdttfseeleedsoaefeahl";

            List<int> key = new List<int>() { 3, 2, 6, 4, 1, 5 };

            //  Encrypt(plainText, key);
            Decrypt(cipherText, key);
            //>.>

            /*
            List<int> Result = Analyse(plainText, cipherText);

            for (int i = 0; i < Result.Count; i++) Console.Write(Result[i] + " ");*/


        }
            public static List<int> Analyse(string plainText, string cipherText)
            {
            SortedDictionary<int, int> sortedDictionary = new SortedDictionary<int, int>();
            plainText = plainText.ToLower();
            cipherText = cipherText.ToLower();
            double plainTxtSize = plainText.Length;
         
            for (int z = 1; z < Int32.MaxValue; z++)
            {
                int c = 0;
                double width = z;
                double height = Math.Ceiling(plainTxtSize / z); ;
                string[,] pl = new string[(int)height, (int)width];
                for (int i = 0; i < height; i++)
                {             
                   for (int j = 0; j < z; j++)
                    {
                        if (c >= plainTxtSize)
                        {
                            pl[i, j] = "";
                        }
                        else
                        {
                            pl[i, j] = plainText[c].ToString();

                            c++;
                        }
                    }
                }
         // taking col by col bntl3 l7rof nlz2ha n3ml string w ndkhlha f list
        //bashof hal l words mwgod f CT? yes? right key and get order.. no? loop again for new key
                List<string> mylist = new List<string>();
                for (int i = 0; i < z; i++)
                {
                    string word = "";
                    for (int j = 0; j < height; j++)
                    {
                        word += pl[j, i]; 
                    }
                    mylist.Add(word);
                }

                if (mylist.Count == 7)
                {
                    string d = "";
                }  

                bool correctkey = true;
                string cipherCopy = (string)cipherText.Clone();
              //map x makano fl cipher text m3 l col index 
               sortedDictionary = new SortedDictionary<int, int>();
                  for (int i=0; i<mylist.Count;i++)
                {
                    //get index of first substring occurance
                   int x= cipherCopy.IndexOf(mylist[i]);
                   if (x == -1)
                    {
                        correctkey = false;
                    }
                    else
                    {
                        sortedDictionary.Add(x, i + 1);
                        cipherCopy.Replace(mylist[i], "#");
                    }

                }
                if (correctkey)
                    break;

            }
                List<int> output = new List<int>();
            Dictionary<int, int> newDictionary = new Dictionary<int, int>();
            
            //seprate string in col..
            //find in cipher (if cipher contains all this string,, then thats the key 

            for (int i = 0; i < sortedDictionary.Count; i++)
            {
                newDictionary.Add(sortedDictionary.ElementAt(i).Value, i + 1);
            }

            for (int i =1; i < newDictionary.Count+1; i++)
            {
                output.Add(newDictionary[i]);
            }
           // Console.WriteLine(output);
            return output;
           

        }

            public static string Decrypt(string cipherText, List<int> key)
            {
            //throw new NotImplementedException();

            double cipherTxtSize = cipherText.Length;
            double width = key.Count;
            double height = Math.Ceiling(cipherTxtSize / width);
            int cnt = 0;

            char[,] arr= new char[(int)height, (int)width];


            // TRIAL filling the dictionary
            Dictionary<int, int> keyDictionary = new Dictionary<int, int>();
            for (int i = 0; i < key.Count; i++)
            {
                keyDictionary.Add(key[i] - 1, i);

            }

            int numberOfFullColumns = cipherText.Length % key.Count;

            for (int i = 0; i < key.Count; i++)
            {
               // int x = key[i];

                for (int k =0; k < height; k++)
                {
                    if (numberOfFullColumns != 0 && k == height - 1 && keyDictionary[i] >= numberOfFullColumns) continue;

                    arr[k, keyDictionary[i]] = cipherText[cnt];
                    cnt++;


                }
                 
            }
         

            StringBuilder builder = new StringBuilder();
         
            for (int i = 0; i< height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    builder.Append(arr[i,j]);
                }
            }
            string result = builder.ToString();
            Console.WriteLine(result.ToUpper());
            return result.ToUpper();
        }


            public static string Encrypt(string plainText, List<int> key)
            {
                double plainTxtSize = plainText.Length;
                double width = key.Count;
                double height = plainTxtSize / width;
                double x = plainTxtSize / width;

            //for rounding
            height = Math.Ceiling(x);

                char[,] pl = new char[(int)height, (int)width];

                int c = 0;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (c >= plainTxtSize)
                        {
                            pl[i, j] = 'x';
                        }
                        else
                        {
                            pl[i, j] = plainText[c];

                            c++;
                        }
                    }
                }


            //filling the dictionary
            Dictionary<int, int> keyDictionary = new Dictionary<int, int>();
            for (int i = 0; i < key.Count; i++)
            {
                keyDictionary.Add(key[i]-1, i);
               
            }

            string myciphertext = "";

                for (int i = 0; i < key.Count; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        //0 based
                   myciphertext += pl[j, keyDictionary[i]];

                }
                }
            Console.WriteLine(myciphertext.ToUpper());
                return myciphertext.ToUpper();
            }

        }
    
}


