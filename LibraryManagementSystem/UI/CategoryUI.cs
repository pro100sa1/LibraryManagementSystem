using LibraryManagementSystem.BLL;
using LibraryManagementSystem.DAL.Entities;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.UI
{
    public static class CategoryUI
    {
        private static CategoryService categoryService = new CategoryService();

        public static void AddCategoryUI()
        {
            try
            {
                Console.Write("Kateqoriya ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Kateqoriya adi: ");
                string name = Console.ReadLine();

                Console.Write("Təsvir: ");
                string description = Console.ReadLine();

                var category = new Category
                {
                    Id = id,
                    Name = name,
                    Description = description
                };

                categoryService.AddCategory(category);

                Console.WriteLine("Kateqoriya ugurla elave olundu! Enter basin...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta: " + ex.Message);
                Console.WriteLine("Enter basin...");
                Console.ReadLine();
            }
        }

        public static void ListCategoriesUI()
        {
            Console.Clear();
            List<Category> categories = categoryService.GetAllCategories();
            foreach (var c in categories)
            {
                Console.WriteLine($"ID: {c.Id} | Name: {c.Name} | Description: {c.Description}");
            }
            Console.WriteLine("Enter basin...");
            Console.ReadLine();
        }

        public static void GetCategoryByIdUI()
        {
            Console.Write("Kateqoriya ID daxil edin: ");
            int id = int.Parse(Console.ReadLine());

            var category = categoryService.GetCategoryById(id);
            if (category != null)
            {
                Console.WriteLine($"ID: {category.Id} | Name: {category.Name} | Description: {category.Description}");
            }
            else
            {
                Console.WriteLine("Kateqoriya tapilmadi!");
            }
            Console.WriteLine("Enter basin...");
            Console.ReadLine();
        }

        public static void UpdateCategoryUI()
        {
            Console.Write("Yenilemek istediyiniz kateqoriya ID: ");
            int id = int.Parse(Console.ReadLine());

            var category = categoryService.GetCategoryById(id);
            if (category == null)
            {
                Console.WriteLine("Kateqoriya tapilmadi! Enter basin...");
                Console.ReadLine();
                return;
            }

            Console.Write($"Yeni Name ({category.Name}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) category.Name = name;

            Console.Write($"Yeni Description ({category.Description}): ");
            string desc = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(desc)) category.Description = desc;

            categoryService.UpdateCategory(category);

            Console.WriteLine("Kateqoriya yenilendi! Enter basin...");
            Console.ReadLine();
        }

        public static void DeleteCategoryUI()
        {
            Console.Write("Silmek istediyiniz kateqoriya ID: ");
            int id = int.Parse(Console.ReadLine());

            categoryService.DeleteCategory(id);

            Console.WriteLine("Kateqoriya silindi! Enter basin...");
            Console.ReadLine();
        }

        public static void SearchCategoryUI()
        {
            Console.Write("Axtarish sozunu daxil edin (ad üzrə): ");
            string keyword = Console.ReadLine();

            var categories = categoryService.SearchCategories(keyword);
            foreach (var c in categories)
            {
                Console.WriteLine($"ID: {c.Id} | Name: {c.Name} | Description: {c.Description}");
            }
            Console.WriteLine("Enter basin...");
            Console.ReadLine();
        }
    }
}
