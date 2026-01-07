using LibraryManagementSystem.DAL.Entities;
using LibraryManagementSystem.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.BLL
{
    public class CategoryService
    {
        private readonly CategoryRepository _repo;

        public CategoryService()
        {
            _repo = new CategoryRepository();
        }

        
        public void AddCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new Exception("Name boş ola bilməz!");

            _repo.Add(category);
        }

        public List<Category> GetAllCategories()
        {
            return _repo.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _repo.GetById(id);
        }

      
        public void UpdateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new Exception("Name boş ola bilməz!");

            _repo.Update(category);
        }

        public void DeleteCategory(int id)
        {
            _repo.Delete(id);
        }

      
        public List<Category> SearchCategories(string keyword)
        {
            return _repo.Search(keyword);
        }
    }
}
