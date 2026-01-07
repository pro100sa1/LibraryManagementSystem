using System;
using LibraryManagementSystem.UI;

namespace LibraryManagementSystem.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("==== Kitabxana Idareetmesi ====");
                Console.WriteLine("1. Kitab elave et");
                Console.WriteLine("2. Kitablari goster");
                Console.WriteLine("3. Kitab axtar");
                Console.WriteLine("4. Kitab yenile");
                Console.WriteLine("5. Kitab sil");
                Console.WriteLine("6. Kateqoriya elave et");
                Console.WriteLine("7. Kateqoriyalari goster");
                Console.WriteLine("8. Kateqoriya axtar");
                Console.WriteLine("9. Kateqoriya yenile");
                Console.WriteLine("10. Kateqoriya sil");
                Console.WriteLine("11. Uzv elave et");
                Console.WriteLine("12. Uzvleri goster");
                Console.WriteLine("13. Uzv axtar");
                Console.WriteLine("14. Uzv yenile");
                Console.WriteLine("15. Uzv sil");
                Console.WriteLine("0. Cixish");
                Console.Write("Seciminizi daxil edin: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BookUI.AddBookUI();
                        break;
                    case "2":
                        BookUI.ListBooksUI();
                        break;
                    case "3":
                        BookUI.SearchBookUI();
                        break;
                    case "4":
                        BookUI.UpdateBookUI();
                        break;
                    case "5":
                        BookUI.DeleteBookUI();
                        break;
                    case "6":
                        CategoryUI.AddCategoryUI();
                        break;
                    case "7":
                        CategoryUI.ListCategoriesUI();
                        break;
                    case "8":
                        CategoryUI.SearchCategoryUI();
                        break;
                    case "9":
                        CategoryUI.UpdateCategoryUI();
                        break;
                    case "10":
                        CategoryUI.DeleteCategoryUI();
                        break;
                    case "11":
                        MemberUI.AddMemberUI();
                        break;
                    case "12":
                        MemberUI.ListMembersUI();
                        break;
                    case "13":
                        MemberUI.SearchMemberUI();
                        break;
                    case "14":
                        MemberUI.UpdateMemberUI();
                        break;
                    case "15":
                        MemberUI.DeleteMemberUI();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Yanlish secim! Enter basin...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}

