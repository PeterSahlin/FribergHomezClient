using Blazored.LocalStorage;
using FribergHomezClient.Services.Base;
using System.Net;

namespace FribergHomezClient.Services.ModelService
{
    public class MunicipalityService : BaseHttpService, IMunicipalityService
    {
        private readonly IClient client;
        public MunicipalityService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.client = client;
        }

        //get all municipalities
        public async Task<Response<List<Municipality>>> GetMunicipalitiesAsync()
        {
            Response<List<Municipality>> response;

            try
            {
                await GetBearerToken();
                var data = await client.MunicipalitiesAllAsync();
                response = new Response<List<Municipality>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<List<Municipality>>(e);
            }
            return response;
        }

        //get municipality by id
        public async Task<Response<Municipality>> GetMunicipalityByIdAsync(int municipalityid)
        {
            Response<Municipality> response;

            try
            {
                await GetBearerToken();
                var data = await client.MunicipalitiesGETAsync(municipalityid);
                response = new Response<Municipality>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<Municipality>(e);
            }
            return response;
        }

        //create municipality
        public async Task CreateMunicipalityAsync(Municipality municipality)
        {
            try

            {
                await GetBearerToken();

                await client.MunicipalitiesPOSTAsync(municipality);

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



        //updatemunicipality
        public async Task UpdateMunicipalityAsync(Municipality municipality)
        {
            try

            {
                await GetBearerToken();

                await client.MunicipalitiesPUTAsync(municipality);

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
        public async Task<Response<Municipality>> DeleteMunicipalityAsync(int municipalityid)
        {
            Response<Municipality> response;
            await GetBearerToken();
            try
            {
                await client.MunicipalitiesDELETEAsync(municipalityid);
                response = new Response<Municipality>
                {
                    Success = true
                };
            }
            catch (ApiException e)
            {
                response = ConvertApiExceptions<Municipality>(e);
            }
            return response;
        }
    }
}

