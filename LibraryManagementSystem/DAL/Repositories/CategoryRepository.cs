using LibraryManagementSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryManagementSystem.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private const int ID_length = 5;
        private const int NAME_Length = 30;
        private const int DESCRIPTION_Length = 50;

        private readonly string filePath = "Data/categories.txt";
        public CategoryRepository()
        {
            string dir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!File.Exists(filePath))
                File.Create(filePath).Close();
        }


        public void Add(Category category)
        {
            string line =
                category.Id.ToString().PadLeft(ID_length, '0') +
                category.Name.PadRight(NAME_Length) +
                category.Description.PadRight(DESCRIPTION_Length);

            File.AppendAllText(filePath, line + Environment.NewLine);
        }

      
        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            if (!File.Exists(filePath))
                return categories;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                Category category = new Category
                {
                    Id = int.Parse(line.Substring(0, ID_length)),
                    Name = line.Substring(ID_length, NAME_Length).Trim(),
                    Description = line.Substring(ID_length + NAME_Length, DESCRIPTION_Length).Trim()
                };

                categories.Add(category);
            }

            return categories;
        }

     
        public Category GetById(int id)
        {
            List<Category> categories = GetAll();

            foreach (Category c in categories)
            {
                if (c.Id == id)
                    return c;
            }

            return null;
        }

        
        public void Update(Category entity)
        {
            List<Category> categories = GetAll();
            bool updated = false;

            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].Id == entity.Id)
                {
                    categories[i] = entity;
                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    foreach (Category c in categories)
                    {
                        string line =
                            c.Id.ToString().PadLeft(ID_length, '0') +
                            c.Name.PadRight(NAME_Length) +
                            c.Description.PadRight(DESCRIPTION_Length);

                        sw.WriteLine(line);
                    }
                }
            }
        }

      
        public void Delete(int id)
        {
            List<Category> categories = GetAll();
            categories.RemoveAll(c => c.Id == id);

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (Category c in categories)
                {
                    string line =
                        c.Id.ToString().PadLeft(ID_length, '0') +
                        c.Name.PadRight(NAME_Length) +
                        c.Description.PadRight(DESCRIPTION_Length);

                    sw.WriteLine(line);
                }
            }
        }

        
        public List<Category> Search(string keyword)
        {
            List<Category> allCategories = GetAll();
            List<Category> result = new List<Category>();

            foreach (Category c in allCategories)
            {
                if (c.Name != null && c.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    result.Add(c);
            }

            return result;
        }
    }
}
