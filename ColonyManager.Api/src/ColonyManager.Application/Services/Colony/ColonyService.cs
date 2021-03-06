﻿using AutoMapper;
using ColonyManager.Data;
using ColonyManager.Data.Entities;
using ColonyManager.Domain.Interfaces.Services;
using ColonyManager.Domain.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColonyManager.Application.Services
{
    public class ColonyService : IColonyService
    {
        private readonly ColonyManagerDbContext _dbContext;
        private readonly IValidator<AddColonyRequestDto> _addValidator;
        private readonly IMapper _mapper;
        private readonly ILogger<ColonyService> _logger;

        public ColonyService(ColonyManagerDbContext dbContext, IMapper mapper, ILogger<ColonyService> logger,
            IValidator<AddColonyRequestDto> validator)
        {
            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext;
            _addValidator = validator;
        }

        public async Task<IEnumerable<ColonyDto>> GetAllColoniesAsync()
        {
            _logger.LogDebug("Get all colonies call");
            return _mapper.Map<List<ColonyDto>>(await _dbContext.Colonies.ToListAsync());
        }

        public async Task<ColonyDto> AddColonyAsync(AddColonyRequestDto request, string fullName)
        {
            _logger.LogDebug($"Add new colony. Request {JsonConvert.SerializeObject(request)}");
            await _addValidator.ValidateAndThrowAsync(request);

            var entity = _mapper.Map<Colony>(request);
            entity.CreatedDate = DateTime.Now;
            entity.LastUpdatedUserName = fullName;

            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ColonyDto>(entity);
        }
    }
}
