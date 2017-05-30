using System;
using System.Collections;
using ReallySimpleEngine.Contracts;
using ReallySimpleEngine.Enums;
using ReallySimpleEngine.Models.Resource;
using ReallySimpleEngine.Models.Unit;

namespace ReallySimpleEngine.Factories
{
    public class ResourceFactory : IResourceFactory
    {
        public IResource CreateResource(string typeBuilding)
        {
            switch (typeBuilding)
            {
                case "archery":
                    var resourceArchery = new Resource(ResourceType.Gold, 5);
                    return resourceArchery;
                case "barracks":
                    var resourceBarracks = new Resource(ResourceType.Steel, 10);
                    return resourceBarracks;
                default:
                    throw new ArgumentException("Unkonwn type buildin");
            }
        }
    }
}