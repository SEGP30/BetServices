﻿using System;
using System.Threading.Tasks;
using BetServices.Application.ClientServices.Requests;
using BetServices.Application.ClientServices.Responses;
using BetServices.Domain.Contracts;
using BetServices.Domain.Entities;
using BetServices.Domain.Enums;

namespace BetServices.Application.ClientServices
{
    public class RegisterClientService
    {
        private readonly IClientRepository _clientRepository;

        public RegisterClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<RegisterClientResponse> Execute(RegisterClientRequest request)
        {
            var clientInDb = await _clientRepository.Find(request.ClientId);
            if (clientInDb != null)
                return new RegisterClientResponse
                {
                    Message = "Client already exits"
                };

            var clientToRegister = new Client
            {
                Id = request.ClientId,
                Names = request.ClientNames,
                Surnames = request.ClientSurnames,
                Gender = request.ClientGender,
                EntityState = EntityState.Active,
                Credit = 0,
                CreationDate = DateTime.Today,
                UpdateTime = DateTime.Now
            };
            
            await _clientRepository.Insert(clientToRegister);
            //await _unitOfWork.Commit();

            return new RegisterClientResponse
            {
                Message = "Client registered successfully"
            };
        }
    }
}