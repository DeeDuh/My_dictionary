using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dictionary
{
    //enum w: byte
    //{
    //    Show=1,
    //    Add,
    //    Translation,
    //    Delete,
    //    Translation_phrase,
    //}
    class Program
    {
        static void Main(string[] args)
        {

            Eng_Rus eng_rus = new Eng_Rus();

                Console.WriteLine();
                int W = 0;
                do
                {
                    Console.WriteLine("\n\n1-Показать словарь;\n 2-Добавить слово;\n 3-Перевести слово;\n 4-Удалить слово;\n 5-Перевести фразу;\n6-Показать базу данных;\n");
                    Console.WriteLine("Введите нужный функционал: ");
                    // string str = Console.ReadLine();
                    //  w W = (w)Enum.Parse(typeof(w), str, ignoreCase: true);
                    W = Convert.ToInt32(Console.ReadLine());
                    switch (W)
                    {
                        case 1: //показать словарь
                            eng_rus.Show();
                            break;

                        case 2: //добавить слово   
                            eng_rus.Add();
                            break;

                        case 3: //перевести слово
                            eng_rus.Translation_Word();
                            break;

                        case 4: //удалить слово
                            eng_rus.Del();
                            break;

                        case 5: //перевести фразу
                            eng_rus.Translation_phrase();
                            break;
                        case 6: //показать базу данных
                            eng_rus.Show_BD();
                            break;
                        default:
                            Console.Write("Неправильно набрана функция!\n");
                            break;
                    }
                } while (W != 7);

                Console.ReadKey();
            }
        }       
    }

