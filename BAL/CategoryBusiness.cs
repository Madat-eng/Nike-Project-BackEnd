using DAL;
using DAL.DTOs;
using System;
using System.Collections.Generic;

namespace BAL
{
    public class CategoryBusiness
    {
        public static DTOCategory GetCategoryById(int categoryId)
        {
            try
            {
                var category = CategoryData.GetCategoryByID(categoryId);
                if (category == null)
                    throw new Exception($"Category with ID {categoryId} not found.");
                return category;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Service error while fetching category {categoryId}.", ex);
            }
        }

        public static List<DTOCategory> GetAllCategories()
        {
            try
            {
                return CategoryData.GetAllCategories();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while fetching all categories.", ex);
            }
        }

        public static (bool, int) CreateCategory(DTOCategory category)
        {
            try
            {
                return CategoryData.CreateCategory(category);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Service error while creating category.", ex);
            }
        }

        public static bool UpdateCategory(DTOCategory category)
        {
            try
            {
                return CategoryData.UpdateCategory(category);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Service error while updating category {category.CategoryID}.", ex);
            }
        }

        public static bool DeleteCategory(int categoryId)
        {
            try
            {
                return CategoryData.DeleteCategory(categoryId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Service error while deleting category {categoryId}.", ex);
            }
        }
    }
}
