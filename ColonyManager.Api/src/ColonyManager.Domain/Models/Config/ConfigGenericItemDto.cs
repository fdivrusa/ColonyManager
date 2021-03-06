﻿using System.Collections.Generic;

namespace ColonyManager.Domain.Models
{
    public class ConfigGenericItemDto : BaseDto
    {
        public int GroupId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<ConfigGenericItemExtentionDto> ConfigGenericItemExtentions { get; set; }
    }
}
