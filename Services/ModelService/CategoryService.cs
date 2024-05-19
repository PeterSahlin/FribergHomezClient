using Blazored.LocalStorage;
using FribergHomezClient.Services.Base;
using System.Net;

namespace FribergHomezClient.Services.ModelService
{
    public class CategoryService : BaseHttpService, ICategoryService
    {
        private readonly IClient client;
        public CategoryService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.client = client;
        }

        //get all categories
        public async Task<Response<List<Category>>> GetCategoriesAsync()
        {
            Response<List<Category>> response;

            try
            {
                await GetBearerToken();
                var data = await client.CategoryAllAsync();
                response = new Response<List<Category>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<List<Category>>(e);
            }
            return response;
        }

        //get category by id
        public async Task<Response<Category>> GetCategoryByIdAsync(int categoryId)
        {
            Response<Category> response;

            try
            {
                await GetBearerToken();
                var data = await client.CategoryGETAsync(categoryId);
                response = new Response<Category>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<Category>(e);
            }
            return response;
        }

        //create category
        public async Task CreateCategoryAsync(Category category)
        {
            try

            {
                await GetBearerToken();

                await client.CategoryPOSTAsync(category);

            }

            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)

            {

                // Handle the 404 error here

                Console.WriteLine("404 error occurred");

                // You can also return a custom error response or throw a custom exception

            }

            catch (Exception ex)

            {

                // Handle other exceptions

                Console.WriteLine("An error occurred: " + ex.Message);

            }



        }



        //updatecategory
        public async Task UpdateCategoryAsync(string id,Category category)
        {
            try

            {
                await GetBearerToken();

                await client.CategoryPUTAsync(id,category);

            }

            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)

            {

                // Handle the 404 error here

                Console.WriteLine("404 error occurred");

                // You can also return a custom error response or throw a custom exception

            }

            catch (Exception ex)

            {

                // Handle other exceptions

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

        //delete
        public async Task<Response<Category>> DeleteCategoryAsync(int categoryId)
        {
            Response<Category> response;
            await GetBearerToken();
            try
            {
                await client.CategoryDELETEAsync(categoryId);
                response = new Response<Category>
                {
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<Category>(e);
            }
            return response;
        }
    }
}
