﻿using Entities.LinkModels;

namespace Entities.Models
{
    public class LinkResponse
    {
        public bool HasLink { get; set; }

        public List<Entity> ShapedEntities { get; set; }

        public LinkCollectionWrapper<Entity> LinkedEntities { get; set; }

        public LinkResponse()
        {
            LinkedEntities = new LinkCollectionWrapper<Entity>();
            ShapedEntities = new List<Entity>();
        }
    }
}
