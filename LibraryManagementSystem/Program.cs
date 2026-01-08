using System;
using LibraryManagementSystem.UI;

namespace LibraryManagementSystem.UI
{
    

    class Program
    {
        static void Main()
        {
            ShowWelcome();

            while (true)
            {
                DrawMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BookMenu();
                        break;
                    case "2":
                        CategoryMenu();
                        break;
                    case "3":
                        MemberMenu();
                        break;
                    case "0":
                        ExitApp();
                        return;
                    default:
                        ShowError("Yanlish secim! Yeniden cehd edin.");
                        break;
                }
            }
        }

        // ================= WELCOME =================
        static void ShowWelcome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("====================================");
            Console.WriteLine("   WELCOME TO LIBRARY MANAGEMENT");
            Console.WriteLine("====================================");
            Console.WriteLine("Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        // ================= MAIN MENU =================
        static void DrawMainMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║        LIBRARY SYSTEM        ║");
            Console.WriteLine("╚══════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" [1]  Book Menu");
            Console.WriteLine(" [2]  Category Menu");
            Console.WriteLine(" [3]  Member Menu");
            Console.WriteLine(" [0]  Exit");
            Console.ResetColor();

            Console.Write("\nSeciminiz: ");
        }

        // ================= BOOK MENU =================
        static void BookMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("===== BOOK MENU =====");
                Console.ResetColor();

                Console.WriteLine(" 1. Kitab elave et");
                Console.WriteLine(" 2. Kitablari goster");
                Console.WriteLine(" 3. Kitab axtar");
                Console.WriteLine(" 4. Kitabi yenile");
                Console.WriteLine(" 5. Kitabi sil");
                Console.WriteLine(" 0. Geri qayit");
                Console.Write("\nSeciminiz: ");

                string c = Console.ReadLine();

                switch (c)
                {
                    case "1": BookUI.AddBookUI(); break;
                    case "2": BookUI.ListBooksUI(); break;
                    case "3": BookUI.SearchBookUI(); break;
                    case "4": BookUI.UpdateBookUI(); break;
                    case "5": BookUI.DeleteBookUI(); break;
                    case "0": return;
                    default:
                        ShowError("Yanlish secim!");
                        break;
                }
            }
        }

        // ================= CATEGORY MENU =================
        static void CategoryMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("===== CATEGORY MENU =====");
                Console.ResetColor();

                Console.WriteLine(" 1. Category elave et");
                Console.WriteLine(" 2. Category siyahisi");
                Console.WriteLine(" 3. Category axtar");
                Console.WriteLine(" 4. Category yenile");
                Console.WriteLine(" 5. Category sil");
                Console.WriteLine(" 0. Geri qayit");
                Console.Write("\nSeciminiz: ");

                string c = Console.ReadLine();

                switch (c)
                {
                    case "1": CategoryUI.AddCategoryUI(); break;
                    case "2": CategoryUI.ListCategoriesUI(); break;
                    case "3": CategoryUI.SearchCategoryUI(); break;
                    case "4": CategoryUI.UpdateCategoryUI(); break;
                    case "5": CategoryUI.DeleteCategoryUI(); break;
                    case "0": return;
                    default:
                        ShowError("Yanlish secim!");
                        break;
                }
            }
        }

        // ================= MEMBER MENU =================
        static void MemberMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("===== MEMBER MENU =====");
                Console.ResetColor();

                Console.WriteLine(" 1. Member elave et");
                Console.WriteLine(" 2. Member siyahisi");
                Console.WriteLine(" 3. Member axtar");
                Console.WriteLine(" 4. Member yenile");
                Console.WriteLine(" 5. Member sil");
                Console.WriteLine(" 0. Geri qayit");
                Console.Write("\nSeciminiz: ");

                string c = Console.ReadLine();

                switch (c)
                {
                    case "1": MemberUI.AddMemberUI(); break;
                    case "2": MemberUI.ListMembersUI(); break;
                    case "3": MemberUI.SearchMemberUI(); break;
                    case "4": MemberUI.UpdateMemberUI(); break;
                    case "5": MemberUI.DeleteMemberUI(); break;
                    case "0": return;
                    default:
                        ShowError("Yanlish secim!");
                        break;
                }
            }
        }

        // ================= HELPERS =================
        static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n❌ " + message);
            Console.ResetColor();
            Console.WriteLine("Enter basin...");
            Console.ReadLine();
        }

        static void ExitApp()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Proqram baglanir... Sag olun!");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
} 

