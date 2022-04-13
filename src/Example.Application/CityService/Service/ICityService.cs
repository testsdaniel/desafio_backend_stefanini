﻿using Example.Application.CityService.Models.Request;
using Example.Application.CityService.Models.Response;

namespace Example.Application.CityService.Service
{
    public interface ICityService
    {
        Task<GetAllCityResponse> GetAllAsync();
        Task<GetByIdCityResponse> GetByIdAsync(int id);
        Task<CreateCityResponse> CreateAsync(CreateCityRequest request);
        Task<UpdateCityResponse> UpdateAsync(UpdateCityRequest request);
        Task<DeleteCityResponse> DeleteAsync(DeleteCityRequest request);
    }
}
