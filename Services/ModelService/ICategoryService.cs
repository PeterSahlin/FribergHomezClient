using FribergHomezClient.Services.Base;

namespace FribergHomezClient.Services.ModelService
{
    public interface ICategoryService
    {
        //Thomas
        Task<Response<List<Category>>> GetCategoriesAsync();

        Task<Response<Category>> GetCategoryByIdAsync(int categoryId);

        Task CreateCategoryAsync(Category category);

        Task<Response<Category>> DeleteCategoryAsync(int categoryId);

        Task UpdateCategoryAsync(string id, Category category);


    }
}
