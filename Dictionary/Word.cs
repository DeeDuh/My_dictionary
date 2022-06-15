using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dictionary
{
    public class Eng_Rus
    {
        public Dictionary<string, string> EngRus;
        public Eng_Rus()
        {
            EngRus = new Dictionary<string, string>();
        }
        public int Id { get; set; }
        public string Word1 { get; set; }
        public string Word2 { get; set; }

        public override string ToString()
        {
            return $"Слово: {Word1}, перевод: {Word2},ID: {Id}";
        }
        public void Show()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("D:\\C#\\Dictionary\\Dictionary\\bin\\Debug\\net5.0\\Myfile.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Выполнение блока finally.");
            }
        }
        public void Add()
        {
            Console.WriteLine("Введите слово:");
            string word = Console.ReadLine();

            Console.WriteLine("Введите перевод");
            string word2 = Console.ReadLine();
            word.ToLower();
            word2.ToLower();

            EngRus.Add(word, word2);
            using (var writer = new StreamWriter("Myfile.txt")) //сохраняем в файл
            {
                foreach (var f in EngRus)
                {
                    writer.WriteLine($"{f.Key}\n{f.Value}");
                }
            }
            Eng_Rus user1 = new Eng_Rus { Word1 = word }; //сохраняем слова в базу данных
            Eng_Rus user2 = new Eng_Rus { Word2 = word2 };
            using (ApplicationContext db = new ApplicationContext())
            {
                db.My_dictionary.Add(user1);
                db.My_dictionary.Add(user2);
                db.SaveChanges();
            }
        }
        public void Translation_Word()
        {
            try
            {
                Console.WriteLine("Введите слово, которое нужно перевести");
                string word = Console.ReadLine();

                Console.WriteLine("{0} - {1}", word, EngRus[word.ToLower()]);
            }
            catch
            {
                Console.WriteLine("Упс..Слово не найдено в словаре");
            }
        }
        public void Translation_phrase()
        {
            Console.WriteLine("Введите предложение, которое нужно перевести");
            string phrase = Console.ReadLine().ToLower();

            string[] word = phrase.Split(' '); //разделение слов
            Console.Write("{0} - ", phrase);
            bool f = true;
            foreach (string n in word)
            {
                if (EngRus.ContainsKey(n))
                    Console.Write("{0} ", EngRus[n.ToLower()]);
                else
                {
                    Console.Write(" ------- ");
                    f = true;
                }
            }
            Console.WriteLine();
            if (!f)
            {
                Console.WriteLine("Какое то из этих слов не найдено\n");
            }
        }

        public void Del()
        {
            Console.WriteLine("Введите слово, которое нужно удалить");
            string word = Console.ReadLine();
            word.ToLower();
            EngRus.Remove(word); //удаляем слово
            using (var writer = new StreamWriter("Myfile.txt")) //перезаписываем
            {
                foreach (var f in EngRus)
                {
                    writer.WriteLine($"{f.Key}\n{f.Value}");
                }
            }
            Console.WriteLine("Слово успешно удалено!\n");
        }

        public void Show_BD() //получаем объекты из бд и выводим на консоль
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.My_dictionary.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Eng_Rus u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Word1} - {u.Word2}");
                }
                Console.Read();
            }
        }
     }
}
    


     


       
        


     


