﻿using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Authors
{
    public class AuthorDto:FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string? ShortBio { get; set; }
        public DateTime BirthDate { get; set; }
    }

    


}
