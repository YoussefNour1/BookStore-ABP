﻿using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Authors
{
    public class AuthorManager
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> CreateAsync(string name, DateTime birthDate, string? shortBio = null)
        {
            Check.NotNullOrEmpty(name, nameof(name));
            var existingUser = await _authorRepository.FindByNameAsync(name);
            if (existingUser != null) {
                throw new AuthorAlreadyExistsException(name);
            }
            return new Author(
                Guid.NewGuid(),
                name,
                birthDate,
                shortBio
            );
        }

        public async Task ChangeNameAsync(Author author, string newName)
        {
            Check.NotNull(author, nameof(author));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingAuthor = await _authorRepository.FindByNameAsync(newName);
            if (existingAuthor != null && existingAuthor.Id != author.Id)
            {
                throw new AuthorAlreadyExistsException(newName);
            }

            author.ChangeName(newName);
        }

    }

}