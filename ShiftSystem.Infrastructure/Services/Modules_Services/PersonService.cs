﻿using Azure.AI.FormRecognizer.DocumentAnalysis;
using Microsoft.EntityFrameworkCore;
using ShiftSystem.Infrastructure.Context;
using ShiftSystem002.Application.Interfaces;
using ShiftSystem002.Domain.Entities;

namespace ShiftSystem.Infrastructure.Services.Modules_Services
{
    public class PersonService : IPersonService
    {
        private readonly IShiftSystemDbContext _dbContext;
        
        public PersonService(IShiftSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> Create(Person person)
        {
            await _dbContext.GetDbSet<Person>().AddAsync(person);
            await _dbContext.SaveChangesAsync();
            return person;
        }

        public async Task<List<Person>> Get(int top = 50)
        {
            return await _dbContext.GetDbSet<Person>().Take(top).ToListAsync();
        }

        public async Task<Person> GetPersonFromAnalyzeResult(AnalyzeResult analyzeResult)
        {
            var person = new Person();
            foreach (AnalyzedDocument document in analyzeResult.Documents)
            {
                foreach (KeyValuePair<string, DocumentField> fieldKvp in document.Fields)
                {
                    string fieldName = fieldKvp.Key;
                    DocumentField field = fieldKvp.Value;

                    if (fieldName == "nombre") person.FullName = field.Content.ToString();
                    if (fieldName == "cedula") person.DNI = field.Content.ToString();
                }
            }
            return await Task.FromResult(person);
        }

        public async Task<Person> GetyById(int id)
        {
            var person = await _dbContext.GetDbSet<Person>().FirstOrDefaultAsync(x => x.Id == id);

            if (person == null) throw new Exception("Person not found");

            return person;
        }
    }
}
