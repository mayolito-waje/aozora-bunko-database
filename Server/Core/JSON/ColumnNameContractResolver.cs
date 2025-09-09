using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Server.Core.JSON;

public class ColumnNameContractResolver : CamelCasePropertyNamesContractResolver
{
  protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
  {
    var prop = base.CreateProperty(member, memberSerialization);

    var columnAttribute = member.GetCustomAttribute<ColumnAttribute>();
    if (columnAttribute != null)
    {
      prop.PropertyName = columnAttribute.Name;
    }

    return prop;
  }
}
