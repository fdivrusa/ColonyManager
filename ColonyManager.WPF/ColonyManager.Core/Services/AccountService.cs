﻿using ColonyManager.Core.Helpers;
using ColonyManager.Core.Models;
using ColonyManager.Provider.Responses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ColonyManager.Core.Services
{
    public class AccountService : BaseService
    {
        public async Task<AuthenticationResponse> AuthenticateAsync(LoginRequest request)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            AuthenticationResponse authenticationResponse = new AuthenticationResponse
            {
                Success = false
            };
            try
            {
                await SecurityHelper.DecryptSecureString(request.SecurePassword, async (password) =>
                {
                    request.Password = password;
                    string json = JsonConvert.SerializeObject(request);
                    var jsonRequest = new StringContent(json, Encoding.UTF8, "application/json");
                    httpResponseMessage = await HttpClient.PostAsync("accounts/authenticate", jsonRequest);
                });

                authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(await httpResponseMessage.Content.ReadAsStringAsync());
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    authenticationResponse.Success = true;
                }
            }
            catch (Exception ex)
            {
                authenticationResponse.Message = ex.Message;
            }
            return authenticationResponse;
        }
    }
}