using System.Reflection;

namespace WebAPI.Configurations.Exceptions;

public class EntityNotFoundException(MemberInfo entity, string? key) 
    : Exception($"{entity.Name} {key} was not found");